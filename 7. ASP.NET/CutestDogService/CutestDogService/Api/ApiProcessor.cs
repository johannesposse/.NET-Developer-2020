using CutestDogService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CutestDogService.Api
{
    public class ApiProcessor
    {
        public static async Task<ApiModel> LoadFact(string breed)
        {
            
            string url = ApiHelper.ApiClient.BaseAddress.ToString();
            url = url.Replace("?", breed.ToLower());

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    ApiModel fact = await response.Content.ReadAsAsync<ApiModel>();
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
