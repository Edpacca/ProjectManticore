using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ProjectManticore
{
    public class Deserialiser
    {
        public static List<object> DeserialiseJSONFromDisk(string filePath)
        {
            try
            {
                using (StreamReader reader = File.OpenText(filePath))
                {
                    string json = reader.ReadToEnd();
                    List<object> objects = JsonConvert.DeserializeObject<List<object>>(json);
                    return objects;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("unexpected error reading file");
            }

            return null;
        }

        public static void DeserialiseJSONFromWeb(string WebPath)
        {
            var content = JSONFromWebAsync(WebPath);
            Console.WriteLine(content.Result);
            //List<object> objects = JsonConvert.DeserializeObject<List<object>>(content.Result);

            //return objects;
        }

        public static async Task<string> JSONFromWebAsync(string WebPath)
        {
            HttpClient client = new HttpClient();

            try
            {
                var dataBase = await client.GetStringAsync(WebPath);

                return dataBase;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
