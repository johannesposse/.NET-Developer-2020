using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ObjectCookieDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjectCookieDemo.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public SurikatModel Surikat { get; set; }
        public List<SurikatModel> CookieSurikater { get; set; } = new List<SurikatModel>();

        public void OnGet()
        {
            string stringSurikater = HttpContext.Session.GetString("surikater");

            if (!string.IsNullOrEmpty(stringSurikater))
            {
                CookieSurikater = JsonConvert.DeserializeObject<List<SurikatModel>>(stringSurikater);
            }
        }

        public IActionResult OnPost()
        {
            List<SurikatModel> surikater = new List<SurikatModel>();
            string stringSurikater = HttpContext.Session.GetString("surikater");

            if (!string.IsNullOrEmpty(stringSurikater))
            {
                surikater = JsonConvert.DeserializeObject<List<SurikatModel>>(stringSurikater);
            }
            surikater.Add(Surikat);


            stringSurikater = JsonConvert.SerializeObject(surikater);
            HttpContext.Session.SetString("surikater", stringSurikater);
            return RedirectToPage("/Index");
        }
    }
}
