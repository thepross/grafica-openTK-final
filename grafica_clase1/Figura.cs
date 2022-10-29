using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace grafica_clase1
{
    [DataContract]
    public class Figura : Objeto
    {
        [DataMember]
        private string nombre;
        [DataMember]
        private Vect3 centro;
        [DataMember]
        private float x;
        [DataMember]
        private float y;
        [DataMember]
        private float z;
        [DataMember]
        private Color4 color;
        [DataMember]
        private Dictionary<string, Cara> caras;
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

        public Figura()
        {
            caras = new Dictionary<string, Cara>();
            angulo = 0.0f;
            rotacionX = 0.0f;
            rotacionY = 0.0f;
            rotacionZ = 0.0f;
            tx = 0; ty = 0; tz = 0;
            ex = 1.0f; ey = 1.0f; ez = 1.0f;
        }

        public Figura(Vect3 centro, float x, float y, float z, Color4 color)
        {
            this.Color = color;
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.Centro = centro;
            Caras = new Dictionary<string, Cara>();
            this.Nombre = "Figura";
            angulo = 0.0f;
            rotacionX = 0.0f;
            rotacionY = 0.0f;
            rotacionZ = 0.0f;
            tx = 0; ty = 0; tz = 0;
            ex = 1.0f; ey = 1.0f; ez = 1.0f;
        }

        public Figura(string nombre, Vect3 centro, Dictionary<string, Cara> caras)
        {
            this.Nombre = nombre;
            this.Centro = centro;
            this.Caras = caras;
            angulo = 0.0f;
            rotacionX = 0.0f;
            rotacionY = 0.0f;
            rotacionZ = 0.0f;
            tx = 0; ty = 0; tz = 0;
            ex = 1.0f; ey = 1.0f; ez = 1.0f;
        }

        public float X { get => x; set => x = value; }
        public float Y { get => y; set => y = value; }
        public float Z { get => z; set => z = value; }
        public Dictionary<string, Cara> Caras { get => caras; set => caras = value; }
        public Color4 Color { get => color; set => color = value; }
        public Vect3 Centro { get => centro; set => centro = value; }
        public string Nombre { get => nombre; set => nombre = value; }


        public void setRotacion(float angulo, float x, float y, float z)
        {
            this.angulo = angulo;
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
            tx = x;
            ty = y;
            tz = z;
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
            ex = x;
            ey = y;
            ez = z;
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
            foreach (var cara in this.Caras.Values)
            {
                GL.PushMatrix();
                rotar(this.angulo, this.rotacionX, this.rotacionY, this.rotacionZ);
                mover(this.tx, this.ty, this.tz);
                escalar(this.ex, this.ey, this.ez);
                cara.dibujar();
                GL.PopMatrix();
            }
        }
        public void rotar(float rotacion, float x, float y, float z)
        {
            foreach (var cara in this.caras.Values)
            {
                cara.rotar(rotacion, x, y, z);
            }
        }
        public void mover(float x, float y, float z)
        {
            foreach (var cara in this.caras.Values)
            {
                cara.mover(x, y, z);
            }
        }
        public void escalar(float x, float y, float z)
        {
            foreach (var cara in this.caras.Values)
            {
                cara.escalar(x, y, z);
            }
        }

        public void guardarJson()
        {
            Utils.guardarJson(this, nombre);
        }

        public Objeto recuperarJson()
        {
            return Utils.agregarDesdeJson(nombre);
        }
    }
}
