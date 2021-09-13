using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PizzaWars.API
{
    public class ApiHelper
    {
        public static HttpClient ApiClient { get; set; }

        public static void Init()
        {
            ApiClient = new HttpClient();
            ApiClient.BaseAddress = new Uri("https://foodish-api.herokuapp.com/api/images/pizza");
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
