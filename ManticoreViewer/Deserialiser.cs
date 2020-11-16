using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace ManticoreViewer
{
    public class Deserialiser
    {
        private StreamReader reader;

        public static List<object> DeserialiseJSON(string filePath)
        {
            using (StreamReader reader = File.OpenText(filePath))
            {
                string json = reader.ReadToEnd();
                List<object> objects = JsonConvert.DeserializeObject<List<object>>(json);
                return objects;
            }
        }

        internal static List<object> DeserialiseJSON(object databaseFilePath)
        {
            throw new NotImplementedException();
        }
    }
}
