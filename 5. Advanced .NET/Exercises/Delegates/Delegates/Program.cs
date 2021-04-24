using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class Program
    {

        static ShoppingCartModel cart = new ShoppingCartModel();

        static void Main(string[] args)
        {
            PopulateCart();

            Console.WriteLine($"The total for the cart is {cart.GenerateTotal(SubTotalAlert):C2}");

            int x = 2;

            foreach(var i in cart.items)
            { 
                Console.WriteLine($"{i.ItemName} : {i.Price * x:C2}");
            }
            Console.ReadLine();


        }

        private static void SubTotalAlert(decimal subtotal)
        {
            Console.WriteLine(subtotal);
        }

        private static void PopulateCart()
        {
            cart.items.Add(new ProductModel { ItemName = "Ägg", Price = 10.2M });
            cart.items.Add(new ProductModel { ItemName = "Bröd", Price = 22.22M });
            cart.items.Add(new ProductModel { ItemName = "Mjölk", Price = 9.95M });
            cart.items.Add(new ProductModel { ItemName = "Kaffe", Price = 41.0M });
        }
    }
}
