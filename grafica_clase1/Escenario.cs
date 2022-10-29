using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace grafica_clase1
{
    [DataContract]
    public class Escenario : Objeto
    {
        [DataMember]
        public Dictionary<string, Figura> figuras;
        [DataMember]
        public Vect3 centro;
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


        public Escenario()
        {
            figuras = new Dictionary<string, Figura>();
            angulo = 0.0f;
            rotacionX = 0.0f;
            rotacionY = 0.0f;
            rotacionZ = 0.0f;
            tx = 0; ty = 0; tz = 0;
            ex = 1.0f; ey = 1.0f; ez = 1.0f;
        }

        public void addFigura(string nombre, Figura figura)
        {
            figuras.Add(nombre, figura);
        }

        public void addCentro(Vect3 centro)
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
            this.centro.X = x;
        }
        public void setTraslacionY(float y)
        {
            this.ty = y;
            this.centro.Y = y;
        }
        public void setTraslacionZ(float z)
        {
            this.tz = z;
            this.centro.Z = z;
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
            foreach (Figura figura in figuras.Values)
            {
                GL.PushMatrix();
                rotar(this.angulo, this.rotacionX, this.rotacionY, this.rotacionZ);
                mover(this.tx, this.ty, this.tz);
                escalar(this.ex, this.ey, this.ez);
                figura.dibujar();
                GL.PopMatrix();
            }
        }
        

        public void rotar(float angulo, float x, float y, float z)
        {
            foreach (var figura in this.figuras.Values)
            {
                figura.rotar(angulo, x, y, z);
            }
        }
        public void mover(float x, float y, float z)
        {
            foreach (var figura in this.figuras.Values)
            {
                figura.mover(x, y, z);
            }
        }
        public void escalar(float x, float y, float z)
        {
            foreach (var figura in this.figuras.Values)
            {
                figura.escalar(x, y, z);
            }
        }

        public void guardarJson()
        {
            Utils.guardarJson(this, "Escenario");
        }

        public Objeto recuperarJson()
        {
            return Utils.agregarDesdeJson("Escenario.json");
        }
    }
}
