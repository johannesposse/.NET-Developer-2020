using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EX4
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data source=.\\SqlExpress; database=Northwind; Integrated Security=true;";
            SqlCommand cmd = new SqlCommand();

            int numRows = 0;
            using (con)
            {
                cmd.CommandText = "INSERT INTO Products (ProductName, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued) " +
                    "VALUES(@pName, @cID, @qPUnit, @uPrice, @uInStock, @uInOrder,@reOrderLevel,@discontinued)";
                cmd.Connection = con;

                cmd.Parameters.AddWithValue("@pName","Snus");
                cmd.Parameters.AddWithValue("@cID", 3);
                cmd.Parameters.AddWithValue("@qPUnit", 10);
                cmd.Parameters.AddWithValue("@uPrice", 300);
                cmd.Parameters.AddWithValue("@uInStock", 10);
                cmd.Parameters.AddWithValue("@uInOrder", 0);
                cmd.Parameters.AddWithValue("@reOrderLevel", 3);
                cmd.Parameters.AddWithValue("@discontinued", 0);

                try
                {
                    con.Open();
                    numRows = cmd.ExecuteNonQuery();                 
                }
                catch (Exception x)
                {
                    Console.WriteLine(x);
                }
            }

            Console.WriteLine("Antal rader: " +  numRows);


            Console.ReadLine();


        }
    }
}
