using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grafica_clase1
{
    public interface Objeto
    {
        void dibujar();
        void rotar(float rotacion, float x, float y, float z);
        void guardarJson();
        Objeto recuperarJson();
    }
}
