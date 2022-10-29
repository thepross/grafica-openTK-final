using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;

namespace grafica_clase1
{
    [DataContract]
    public class Cara
    {
        [DataMember]
        private Vect3 centro;
        [DataMember]
        private Vect3 color;
        [DataMember]
        private Dictionary<string, Vect3> vertices;
        [DataMember]
        public float angulo;
        public float rotacionX;
        public float rotacionY;
        public float rotacionZ;
        public float tx;
        public float ty;
        public float tz;
        public float ex;
        public float ey;
        public float ez;
        public Cara()
        {
            vertices = new Dictionary<string, Vect3>();
            angulo = 0.0f;
            rotacionX = 0.0f;
            rotacionY = 0.0f;
            rotacionZ = 0.0f;
            tx = 0; ty = 0; tz = 0;
            ex = 1.0f; ey = 1.0f; ez = 1.0f;
        }

        public Cara(Dictionary<string, Vect3> vertices)
        {
            this.vertices = vertices;
            angulo = 0.0f;
            rotacionX = 0.0f;
            rotacionY = 0.0f;
            rotacionZ = 0.0f;
            tx = 0; ty = 0; tz = 0;
            ex = 1.0f; ey = 1.0f; ez = 1.0f;
        }

        public Cara(Dictionary<string, Vect3> vertices, Vect3 centro, Vect3 color)
        {
            this.vertices = vertices;
            this.color = color;
            this.centro = centro;
            angulo = 0.0f;
            rotacionX = 0.0f;
            rotacionY = 0.0f;
            rotacionZ = 0.0f;
            tx = 0; ty = 0; tz = 0;
            ex = 1.0f; ey = 1.0f; ez = 1.0f;
        }

        public void addVertice(string key, Vect3 vertice)
        {
            this.vertices.Add(key, vertice);
        }

        public void addVertices(Dictionary<string, Vect3> vertices)
        {
            this.vertices = vertices;
        }

        public void addColor(Vect3 color)
        {
            this.color = color;
        }

        public void addColor(Color color)
        {
            this.color = new Vect3(color.R, color.G, color.B);
        }

        public void setCentro(Vect3 centro)
        {
            this.centro = centro;
        }

        public void setRotacion(float angulo, float x, float y, float z)
        {
            this.angulo = angulo;
            this.rotacionX = x;
            this.rotacionY = y;
            this.rotacionZ = z;
        }
        public void setRotacion(float x, float y, float z)
        {
            this.rotacionX = x;
            this.rotacionY = y;
            this.rotacionZ = z;
        }
        public void setRotacionX(float angulo, float x)
        {
            this.angulo = angulo;
            this.rotacionX = x;
            this.rotacionY = 0.0f;
            this.rotacionZ = 0.0f;
        }
        public void setRotacionY(float angulo, float y)
        {
            this.angulo = angulo;
            this.rotacionY = y;
            this.rotacionX = 0.0f;
            this.rotacionZ = 0.0f;
        }
        public void setRotacionZ(float angulo, float z)
        {
            this.angulo = angulo;
            this.rotacionZ = z;
            this.rotacionX = 0.0f;
            this.rotacionY = 0.0f;
        }

        public void setTraslacion(float x, float y, float z)
        {
            this.tx = x;
            this.ty = y;
            this.tz = z;
        }
        public void setTraslacionX(float x)
        {
            this.tx = x;
        }
        public void setTraslacionY(float y)
        {
            this.ty = y;
        }
        public void setTraslacionZ(float z)
        {
            this.tz = z;
        }

        public void setEscalacion(float x, float y, float z)
        {
            this.ex = x;
            this.ey = y;
            this.ez = z;
        }
        public void setEscalacionX(float x)
        {
            this.ex = x;
        }
        public void setEscalacionY(float y)
        {
            this.ey = y;
        }
        public void setEscalacionZ(float z)
        {
            this.ez = z;
        }

        public void dibujar()
        {
            GL.PushMatrix();
            rotar(this.angulo, this.rotacionX, this.rotacionY, this.rotacionZ);
            mover(this.tx, this.ty, this.tz);
            escalar(this.ex, this.ey, this.ez);
            GL.Begin(PrimitiveType.Polygon);
            GL.Color3(this.color.X, this.color.Y, this.color.Z);
            foreach (var vector in vertices.Values)
            {
                GL.Vertex3(this.centro.X + vector.X, this.centro.Y + vector.Y, this.centro.Z + vector.Z);
            }
            GL.End();
            GL.PopMatrix();
        }

        public void rotar(float rotacion, float x, float y, float z)
        {
            GL.Translate(this.centro.X, this.centro.Y, this.centro.Z);
            GL.Rotate(rotacion, x, y, z);
            GL.Translate(-this.centro.X, -this.centro.Y, -this.centro.Z);
        }
        public void mover(float x, float y, float z)
        {
            GL.Translate(x, y, z);
        }
        public void escalar(float x, float y, float z)
        {
            GL.Scale(x, y, z);
        }
    }
}
