using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grafica_clase1
{
    class Utils
    {
        public Utils()
        {
            /**/
        }

        public static void guardarJson(Objeto figura, string nombre)
        {
            string jsonString = JsonConvert.SerializeObject(figura, Formatting.Indented,
                new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

            File.WriteAllText(nombre + ".json", jsonString);
            Console.WriteLine(File.ReadAllText(nombre + ".json"));
        }

        public static Escenario agregarDesdeJson(string nombre)
        {
            using (StreamReader file = File.OpenText(nombre))
            {
                JsonSerializer serializer = new JsonSerializer();
                Escenario figura = (Escenario)serializer.Deserialize(file, typeof(Escenario));
                return figura;
            }
        }
    }
}
