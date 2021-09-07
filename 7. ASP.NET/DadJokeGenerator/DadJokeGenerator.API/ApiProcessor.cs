using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DadJokeGenerator.Data;

namespace DadJokeGenerator.API
{
    public class ApiProcessor
    {
        public static async Task<ApiModel> Load() 
        {
            var url = ApiHelper.ApiClient.BaseAddress.ToString();

            using(HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    ApiModel joke = await response.Content.ReadAsAsync<ApiModel>();
                    return joke;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

    }
}
