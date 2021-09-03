using ChuckNorrisFactGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ChuckNorrisFactGenerator.Api
{
    public class FactProcessor
    {
        public static async Task<FactModel> LoadFact()
        {
            string url = ApiHelper.ApiClient.BaseAddress.ToString();

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    FactModel fact = await response.Content.ReadAsAsync<FactModel>();
                    return fact;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }

            }


        }
    }
}
