using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NeverBored.Api;
using NeverBored.Model;
using Newtonsoft.Json;

namespace NeverBored.Pages.Bored
{
    public class IndexModel : PageModel
    {
        public static ApiModel Bored { get; set; }
        [BindProperty]
        public bool isFavorite { get; set; }
        public static List<ApiModel> Boreds { get; set; } = new List<ApiModel>();
        public async Task OnGet()
        {
            Bored = await ApiProcessor.Load();

            string _boreds = HttpContext.Session.GetString("boreds");
            if (!String.IsNullOrEmpty(_boreds))
            {
                Boreds = JsonConvert.DeserializeObject<List<ApiModel>>(_boreds);
            }
        }

        public IActionResult OnPost()
        {
            string _boreds = HttpContext.Session.GetString("boreds");

            if (!String.IsNullOrEmpty(_boreds))
            {
                Boreds = JsonConvert.DeserializeObject<List<ApiModel>>(_boreds);
            }
            Boreds.Add(Bored);

            _boreds = JsonConvert.SerializeObject(Boreds);
            HttpContext.Session.SetString("boreds", _boreds);

            return RedirectToPage("/Bored/Index");

        }
    }
}
