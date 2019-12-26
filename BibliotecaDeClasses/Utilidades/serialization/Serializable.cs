using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDeClasses.Utilidades.serialization
{
    public static class Serializable
    {
        public static string Serialize(object objeto)
        {
            byte[] byteInstance;
            using (var memory = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(memory, objeto);
                byteInstance = memory.ToArray();
            }

            return Convert.ToBase64String(byteInstance);
        }

        public static object Descerialize(string byteInstance64)
        {
            var binery = new BinaryFormatter();
            object objeto = null;
            var buffer = Convert.FromBase64String(byteInstance64);
            using (var memory = new MemoryStream(buffer))
            {
                objeto = binery.Deserialize(memory);
            }

            return objeto;
        }
    }
}
