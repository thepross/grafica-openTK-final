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


    public partial class ControlForm : Form
    {
        Ventana v;
        float trackBarValue1 = 0.0f;
        float trackBarValue2 = 0.0f;
        float trackBarValue3 = 0.0f;
        
        public ControlForm()
        {
            InitializeComponent();
        }

        public void llenarComboBox()
        {
            guna2ComboBox1.Items.Clear();
            foreach (Figura figura in v.Escenario.figuras.Values)
            {
                guna2ComboBox1.Items.Add(figura.Nombre);
            }
        }

        public void llenarComboBox2(string nombreFigura)
        {
            guna2ComboBox2.Items.Clear();
            List<string> caras = new List<string>(v.Escenario.figuras[nombreFigura].Caras.Keys);
            foreach (string cara in caras)
            {
                guna2ComboBox2.Items.Add(cara);
            }
        }

        private void ControlForm_Load(object sender, EventArgs e)
        {
            v = new Ventana(800, 600);
            llenarComboBox();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Thread t = new Thread((ThreadStart)(() => {
                esquema();
            }));
            t.Start();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            v.Escenario.figuras["Automovil"].Caras["r1"].angulo = 0;
            v.Escenario.figuras["Automovil"].Caras["r2"].angulo = 0;

            v.Escenario.figuras["Automovil"].tx = 0.0f;
            v.Escenario.figuras["Automovil"].ex = 1.0f;
            v.Escenario.figuras["Automovil"].ey = 1.0f;
            v.Escenario.figuras["Automovil"].ez = 1.0f;
            esquema();
        }

        public void esquema()
        {
            v.Escenario.figuras["Automovil"].Caras["r1"].setRotacionZ(v.Escenario.figuras["Automovil"].Caras["r1"].angulo, 1.0f);
            v.Escenario.figuras["Automovil"].Caras["r2"].setRotacionZ(v.Escenario.figuras["Automovil"].Caras["r2"].angulo, 1.0f);
            v.Escenario.figuras["Automovil"].Caras["r1"].angulo += 15.0f;
            v.Escenario.figuras["Automovil"].Caras["r2"].angulo += 15.0f;

            v.Escenario.figuras["Automovil"].setTraslacionX(v.Escenario.figuras["Automovil"].tx);
            v.Escenario.figuras["Automovil"].tx -= 0.01f;

            v.Escenario.figuras["Automovil"].setEscalacion(
                v.Escenario.figuras["Automovil"].ex,
                v.Escenario.figuras["Automovil"].ey,
                v.Escenario.figuras["Automovil"].ez);
            v.Escenario.figuras["Automovil"].ex -= 0.002f;
            v.Escenario.figuras["Automovil"].ey -= 0.002f;
            v.Escenario.figuras["Automovil"].ez -= 0.002f;
        }


        private void guna2TrackBar1_Scroll(object sender, ScrollEventArgs e)
        {
            Console.WriteLine(guna2TrackBar1.Value);
            if (guna2ComboBox3.SelectedItem.Equals("Rotacion"))
            {
                if (guna2ComboBox1.SelectedIndex != -1)
                {
                    if (guna2ComboBox2.SelectedIndex != -1)
                    {
                        v.Escenario
                            .figuras[guna2ComboBox1.SelectedItem.ToString()]
                            .Caras[guna2ComboBox2.SelectedItem.ToString()]
                        .setRotacionX(guna2TrackBar1.Value * 4, 1.0f);
                    }
                    else
                    {
                        v.Escenario
                            .figuras[guna2ComboBox1.SelectedItem.ToString()]
                        .setRotacionX(guna2TrackBar1.Value * 2, 1.0f);
                    }
                }
                else
                {
                    v.Escenario.setRotacionX(guna2TrackBar1.Value, 1.0f);
                }
            }
            if (guna2ComboBox3.SelectedItem.Equals("Traslacion"))
            {
                if (guna2ComboBox1.SelectedIndex != -1)
                {
                    if (guna2ComboBox2.SelectedIndex != -1)
                    {
                        v.Escenario
                            .figuras[guna2ComboBox1.SelectedItem.ToString()]
                            .Caras[guna2ComboBox2.SelectedItem.ToString()]
                        .setTraslacionX(guna2TrackBar1.Value * 0.1f);
                    }
                    else
                    {
                        v.Escenario
                            .figuras[guna2ComboBox1.SelectedItem.ToString()]
                        .setTraslacionX(guna2TrackBar1.Value * 0.1f);
                    }
                }
                else
                {
                    v.Escenario.setTraslacionX(guna2TrackBar1.Value * 0.1f);
                }
            }
            if (guna2ComboBox3.SelectedItem.Equals("Escalacion"))
            {
                if (guna2ComboBox1.SelectedIndex != -1)
                {
                    if (guna2ComboBox2.SelectedIndex != -1)
                    {
                        v.Escenario
                            .figuras[guna2ComboBox1.SelectedItem.ToString()]
                            .Caras[guna2ComboBox2.SelectedItem.ToString()]
                        .setEscalacionX(guna2TrackBar1.Value * 0.5f);
                    }
                    else
                    {
                        v.Escenario
                            .figuras[guna2ComboBox1.SelectedItem.ToString()]
                        .setEscalacionX(guna2TrackBar1.Value * 0.1f);
                    }
                }
                else
                {
                    v.Escenario.setEscalacionX(guna2TrackBar1.Value * 0.1f);
                }
            }
        }

        private void guna2TrackBar2_Scroll(object sender, ScrollEventArgs e)
        {
            if (guna2ComboBox3.SelectedIndex == -1)
            {
                return;
            }
            if (guna2ComboBox3.SelectedItem.Equals("Rotacion"))
            {
                if (guna2ComboBox1.SelectedIndex != -1)
                {
                    if (guna2ComboBox2.SelectedIndex != -1)
                    {
                        v.Escenario
                            .figuras[guna2ComboBox1.SelectedItem.ToString()]
                            .Caras[guna2ComboBox2.SelectedItem.ToString()]
                            .setRotacionY(guna2TrackBar2.Value * 4, 1.0f);
                    }
                    else
                    {
                        v.Escenario
                            .figuras[guna2ComboBox1.SelectedItem.ToString()]
                            .setRotacionY(guna2TrackBar2.Value * 2, 1.0f);
                    }
                }
                else
                {
                    v.Escenario.setRotacionY(guna2TrackBar2.Value, 1.0f);
                }
            }
            if (guna2ComboBox3.SelectedItem.Equals("Traslacion"))
            {
                if (guna2ComboBox1.SelectedIndex != -1)
                {
                    if (guna2ComboBox2.SelectedIndex != -1)
                    {
                        v.Escenario
                            .figuras[guna2ComboBox1.SelectedItem.ToString()]
                            .Caras[guna2ComboBox2.SelectedItem.ToString()]
                            .setTraslacionY(guna2TrackBar2.Value * 0.1f);
                    }
                    else
                    {
                        v.Escenario
                            .figuras[guna2ComboBox1.SelectedItem.ToString()]
                            .setTraslacionY(guna2TrackBar2.Value * 0.1f);
                    }
                }
                else
                {
                    v.Escenario.setTraslacionY(guna2TrackBar2.Value * 0.1f);
                }
            }
            if (guna2ComboBox3.SelectedItem.Equals("Escalacion"))
            {
                if (guna2ComboBox1.SelectedIndex != -1)
                {
                    if (guna2ComboBox2.SelectedIndex != -1)
                    {
                        v.Escenario
                            .figuras[guna2ComboBox1.SelectedItem.ToString()]
                            .Caras[guna2ComboBox2.SelectedItem.ToString()]
                            .setEscalacionY(guna2TrackBar2.Value * 0.1f);
                    }
                    else
                    {
                        v.Escenario
                            .figuras[guna2ComboBox1.SelectedItem.ToString()]
                            .setEscalacionY(guna2TrackBar2.Value * 0.1f);
                    }
                }
                else
                {
                    v.Escenario.setEscalacionY(guna2TrackBar2.Value * 0.1f);
                }
            }
            trackBarValue2 = guna2TrackBar2.Value;
        }

        private void guna2TrackBar3_Scroll(object sender, ScrollEventArgs e)
        {
            if (guna2ComboBox3.SelectedIndex == -1)
            {
                return;
            }
            if (guna2ComboBox3.SelectedItem.Equals("Rotacion"))
            {
                if (guna2ComboBox1.SelectedIndex != -1)
                {
                    if (guna2ComboBox2.SelectedIndex != -1)
                    {
                        v.Escenario
                            .figuras[guna2ComboBox1.SelectedItem.ToString()]
                            .Caras[guna2ComboBox2.SelectedItem.ToString()]
                            .setRotacionZ(guna2TrackBar3.Value * 4, 1.0f);
                    }
                    else
                    {
                        v.Escenario
                            .figuras[guna2ComboBox1.SelectedItem.ToString()]
                            .setRotacionZ(guna2TrackBar3.Value * 2, 1.0f);
                    }
                }
                else
                {
                    v.Escenario.setRotacionZ(guna2TrackBar3.Value, 1.0f);
                }
            }
            if (guna2ComboBox3.SelectedItem.Equals("Traslacion"))
            {
                if (guna2ComboBox1.SelectedIndex != -1)
                {
                    if (guna2ComboBox2.SelectedIndex != -1)
                    {
                        v.Escenario
                            .figuras[guna2ComboBox1.SelectedItem.ToString()]
                            .Caras[guna2ComboBox2.SelectedItem.ToString()]
                            .setTraslacionZ(guna2TrackBar3.Value * 0.1f);
                    }
                    else
                    {
                        v.Escenario
                            .figuras[guna2ComboBox1.SelectedItem.ToString()]
                            .setTraslacionZ(guna2TrackBar3.Value * 0.1f);
                    }
                }
                else
                {
                    v.Escenario.setTraslacionZ(guna2TrackBar3.Value * 0.1f);
                }
            }
            if (guna2ComboBox3.SelectedItem.Equals("Escalacion"))
            {
                if (guna2ComboBox1.SelectedIndex != -1)
                {
                    if (guna2ComboBox2.SelectedIndex != -1)
                    {
                        v.Escenario
                            .figuras[guna2ComboBox1.SelectedItem.ToString()]
                            .Caras[guna2ComboBox2.SelectedItem.ToString()]
                            .setEscalacionZ(guna2TrackBar3.Value * 0.1f);
                    }
                    else
                    {
                        v.Escenario
                            .figuras[guna2ComboBox1.SelectedItem.ToString()]
                            .setEscalacionZ(guna2TrackBar3.Value * 0.1f);
                    }
                }
                else
                {
                    v.Escenario.setEscalacionZ(guna2TrackBar3.Value * 0.1f);
                }
            }
            trackBarValue3 = guna2TrackBar3.Value;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Thread t = new Thread((ThreadStart)(() => {
                OpenFileDialog saveFileDialog1 = new OpenFileDialog();

                saveFileDialog1.Filter = "JSON Files (*.json)|*.json";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    v.Escenario = (Escenario)Utils.agregarDesdeJson(saveFileDialog1.FileName);
                }
            }));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();

            llenarComboBox();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            v.Run();
        }

        private void guna2ComboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (guna2ComboBox1.SelectedIndex != -1)
            {
                llenarComboBox2(guna2ComboBox1.SelectedItem.ToString());
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            guna2ComboBox1.SelectedIndex = -1;
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            guna2ComboBox2.SelectedIndex = -1;
        }
    }


}
