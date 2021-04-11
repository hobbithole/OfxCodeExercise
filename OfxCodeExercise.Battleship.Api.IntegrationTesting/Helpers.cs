using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OfxCodeExercise.Battleship.Api.IntegrationTesting
{
    public class Helpers
    {
        public static StringContent GetHttpRequestContent(object obj)
        {
            return new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        }

        public static async Task<T> GetHttpResponseContent<T>(HttpResponseMessage response)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseContent);
        }
    }
}
