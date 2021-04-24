using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EX3
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data source=.\\SqlExpress; database=Northwind; Integrated Security=true;";
            SqlCommand cmd = new SqlCommand();
            SqlDataReader rdr = null;
            Console.WriteLine("[Product Name]".PadRight(51,' ') + "[Category Name]\n");
            using (con)
            {
                cmd.CommandText = "SELECT p.ProductName, c.CategoryName FROM Products p JOIN Categories c ON p.CategoryID = c.CategoryID ORDER BY c.CategoryName";
                cmd.Connection = con;

                try
                {
                    con.Open();
                    rdr = cmd.ExecuteReader();

                    using (rdr)
                    {
                        try
                        {
                            while (rdr.Read())
                            {
                                Console.WriteLine((rdr[0]).ToString().PadRight(50,' ') + " " + rdr[1]);
                            }
                        }
                        catch (Exception x)
                        {
                            Console.WriteLine(x);
                        }
                    }
                }
                catch (Exception x)
                {
                    Console.WriteLine(x);
                }
            }

            Console.ReadLine();
        }
    }
}
