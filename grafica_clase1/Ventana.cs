using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace grafica_clase1
{
    public class Ventana : GameWindow
    {

        float speed = 0.2f;
        Vector3 position = new Vector3(0.0f, 0.0f, 15.0f);
        Vector3 front = new Vector3(0.0f, 0.0f, -1.0f);
        Vector3 up = new Vector3(0.0f, 1.0f, 0.0f);

        public float tx = 0.0f;
        public float ty = 0.0f;
        public float tz = 0.0f;

        public float rotarCubo;
        float rotarCuboCara;
        float rotarPiramide;

        public Escenario Escenario { set; get; }

        public Ventana(int width, int height) : base(width, height, GraphicsMode.Default, "Programación Gráfica")
        {
            VSync = VSyncMode.On;
            rotarCubo = 0;
            rotarCuboCara = 0;
            rotarPiramide = 0;

            Escenario = new Escenario();
            //-----------------------------------------------------------------------------------------------------------------
            Escenario = (Escenario)Utils.agregarDesdeJson("Escenario2.json");
            //-----------------------------------------------------------------------------------------------------------------

            
        }


        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(0.0f, 0.01f, 0.05f, 0.0f);
            GL.Enable(EnableCap.DepthTest);

            base.OnLoad(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.DepthMask(true);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit | ClearBufferMask.StencilBufferBit);
            Matrix4 modelview = Matrix4.LookAt(position, position + front, up);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelview);
            //dibujarPiso();

            //-----------------------------------------------------------------------------------------------------------------
            Escenario.dibujar();
            //-----------------------------------------------------------------------------------------------------------------

            SwapBuffers();
            base.OnRenderFrame(e);
        }


        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
            ContextMenuStrip c = new ContextMenuStrip();
            c.Show();
        }


        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            KeyboardState input = Keyboard.GetState();

            // mover
            if (input.IsKeyDown(Key.Left))
            {
                rotarCuboCara = rotarCuboCara - 0.5f;
                //escenario.figuras["cubo"].rotacion = rotarCubo;
                Escenario.figuras["Cubo"].Caras["c1"].angulo = rotarCuboCara;
                Console.WriteLine(rotarCuboCara);
            }

            if (input.IsKeyDown(Key.Right))
            {
                rotarCubo = rotarCubo + 0.2f;
                Escenario.figuras["Cubo"].angulo = rotarCubo;
                Console.WriteLine(rotarCubo);
            }
            if (input.IsKeyDown(Key.Up))
            {
                rotarPiramide = rotarPiramide + 0.2f;
                Escenario.figuras["Piramide"].angulo = rotarPiramide;
                Console.WriteLine(rotarPiramide);
            }
            if (input.IsKeyDown(Key.Down))
            {
                rotarPiramide = rotarPiramide - 0.2f;
                Escenario.figuras["Piramide"].angulo = rotarPiramide;
                Console.WriteLine(rotarPiramide);
            }

            // camara
            if (input.IsKeyDown(Key.W))
            {
                position += front * speed;
            }

            if (input.IsKeyDown(Key.S))
            {
                position -= front * speed;
            }

            if (input.IsKeyDown(Key.A))
            {
                position -= Vector3.Normalize(Vector3.Cross(front, up)) * speed;
            }

            if (input.IsKeyDown(Key.D))
            {
                position += Vector3.Normalize(Vector3.Cross(front, up)) * speed;
            }

            if (input.IsKeyDown(Key.Space))
            {
                position += up * speed;
            }

            if (input.IsKeyDown(Key.LShift))
            {
                position -= up * speed;
            }

            if (input.IsKeyDown(Key.Escape))
            {
                Exit();
            }

            if (!Focused)
            {
                return;
            }
        }


        protected override void OnResize(EventArgs e)
        {

            base.OnResize(e);
            GL.Viewport(0, 0, this.Width, this.Height);

            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, Width / (float)Height, 1.0f, 64.0f);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);
        }

        public void dibujarPiso()
        {
            GL.PushMatrix();
            GL.Begin(PrimitiveType.Polygon);
            GL.Color3(0.03f, 0.09f, 0.09f);
            GL.Vertex3(-20.0f, -2.0, -20.0f);
            GL.Vertex3(20.0f, -2.0, -20.0f);
            GL.Vertex3(20.0f, -2.0, 20.0f);
            GL.Vertex3(-20.0f, -2.0, 20.0f);
            GL.End();
        }

        

    }


}
