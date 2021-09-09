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

        public List<Pizza> Init()
        {
            List<Pizza> pizzaz = new List<Pizza>()
            {
                new Pizza{Id = 1, Name="Hawaii", Toppings = new List<string> { "Ham","PineApple"}, HypeLevel = 10 },
                new Pizza{Id = 2, Name="Kebab", Toppings = new List<string> { "Kebabkött","Sås"}, HypeLevel = 9 },
                new Pizza{Id = 3, Name="Afrikana", Toppings = new List<string> { "Kykling","Annanas","Jordnötter", "Curry", "Banan"}, HypeLevel = 7 },
                new Pizza{Id = 4, Name="Vesuvio", Toppings = new List<string> { "Ost"}, HypeLevel = 1 },
            };

            return pizzaz;
        }
    }
}
