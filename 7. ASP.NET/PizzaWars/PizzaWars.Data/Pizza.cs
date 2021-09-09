using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaWars.Data
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Toppings { get; set; }
        public int HypeLevel { get; set; }
        public string Image { get; set; }
    }
}
