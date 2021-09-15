using NeverBored.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NeverBored.Api
{
    public class ApiProcessor
    {
        public static async Task<ApiModel> Load()
        {
            var url = ApiHelper.ApiClient.BaseAddress.ToString();

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    ApiModel result = await response.Content.ReadAsAsync<ApiModel>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

    }
}
