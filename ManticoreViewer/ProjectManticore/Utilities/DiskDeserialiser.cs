using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ManticoreViewer
{
    public class DiskDeserialiser : IFileDeserialiser
    {
        List<object> IFileDeserialiser.Deserialise(string filePath)
        {
            return JsonConvert.DeserializeObject<List<object>>(StringFromDisk(filePath));
        }

        public static string StringFromDisk(string filePath)
        {
            try
            {
                using (StreamReader reader = File.OpenText(filePath))
                {
                    return reader.ReadToEnd();
                    //List<object> objects = JsonConvert.DeserializeObject<List<object>>(json);
                    //return objects;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("unexpected error reading file");
            }

            return null;
        }
    }
}
