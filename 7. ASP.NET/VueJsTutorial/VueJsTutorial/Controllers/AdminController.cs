using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueJsTutorial.Models;

namespace VueJsTutorial.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public List<Pizza> Pizzas()
        {
            List<Pizza> pizzaz = new List<Pizza>()
            {
                new Pizza {Name = "Hawaii", Smak= 10},
                new Pizza {Name = "Kebab", Smak= 9},
                new Pizza {Name = "Vesuvio", Smak= 1},
                new Pizza {Name = "Afrikana", Smak= 7}
            };

            
            // Hämta projekt från t.ex. en databas och skicka tillbaka till Axios
            return pizzaz;
        }

    }
}
