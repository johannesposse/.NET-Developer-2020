using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CutestDogService.Api
{
    public class ApiHelper
    {
        public static HttpClient ApiClient { get; set; }
        public static void InitilizeClient()
        {
            ApiClient = new HttpClient();
            ApiClient.BaseAddress = new Uri("https://dog.ceo/api/breed/?/images/random");

            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
