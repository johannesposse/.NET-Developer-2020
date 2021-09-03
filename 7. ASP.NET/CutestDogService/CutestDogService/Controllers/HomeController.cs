using CutestDogService.Api;
using CutestDogService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;

namespace CutestDogService.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {

            var dogNames = Enum.GetNames(typeof(NamesEnum)).ToList();
            var dogBreeds = Enum.GetNames(typeof(BreedsEnum)).ToList();

            var newDog = new DogModel()
            {
                Name = dogNames[new Random().Next(0, dogNames.Count)],
                Age = new Random().Next(0, 21),
                Cuteness = new Random().Next(0, 11),
                Breed = dogBreeds[new Random().Next(0, dogBreeds.Count)]
            };

            ApiModel api = await ApiProcessor.LoadFact(newDog.Breed);
            ViewBag.Img = api.message;

            return View(newDog);
        }


        public IActionResult Congrats(string name)
        {


            ViewBag.Name = name;
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
