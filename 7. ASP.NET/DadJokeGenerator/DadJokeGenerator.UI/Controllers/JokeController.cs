using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DadJokeGenerator.App;

namespace DadJokeGenerator.UI.Controllers
{
    public class JokeController : Controller
    {
        public static string Joke { get; set; }
        JokeManager jokeManager = new JokeManager();

        public async Task<IActionResult> Index()
        {
            await GetNewJoke();
            return View();
        }

        public IActionResult Formatted(string type)
        {
            
            if(type == "caps")
                Joke = jokeManager.UpperCase(Joke);
            else if(type == "!!!")
                Joke = jokeManager.ExlemationMark(Joke);
            else if(type == "???")
                Joke = jokeManager.QuestionMark(Joke);
            else if(type == "röv")
                Joke = jokeManager.Rovarspraket(Joke);
            
            ViewBag.Joke = Joke;
            return View();
        }

        public async Task GetNewJoke()
        {
            Joke = await jokeManager.GetNewJoke();
            ViewBag.Joke = Joke;
        }
    }
}
