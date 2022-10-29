using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grafica_clase1
{
    public partial class Form1 : Form
    {
        float speed = 0.2f;
        Vector3 position = new Vector3(0.0f, 0.0f, 10.0f);
        Vector3 front = new Vector3(0.0f, 0.0f, -1.0f);
        Vector3 up = new Vector3(0.0f, 1.0f, 0.0f);

        public float tx = 0.0f;
        public float ty = 0.0f;
        public float tz = 0.0f;

        //float rotarCubo = 0.0f;

        

        Escenario escenario;

        public Form1()
        {
            InitializeComponent();

            glControl1.VSync = true;

            escenario = new Escenario();
            //-----------------------------------------------------------------------------------------------------------------
            escenario = (Escenario)Utils.agregarDesdeJson("Escenario1.json");
            //-----------------------------------------------------------------------------------------------------------------

            llenarComboBox();

        }

        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(0.0f, 0.01f, 0.05f, 0.0f);
            GL.Enable(EnableCap.DepthTest);

            base.OnLoad(e);
        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            redraw();
        }

        public void redraw()
        {
            glControl1.MakeCurrent();
            GL.DepthMask(true);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit | ClearBufferMask.StencilBufferBit);
            Matrix4 modelview = Matrix4.LookAt(position, position + front, up);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelview);

            //-----------------------------------------------------------------------------------------------------------------

            escenario.dibujar();

            //rotarCubo = rotarCubo + 0.2f;

            //escenario.figuras["Cubo"].rotacion = rotarCubo;

            //escenario.figuras["Cubo"].angulo = rotarCubo;
            //escenario.figuras["Cubo"].setRotacion(rotarCubo, 0.0f, 1.0f, 0.0f);
            ////escenario.rotar(rotarCubo, 0.0f, 1.0f, 0.0f);
            //Console.WriteLine(rotarCubo);

            //-----------------------------------------------------------------------------------------------------------------

            glControl1.Invalidate();
            GL.Finish();
            glControl1.SwapBuffers();
        }

        private void glControl1_Resize(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, glControl1.Width, glControl1.Height);

            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, Width / (float)Height, 1.0f, 64.0f);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread t = new Thread((ThreadStart)(() => {
                OpenFileDialog saveFileDialog1 = new OpenFileDialog();

                saveFileDialog1.Filter = "JSON Files (*.json)|*.json";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    escenario = (Escenario)Utils.agregarDesdeJson(saveFileDialog1.FileName);
                    
                }
            }));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();

            llenarComboBox();
        }

        public void llenarComboBox()
        {
            comboBox1.Items.Clear();
            foreach (Figura figura in escenario.figuras.Values)
            {
                comboBox1.Items.Add(figura.Nombre);
            }
        }

        public void llenarComboBox2(string nombreFigura)
        {
            comboBox2.Items.Clear();
            List<string> caras = new List<string>(escenario.figuras[nombreFigura].Caras.Keys);
            foreach (string cara in caras)
            {
                comboBox2.Items.Add(cara);
            }
        }

        private void glControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.I)
            {
                if (comboBox1.SelectedIndex != -1)
                {
                    if (comboBox2.SelectedIndex != -1)
                    {
                        escenario.figuras[comboBox1.SelectedItem.ToString()].Caras[comboBox2.SelectedItem.ToString()].angulo -= 0.6f;
                        escenario.figuras[comboBox1.SelectedItem.ToString()].Caras[comboBox2.SelectedItem.ToString()].setRotacion(1.0f, 0.0f, 0.0f);
                    }
                    else
                    {
                        escenario.figuras[comboBox1.SelectedItem.ToString()].angulo -= 0.6f;
                    }
                }
                else
                {
                    escenario.angulo -= 0.6f;
                    escenario.setRotacion(escenario.angulo, 1.0f, 0.0f, 0.0f);
                }
            }
            if (e.KeyCode == Keys.K)
            {
                if (comboBox1.SelectedIndex != -1)
                {
                    if (comboBox2.SelectedIndex != -1)
                    {
                        escenario.figuras[comboBox1.SelectedItem.ToString()].Caras[comboBox2.SelectedItem.ToString()].angulo += 0.6f;
                    }
                    else
                    {
                        escenario.figuras[comboBox1.SelectedItem.ToString()].angulo += 0.6f;
                    }
                }
                else
                {
                    escenario.angulo += 0.6f;
                    escenario.setRotacion(escenario.angulo, 1.0f, 0.0f, 0.0f);
                }
            }
            if (e.KeyCode == Keys.J)
            {
                escenario.angulo += 0.6f;
                escenario.setRotacion(escenario.angulo, 0.0f, 1.0f, 0.0f);
            }
            if (e.KeyCode == Keys.L)
            {
                escenario.angulo -= 0.6f;
                escenario.setRotacion(escenario.angulo, 0.0f, 1.0f, 0.0f);
            }

            // camara
            if (e.KeyCode == Keys.W)
            {
                position += front * speed;
            }

            if (e.KeyCode == Keys.S)
            {
                position -= front * speed;
            }

            if (e.KeyCode == Keys.A)
            {
                position -= Vector3.Normalize(Vector3.Cross(front, up)) * speed;
            }

            if (e.KeyCode == Keys.D)
            {
                position += Vector3.Normalize(Vector3.Cross(front, up)) * speed;
            }

            if (e.KeyCode == Keys.Space)
            {
                position += up * speed;
            }

            if (e.KeyCode == Keys.LShiftKey)
            {
                position -= up * speed;
            }

            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }

            if (!Focused)
            {
                return;
            }
        }

        private void glControl1_Load(object sender, EventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                if (comboBox2.SelectedIndex != -1)
                {
                    escenario.figuras[comboBox1.SelectedItem.ToString()].Caras[comboBox2.SelectedItem.ToString()].angulo -= 0.6f;
                } else
                {
                    escenario.figuras[comboBox1.SelectedItem.ToString()].angulo -= 0.6f;
                }
            } else
            {
                escenario.setRotacion(-0.6f, 1.0f, 0.0f, 0.0f);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                if (comboBox2.SelectedIndex != -1)
                {
                    escenario.figuras[comboBox1.SelectedItem.ToString()].Caras[comboBox2.SelectedItem.ToString()].angulo += 0.6f;
                } else
                {
                    escenario.figuras[comboBox1.SelectedItem.ToString()].angulo += 0.6f;
                }
            } else
            {
                escenario.setRotacion(0.6f, 1.0f, 0.0f, 0.0f);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                llenarComboBox2(comboBox1.SelectedItem.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            comboBox2.SelectedIndex = -1;
        }
    }
}
