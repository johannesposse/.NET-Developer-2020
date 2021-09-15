using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoockieDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public string Theme { get; set; }
        public List<string> CookieList { get; set; } = new List<string>();

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            return Page();
        }

        public IActionResult OnPostTest(string key, string value)
        {
            CookieOptions options = new CookieOptions();

            options.Expires = DateTime.Now.AddDays(2);

            Response.Cookies.Append(key, value, options);

            foreach(var cookie in Request.Cookies)
            {
                CookieList.Add(cookie.Key + " " + cookie.Value);
            }

            return Page();

        }

        public void OnPostCreate()
        {
            string key = "Theme";
            string value = "Dark";

            CookieOptions options = new CookieOptions();

            options.Expires = DateTime.Now.AddDays(2);

            Response.Cookies.Append(key, value, options);
        }

        public void OnPostRead()
        {
            string key = "Theme";

            Theme = Request.Cookies[key];
        }

        public void OnPostDelete()
        {
            string key = "Theme";

            var options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(-1);

            Response.Cookies.Append(key, "", options);
        }
    }
}
