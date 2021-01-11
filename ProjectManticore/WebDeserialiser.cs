using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace ProjectManticore
{
    public class WebDeserialiser : IFileDeserialiser
    {
        List<object> IFileDeserialiser.Deserialise(string filePath)
        {
            return JsonConvert.DeserializeObject<List<object>>(StringFromWeb(filePath));
        }

        // Make asynchronous
        public static string StringFromWeb(string WebPath)
        {
            return WebStringScraperAsync(WebPath).Result;
        }

        private static async Task<string> WebStringScraperAsync(string WebPath)
        {
            HttpClient client = new HttpClient();

            try
            {
                return await client.GetStringAsync(WebPath);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
