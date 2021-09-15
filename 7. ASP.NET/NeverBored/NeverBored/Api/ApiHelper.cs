using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace NeverBored.Api
{
    public class ApiHelper
    {
        public static HttpClient ApiClient { get; set; }

        public static void Init()
        {
            ApiClient = new HttpClient();
            ApiClient.BaseAddress = new Uri("http://www.boredapi.com/api/activity/");
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
