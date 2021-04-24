using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EX2_
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data source=.\\SqlExpress; database=Northwind; Integrated Security=true;";
            SqlCommand cmd = new SqlCommand();
            SqlDataReader rdr = null;
            using (con)
            {
                cmd.CommandText = "SELECT CategoryName, Description FROM Categories";
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
                                Console.WriteLine(rdr[0] + " " + rdr[1]);
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
