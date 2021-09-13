using PizzaWars.API;
using PizzaWars.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaWars.App
{
    public class PizzaManager
    {

        public PizzaManager()
        {
            ApiHelper.Init();
        }


        private async Task<PizzaModel> LoadImage()
        {
            var pizza = await ApiProcessor.Load();
            return pizza;
        }

        public List<PizzaModel> Init()
        {


            List<PizzaModel> pizzaz = new List<PizzaModel>()
            {
                new PizzaModel{Id = 1, Name="Hawaii", Toppings = new List<string> { "Ham","PineApple"}, HypeLevel = 10, Image = LoadImage().Result.Image },
                new PizzaModel{Id = 2, Name="Kebab", Toppings = new List<string> { "Kebabkött","Sås"}, HypeLevel = 9, Image = LoadImage().Result.Image },
                new PizzaModel{Id = 3, Name="Afrikana", Toppings = new List<string> { "Kykling","Annanas","Jordnötter", "Curry", "Banan"}, HypeLevel = 7, Image = LoadImage().Result.Image },
                new PizzaModel{Id = 4, Name="Vesuvio", Toppings = new List<string> { "Ost"}, HypeLevel = 1, Image = LoadImage().Result.Image },
            };

            return pizzaz;
        }
    }
}
