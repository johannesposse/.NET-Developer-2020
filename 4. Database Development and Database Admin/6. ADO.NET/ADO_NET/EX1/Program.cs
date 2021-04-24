using System;
using System.Data.SqlClient;

namespace EX1
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection();

            con.ConnectionString = "Data source=(local)\\SqlExpress; database=Northwind; Integrated Security=true;";
            
            SqlCommand cmd = new SqlCommand();

            int numRows = 0;

            using (con)
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Categories";
                cmd.Connection = con;

                try
                {
                    con.Open();
                    numRows = (int)cmd.ExecuteScalar();
                }
                catch(Exception x)
                {
                    Console.WriteLine(x);
                }
            }

            Console.WriteLine(numRows);
        }
    }
}
