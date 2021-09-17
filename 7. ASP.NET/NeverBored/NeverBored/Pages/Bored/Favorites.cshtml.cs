using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NeverBored.Model;
using Newtonsoft.Json;

namespace NeverBored.Pages.Bored
{
    public class FavoritesModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            return Page();
        }

        public IActionResult OnPostDelete(string key)
        {

            for(int i = 0; i < IndexModel.Boreds.Count(); i++)
            {
                if(IndexModel.Boreds[i].Key == key)
                {
                    IndexModel.Boreds.RemoveAt(i);
                }
            }

            string _boreds = JsonConvert.SerializeObject(IndexModel.Boreds);
            HttpContext.Session.SetString("boreds", _boreds);

            return RedirectToPage("/Bored/Favorites");
        }
    }
}
