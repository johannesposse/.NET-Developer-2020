using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.ComponentModel;

namespace EX5
{
    class Program
    {
        static void Main(string[] args)
        {

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader rdr = null;

            int counter = 0;

            con.ConnectionString = "Data source=.\\sqlexpress; database=Northwind; Integrated security=true";

            using (con)
            {
                cmd.CommandText = "SELECT Picture FROM Categories;";
                cmd.Connection = con;
                con.Open();
                try
                {
                    rdr = cmd.ExecuteReader();

                    using (rdr)
                    {
                        while (rdr.Read())
                        {
                            counter++;
                            byte[] img = (byte[])rdr[0];
                            TypeConverter tc = TypeDescriptor.GetConverter(typeof(Bitmap));
                            Bitmap bitmap1 = (Bitmap)tc.ConvertFrom(img);
                            bitmap1.Save("category" + counter + ".jpg");

                            Console.WriteLine("Sparar bild nr " + counter);
                        }
                    }
                    Console.WriteLine("Alla bilde är sparade");
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
