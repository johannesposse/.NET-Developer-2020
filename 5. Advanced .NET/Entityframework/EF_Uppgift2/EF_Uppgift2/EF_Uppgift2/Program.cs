using EF_Uppgift2.Models;
using System;
using System.Linq;

namespace EF_Uppgift2
{
    class Program
    {
        static BikeStoresContext bs = new BikeStoresContext();
        static void Main(string[] args)
        {

            #region MyRegion
            // DEL 1
            //var firstNameD = bs.Customers.Where(x => x.FirstName.StartsWith("D"));

            //foreach (var c in firstNameD)
            //{
            //    Console.WriteLine(c.FirstName);
            //} 
            #endregion



            #region MyRegion
            // DEL 2

            //var email = bs.Customers.Select(x => x.Email).ToArray();
            //var unique = email.Select(x => x.Split('@').Last()).Distinct().ToList();

            ////foreach (var e in email)
            ////{
            ////    Console.WriteLine(e);
            ////}

            //foreach (var u in unique)
            //{
            //    Console.WriteLine(u.ToString());
            //} 
            #endregion



            #region MyRegion
            // DEL 3


            //SELECT c.customer_id, c.first_name, count(o.order_id) AS 'C'
            //FROM sales.customers c
            //JOIN sales.orders o ON
            //c.customer_id = o.customer_id
            //GROUP BY c.customer_id, c.first_name
            //ORDER BY c DESC

            //var order = bs.Customers.Join(bs.Orders, customer => customer.CustomerId, order => order.CustomerId, (customer, order) => new { customer, order });
            //var qu = order.AsEnumerable().GroupBy(x => x.order.CustomerId);


            //foreach (var q in qu)
            //{
            //    Console.WriteLine(q.Key + q.Count());
            //}


            //var order = bs.Orders.AsEnumerable().GroupBy(x => x.CustomerId).Join(bs.Customers, x => x.);

            //foreach (var c in order.OrderBy(x => x.Key))
            //{
            //    Console.WriteLine("{0} {1}",c.Key,c.Count());
            //}

            //var result = from c in bs.Customers
            //             join o in bs.Orders
            //             on c.CustomerId equals o.CustomerId
            //             group c.CustomerId by o.CustomerId into o
            //             select new
            //             {
            //                 ID = o.Key,
            //                 Name = o.Key,
            //                 Order = o.Key
            //             };

            //foreach (var r in result)
            //{
            //    Console.WriteLine(r.ID +" "+ r.Name +" "+ r.Order);
            //}

            //var result = from p in bs.Customers
            //             join a in bs.Orders
            //             on p.CustomerId equals a.CustomerId
            //             group p.CustomerId by a.CustomerId into g
            //             select new
            //             {
            //                 Id = a.Customer.CustomerId,
            //                 Name = a.Customer.FirstName + " " + a.Customer.LastName,
            //                 SumOrder = a.OrderId
            //             };

            //var sum = result.GroupBy(x => x.Id);

            ////var customer = bs.Customers.Where(x => x.Orders.Where())

            //foreach (var r in result)
            //{
            //    Console.WriteLine($"{r.Id} {r.Name} {r.SumOrder}");
            //} 
            #endregion


            // DEL 4




        }
    }
}
