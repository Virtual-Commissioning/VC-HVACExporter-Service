using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Helpers
{
    public class HttpClientHelper
    {
        private static HttpClient _httpClient = new HttpClient();

        public static bool POSTData(string json, string url)
        {
            using (var content = new StringContent(json, System.Text.Encoding.UTF8))
            {

                HttpResponseMessage result = _httpClient.PutAsync(url, content).Result;

                if (result.StatusCode == System.Net.HttpStatusCode.Created)
                    return true;
                string returnValue = result.Content.ReadAsStringAsync().Result;
                throw new Exception($"Failed to POST data: ({result.StatusCode}): {returnValue}");
            }
        }
    }

    
}
