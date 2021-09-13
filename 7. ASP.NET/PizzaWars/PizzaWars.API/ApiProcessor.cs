using PizzaWars.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PizzaWars.API
{
    public class ApiProcessor
    {
        public static async Task<PizzaModel> Load()
        {
            var url = ApiHelper.ApiClient.BaseAddress.ToString();

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    PizzaModel pizza = await response.Content.ReadAsAsync<PizzaModel>();
                    return pizza;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

    }
}

