using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grafica_clase1
{
    class Program
    {
        static void Main(string[] args)
        {

            //guardarJson();
            //saveAuto();

            //escenario2();

            Application.Run(new ControlForm());

            //Ventana window = new Ventana(800, 600);
            //window.Run();
        }


        public static void escenario2()
        {
            Escenario e = new Escenario();

            Dictionary<string, Cara> caras = new Dictionary<string, Cara>();
            Vect3 centroEscenario = new Vect3(0.0, 0.0, 0.0);
            Vect3 centroFigura = new Vect3(5.0, 0.0, 0.0);

            string nombre = "Auto";
            //---------------------------------------------------------------------------------------------------------------------

            Dictionary<string, Cara> faces = new Dictionary<string, Cara>();

            Vect3 centro = new Vect3(centroFigura.X + 0.0f, centroFigura.Y + 0.0f, centroFigura.Z + 0.0f);
            Dictionary<string, Vect3> lista = new Dictionary<string, Vect3>();
            lista.Add("v1", new Vect3(1.0f, 1.0f, 0.0f));
            lista.Add("v2", new Vect3(-1.0f, 1.0f, 0.0f));
            lista.Add("v3", new Vect3(1.0f, 0.0f, 0.0f));
            lista.Add("v4", new Vect3(2.0f, 0.0f, 0.0f));
            lista.Add("v5", new Vect3(2.0f, -1.0f, 0.0f));
            lista.Add("v6", new Vect3(-2.0f, -1.0f, 0.0f));
            lista.Add("v7", new Vect3(-2.0f, 0.0f, 0.0f));
            lista.Add("v8", new Vect3(-1.0f, 0.0f, 0.0f));
            lista.Add("v9", new Vect3(-1.0f, 1.0f, 0.0f));
            Cara face = new Cara(lista, centro, new Vect3(1.0, 0.29, 0.0));
            faces.Add("carro1", face);

            centro = new Vect3(centroFigura.X - 1.0f, centroFigura.Y - 1.0f, centroFigura.Z + 0.0f);
            lista = new Dictionary<string, Vect3>();
            lista.Add("v1", new Vect3(-0.3f, 0.35f, 0.1f));
            lista.Add("v2", new Vect3(0.3f, 0.35f, 0.1f));
            lista.Add("v3", new Vect3(0.45f, 0.0f, 0.1f));
            lista.Add("v4", new Vect3(0.3f, -0.35f, 0.1f));
            lista.Add("v5", new Vect3(-0.3f, -0.35f, 0.1f));
            lista.Add("v6", new Vect3(-0.45f, 0.0f, 0.1f));
            face = new Cara(lista);
            face.addColor(Color.White);
            face.setCentro(centro);
            faces.Add("r1", face);

            centro = new Vect3(centroFigura.X + 0.9f, centroFigura.Y - 1.0f, centroFigura.Z + 0.0f);
            lista = new Dictionary<string, Vect3>();
            lista.Add("v1", new Vect3(-0.3f, 0.35f, 0.1f));
            lista.Add("v2", new Vect3(0.3f, 0.35f, 0.1f));
            lista.Add("v3", new Vect3(0.45f, 0.0f, 0.1f));
            lista.Add("v4", new Vect3(0.3f, -0.35f, 0.1f));
            lista.Add("v5", new Vect3(-0.3f, -0.35f, 0.1f));
            lista.Add("v6", new Vect3(-0.45f, 0.0f, 0.1f));
            face = new Cara(lista);
            face.addColor(Color.White);
            face.setCentro(centro);
            faces.Add("r2", face);

            nombre = "Automovil";
            Figura figura = new Figura(nombre, centroFigura, faces);

            e.addFigura(nombre, figura); // agregado auto

            //---------------------------------------------------------------------------------------------------------------------

            centroFigura = new Vect3(-2.0, 0.0, 0.0);
            faces = new Dictionary<string, Cara>();

            lista = new Dictionary<string, Vect3>();
            lista.Add("v1", new Vect3(0.3f, 1.0f, 0.0f));
            lista.Add("v2", new Vect3(0.3f, -1.0f, 0.0f));
            lista.Add("v3", new Vect3(-0.3f, -1.0f, 0.0f));
            lista.Add("v4", new Vect3(-0.3f, 1.0f, 0.0f));
            centro = new Vect3(centroFigura.X - 5.0f, centroFigura.Y + 0.0f, centroFigura.Z + 0.0f);
            face = new Cara(lista, centro, new Vect3(0.58, 0.29, 0.0));
            faces.Add("tronco1", face);
           
            lista = new Dictionary<string, Vect3>();
            lista.Add("v1", new Vect3(-0.7f, 1.0f, 0.0f));
            lista.Add("v2", new Vect3(0.7f, 1.0f, 0.0f));
            lista.Add("v3", new Vect3(1.0f, 0.0f, 0.0f));
            lista.Add("v4", new Vect3(0.7f, -1.0f, 0.0f));
            lista.Add("v5", new Vect3(-0.7f, -1.0f, 0.0f));
            lista.Add("v6", new Vect3(-1.0f, 0.0f, 0.0f));
            face = new Cara(lista);
            face.addColor(Color.Green);
            centro = new Vect3(centroFigura.X - 5.0f, centroFigura.Y + 2.0f, centroFigura.Z + 0.0f);
            face.setCentro(centro);
            faces.Add("rama1", face);

            nombre = "Arbol";
            figura = new Figura(nombre, centroFigura, faces);

            e.addFigura(nombre, figura); // agregado arbol
            e.addCentro(centroEscenario);

            Utils.guardarJson(e, "Escenario2");

        }



        public static void saveAuto()
        {
            Escenario e = new Escenario();

            Dictionary<string, Cara> caras = new Dictionary<string, Cara>();
            Dictionary<string, Vect3> lista1 = new Dictionary<string, Vect3>();
            Vect3 centro = new Vect3(0.0, 0.0, 0.0);

            Dictionary<string, Vect3> lista5 = new Dictionary<string, Vect3>();
            lista5.Add("v1", new Vect3(1.0f, 1.0f, 0.0f));
            lista5.Add("v2", new Vect3(-1.0f, 1.0f, 0.0f));
            lista5.Add("v3", new Vect3(1.0f, 0.0f, 0.0f));
            lista5.Add("v4", new Vect3(2.0f, 0.0f, 0.0f));
            lista5.Add("v5", new Vect3(2.0f, -1.0f, 0.0f));
            lista5.Add("v6", new Vect3(-2.0f, -1.0f, 0.0f));
            lista5.Add("v7", new Vect3(-2.0f, 0.0f, 0.0f));
            lista5.Add("v8", new Vect3(-1.0f, 0.0f, 0.0f));
            lista5.Add("v9", new Vect3(-1.0f, 1.0f, 0.0f));
            Cara face = new Cara(lista5, centro, new Vect3(1.0, 0.29, 0.0));
            caras.Add("c1", face);

            string nombre = "Auto";
            Figura figura = new Figura(nombre, centro, caras);

            e.addFigura(nombre, figura);

            //---------------------------------------------------------------------------------------------------------------------

            Dictionary<string, Cara> faces = new Dictionary<string, Cara>();

            centro = new Vect3(-1.0, -1.0, 0.0);
            Dictionary<string, Vect3> lista4 = new Dictionary<string, Vect3>();
            lista4 = new Dictionary<string, Vect3>();
            lista4.Add("v1", new Vect3(-0.3f, 0.35f, 0.1f));
            lista4.Add("v2", new Vect3(0.3f, 0.35f, 0.1f));
            lista4.Add("v3", new Vect3(0.45f, 0.0f, 0.1f));
            lista4.Add("v4", new Vect3(0.3f, -0.35f, 0.1f));
            lista4.Add("v5", new Vect3(-0.3f, -0.35f, 0.1f));
            lista4.Add("v6", new Vect3(-0.45f, 0.0f, 0.1f));
            face = new Cara(lista4);
            face.addColor(Color.White);
            face.setCentro(centro);
            faces.Add("c1", face);

            centro = new Vect3(0.9, -1.0, 0.0);
            lista4 = new Dictionary<string, Vect3>();
            lista4.Add("v1", new Vect3(-0.3f, 0.35f, 0.1f));
            lista4.Add("v2", new Vect3(0.3f, 0.35f, 0.1f));
            lista4.Add("v3", new Vect3(0.45f, 0.0f, 0.1f));
            lista4.Add("v4", new Vect3(0.3f, -0.35f, 0.1f));
            lista4.Add("v5", new Vect3(-0.3f, -0.35f, 0.1f));
            lista4.Add("v6", new Vect3(-0.45f, 0.0f, 0.1f));
            face = new Cara(lista4);
            face.addColor(Color.White);
            face.setCentro(centro);
            faces.Add("c2", face);

            nombre = "Ruedas";
            figura = new Figura(nombre, centro, faces);

            e.addFigura(nombre, figura);

            Utils.guardarJson(e, "Auto");
        }
        public static void saveArbol()
        {
            Escenario e = new Escenario();

            Dictionary<string, Cara> caras = new Dictionary<string, Cara>();
            Dictionary<string, Vect3> lista1 = new Dictionary<string, Vect3>();
            Vect3 centro = new Vect3(0.0, 0.0, 0.0);
            
            Dictionary<string, Vect3> lista5 = new Dictionary<string, Vect3>();
            lista5.Add("v1", new Vect3(0.3f, 1.0f, 0.0f));
            lista5.Add("v2", new Vect3(0.3f, -1.0f, 0.0f));
            lista5.Add("v3", new Vect3(-0.3f, -1.0f, 0.0f));
            lista5.Add("v4", new Vect3(-0.3f, 1.0f, 0.0f));
            Cara face = new Cara(lista5, centro, new Vect3(0.58, 0.29, 0.0));
            caras.Add("c5", face);

            

            string nombre = "Tronco";
            Figura figura = new Figura(nombre, centro, caras);

            e.addFigura(nombre, figura);

            //---------------------------------------------------------------------------------------------------------------------

            Dictionary<string, Cara> faces = new Dictionary<string, Cara>();

            centro = new Vect3(0.0, 2.0, 0.0);
            Dictionary<string, Vect3> lista4 = new Dictionary<string, Vect3>();
            lista4 = new Dictionary<string, Vect3>();
            lista4.Add("v1", new Vect3(-0.7f, 1.0f, 0.0f));
            lista4.Add("v2", new Vect3(0.7f, 1.0f, 0.0f));
            lista4.Add("v3", new Vect3(1.0f, 0.0f, 0.0f));
            lista4.Add("v4", new Vect3(0.7f, -1.0f, 0.0f));
            lista4.Add("v5", new Vect3(-0.7f, -1.0f, 0.0f));
            lista4.Add("v6", new Vect3(-1.0f, 0.0f, 0.0f));
            face = new Cara(lista4);
            face.addColor(Color.Green);
            face.setCentro(centro);
            faces.Add("c4", face);

            
            nombre = "Ramas";
            figura = new Figura(nombre, centro, faces);

            e.addFigura(nombre, figura);

            Utils.guardarJson(e, "Arbol");

        }
        public static void saveCasa()
        {
            Escenario e = new Escenario();

            Dictionary<string, Cara> caras = new Dictionary<string, Cara>();
            Dictionary<string, Vect3> lista1 = new Dictionary<string, Vect3>();
            Vect3 centro = new Vect3(0.0, 0.0, 0.0);
            lista1.Add("v1", new Vect3(-1.0f, 1.0f, 1.0f));
            lista1.Add("v2", new Vect3(-1.0f, 1.0f, -1.0f));
            lista1.Add("v3", new Vect3(-1.0f, -1.0f, -1.0f));
            lista1.Add("v4", new Vect3(-1.0f, -1.0f, 1.0f));
            Cara face = new Cara(lista1, centro, new Vect3(1.0, 1.0, 0.0));
            caras.Add("c1", face);

            Dictionary<string, Vect3> lista2 = new Dictionary<string, Vect3>();
            lista2.Add("v1", new Vect3(1.0f, 1.0f, 1.0f));
            lista2.Add("v2", new Vect3(1.0f, 1.0f, -1.0f));
            lista2.Add("v3", new Vect3(1.0f, -1.0f, -1.0f));
            lista2.Add("v4", new Vect3(1.0f, -1.0f, 1.0f));
            face = new Cara(lista2, centro, new Vect3(1.0, 1.0, 0.0));
            caras.Add("c2", face);

            Dictionary<string, Vect3> lista3 = new Dictionary<string, Vect3>();
            lista3.Add("v1", new Vect3(1.0f, -1.0f, 1.0f));
            lista3.Add("v2", new Vect3(1.0f, -1.0f, -1.0f));
            lista3.Add("v3", new Vect3(-1.0f, -1.0f, -1.0f));
            lista3.Add("v4", new Vect3(-1.0f, -1.0f, 1.0f));
            face = new Cara(lista3, centro, new Vect3(1.0, 1.0, 0.0));
            caras.Add("c3", face);

            Dictionary<string, Vect3> lista4 = new Dictionary<string, Vect3>();
            lista4.Add("v1", new Vect3(1.0f, 1.0f, 1.0f));
            lista4.Add("v2", new Vect3(1.0f, 1.0f, -1.0f));
            lista4.Add("v3", new Vect3(-1.0f, 1.0f, -1.0f));
            lista4.Add("v4", new Vect3(-1.0f, 1.0f, 1.0f));
            face = new Cara(lista4, centro, new Vect3(1.0, 1.0, 0.0));
            caras.Add("c4", face);

            Dictionary<string, Vect3> lista5 = new Dictionary<string, Vect3>();
            lista5.Add("v1", new Vect3(1.0f, 1.0f, -1.0f));
            lista5.Add("v2", new Vect3(1.0f, -1.0f, -1.0f));
            lista5.Add("v3", new Vect3(-1.0f, -1.0f, -1.0f));
            lista5.Add("v4", new Vect3(-1.0f, 1.0f, -1.0f));
            face = new Cara(lista5, centro, new Vect3(1.0, 1.0, 0.0));
            caras.Add("c5", face);

            Dictionary<string, Vect3> lista6 = new Dictionary<string, Vect3>();
            lista6.Add("v1", new Vect3(1.0f, 1.0f, 1.0f));
            lista6.Add("v2", new Vect3(1.0f, -1.0f, 1.0f));
            lista6.Add("v3", new Vect3(-1.0f, -1.0f, 1.0f));
            lista6.Add("v4", new Vect3(-1.0f, 1.0f, 1.0f));
            face = new Cara(lista6, centro, new Vect3(1.0, 1.0, 0.0));
            caras.Add("c6", face);

            string nombre = "Paredes";
            Figura figura = new Figura(nombre, centro, caras);

            e.addFigura(nombre, figura);

            //---------------------------------------------------------------------------------------------------------------------

            Dictionary<string, Cara> faces = new Dictionary<string, Cara>();

            centro = new Vect3(0.0, 2.0, 0.0);
            lista1 = new Dictionary<string, Vect3>();
            lista1.Add("v1", new Vect3(-1.0f, -1.0f, -1.0f));
            lista1.Add("v2", new Vect3(1.0f, -1.0f, -1.0f));
            lista1.Add("v3", new Vect3(0.0f, 0.4f, 0.0f));
            face = new Cara(lista1);
            face.addColor(Color.Blue);
            face.setCentro(centro);
            faces.Add("c1", face);

            lista2 = new Dictionary<string, Vect3>();
            lista2.Add("v1", new Vect3(-1.0f, -1.0f, -1.0f));
            lista2.Add("v2", new Vect3(-1.0f, -1.0f, 1.0f));
            lista2.Add("v3", new Vect3(0.0f, 0.4f, 0.0f));
            face = new Cara(lista2);
            face.addColor(Color.Blue);
            face.setCentro(centro);
            faces.Add("c2", face);

            lista3 = new Dictionary<string, Vect3>();
            lista3.Add("v1", new Vect3(1.0f, -1.0f, -1.0f));
            lista3.Add("v2", new Vect3(1.0f, -1.0f, 1.0f));
            lista3.Add("v3", new Vect3(0.0f, 0.4f, 0.0f));
            face = new Cara(lista3);
            face.addColor(Color.Blue);
            face.setCentro(centro);
            faces.Add("c3", face);

            lista4 = new Dictionary<string, Vect3>();
            lista4.Add("v1", new Vect3(-1.0f, -1.0f, 1.0f));
            lista4.Add("v2", new Vect3(1.0f, -1.0f, 1.0f));
            lista4.Add("v3", new Vect3(0.0f, 0.4f, 0.0f));
            face = new Cara(lista4);
            face.addColor(Color.Blue);
            face.setCentro(centro);
            faces.Add("c4", face);

            lista5 = new Dictionary<string, Vect3>();
            lista5.Add("v1", new Vect3(-1.0f, -1.0f, 1.0f));
            lista5.Add("v2", new Vect3(-1.0f, -1.0f, -1.0f));
            lista5.Add("v3", new Vect3(1.0f, -1.0f, -1.0f));
            lista5.Add("v4", new Vect3(1.0f, -1.0f, 1.0f));
            face = new Cara(lista5);
            face.addColor(Color.Blue);
            face.setCentro(centro);
            faces.Add("c5", face);

            nombre = "Techo";
            figura = new Figura(nombre, centro, faces);

            e.addFigura(nombre, figura);


            Utils.guardarJson(e, "Casa");

        }

        public static void guardarJson()
        {
            Escenario e = new Escenario();

            Dictionary<string, Cara> caras = new Dictionary<string, Cara>();
            Dictionary<string, Vect3> lista1 = new Dictionary<string, Vect3>();
            Vect3 centro = new Vect3(-2.0, 0.0, 0.0);
            lista1.Add("v1", new Vect3(-1.0f, 1.0f, 1.0f));
            lista1.Add("v2", new Vect3(-1.0f, 1.0f, -1.0f));
            lista1.Add("v3", new Vect3(-1.0f, -1.0f, -1.0f));
            lista1.Add("v4", new Vect3(-1.0f, -1.0f, 1.0f));
            Cara face = new Cara(lista1, centro, new Vect3(1.0, 1.0, 0.0));
            caras.Add("c1", face);

            Dictionary<string, Vect3> lista2 = new Dictionary<string, Vect3>();
            lista2.Add("v1", new Vect3(1.0f, 1.0f, 1.0f));
            lista2.Add("v2", new Vect3(1.0f, 1.0f, -1.0f));
            lista2.Add("v3", new Vect3(1.0f, -1.0f, -1.0f));
            lista2.Add("v4", new Vect3(1.0f, -1.0f, 1.0f));
            face = new Cara(lista2, centro, new Vect3(1.0f, 0.0f, 1.0f));
            caras.Add("c2", face);

            Dictionary<string, Vect3> lista3 = new Dictionary<string, Vect3>();
            lista3.Add("v1", new Vect3(1.0f, -1.0f, 1.0f));
            lista3.Add("v2", new Vect3(1.0f, -1.0f, -1.0f));
            lista3.Add("v3", new Vect3(-1.0f, -1.0f, -1.0f));
            lista3.Add("v4", new Vect3(-1.0f, -1.0f, 1.0f));
            face = new Cara(lista3, centro, new Vect3(0.0f, 1.0f, 1.0f));
            caras.Add("c3", face);

            Dictionary<string, Vect3> lista4 = new Dictionary<string, Vect3>();
            lista4.Add("v1", new Vect3(1.0f, 1.0f, 1.0f));
            lista4.Add("v2", new Vect3(1.0f, 1.0f, -1.0f));
            lista4.Add("v3", new Vect3(-1.0f, 1.0f, -1.0f));
            lista4.Add("v4", new Vect3(-1.0f, 1.0f, 1.0f));
            face = new Cara(lista4, centro, new Vect3(1.0f, 0.0f, 0.0f));
            caras.Add("c4", face);

            Dictionary<string, Vect3> lista5 = new Dictionary<string, Vect3>();
            lista5.Add("v1", new Vect3(1.0f, 1.0f, -1.0f));
            lista5.Add("v2", new Vect3(1.0f, -1.0f, -1.0f));
            lista5.Add("v3", new Vect3(-1.0f, -1.0f, -1.0f));
            lista5.Add("v4", new Vect3(-1.0f, 1.0f, -1.0f));
            face = new Cara(lista5, centro, new Vect3(0.0f, 1.0f, 0.0f));
            caras.Add("c5", face);

            Dictionary<string, Vect3> lista6 = new Dictionary<string, Vect3>();
            lista6.Add("v1", new Vect3(1.0f, 1.0f, 1.0f));
            lista6.Add("v2", new Vect3(1.0f, -1.0f, 1.0f));
            lista6.Add("v3", new Vect3(-1.0f, -1.0f, 1.0f));
            lista6.Add("v4", new Vect3(-1.0f, 1.0f, 1.0f));
            face = new Cara(lista6, centro, new Vect3(0.0f, 0.0f, 1.0f));
            caras.Add("c6", face);

            string nombre = "Cubo";
            Figura figura = new Figura(nombre, centro, caras);

            e.addFigura(nombre, figura);

            //Utils.guardarJson(figura, nombre);

            //---------------------------------------------------------------------------------------------------------------------

            Dictionary<string, Cara> faces = new Dictionary<string, Cara>();

            centro = new Vect3(2.0, 0.0, 0.0);
            lista1 = new Dictionary<string, Vect3>();
            lista1.Add("v1", new Vect3(-1.0f, -1.0f, -1.0f));
            lista1.Add("v2", new Vect3(1.0f, -1.0f, -1.0f));
            lista1.Add("v3", new Vect3(0.0f, 1.0f, 0.0f));
            face = new Cara(lista1);
            face.addColor(Color.Green);
            face.setCentro(centro);
            faces.Add("c1", face);

            lista2 = new Dictionary<string, Vect3>();
            lista2.Add("v1", new Vect3(-1.0f, -1.0f, -1.0f));
            lista2.Add("v2", new Vect3(-1.0f, -1.0f, 1.0f));
            lista2.Add("v3", new Vect3(0.0f, 1.0f, 0.0f));
            face = new Cara(lista2);
            face.addColor(Color.Yellow);
            face.setCentro(centro);
            faces.Add("c2", face);

            lista3 = new Dictionary<string, Vect3>();
            lista3.Add("v1", new Vect3(1.0f, -1.0f, -1.0f));
            lista3.Add("v2", new Vect3(1.0f, -1.0f, 1.0f));
            lista3.Add("v3", new Vect3(0.0f, 1.0f, 0.0f));
            face = new Cara(lista3);
            face.addColor(Color.HotPink);
            face.setCentro(centro);
            faces.Add("c3", face);

            lista4 = new Dictionary<string, Vect3>();
            lista4.Add("v1", new Vect3(-1.0f, -1.0f, 1.0f));
            lista4.Add("v2", new Vect3(1.0f, -1.0f, 1.0f));
            lista4.Add("v3", new Vect3(0.0f, 1.0f, 0.0f));
            face = new Cara(lista4);
            face.addColor(Color.Blue);
            face.setCentro(centro);
            faces.Add("c4", face);

            lista5 = new Dictionary<string, Vect3>();
            lista5.Add("v1", new Vect3(-1.0f, -1.0f, 1.0f));
            lista5.Add("v2", new Vect3(-1.0f, -1.0f, -1.0f));
            lista5.Add("v3", new Vect3(1.0f, -1.0f, -1.0f));
            lista5.Add("v4", new Vect3(1.0f, -1.0f, 1.0f));
            face = new Cara(lista5);
            face.addColor(Color.Gold);
            face.setCentro(centro);
            faces.Add("c5", face);

            nombre = "Piramide";
            figura = new Figura(nombre, centro, faces);

            e.addFigura(nombre, figura);


            Utils.guardarJson(e, "Escenario1");
        }

    }
}
