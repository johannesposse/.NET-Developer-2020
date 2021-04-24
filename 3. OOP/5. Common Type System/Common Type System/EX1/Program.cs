using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX1
{
    class Program
    {
        static void Main(string[] args)
        {
            Student a = new Student("Johannes", "Posse", 1234, "Almers Väg 2", "0725659465", "johannesposse@gmail.com", "SUT20", 0, 1, 1);
            Student b = new Student();
            b = (Student)a.Clone();
            Console.WriteLine(a);
            Console.WriteLine(b);
            b.FirstName = "Aillen";
            Console.WriteLine(a);
            Console.WriteLine(b);

            Console.WriteLine(a.CompareTo(b));
            Console.ReadLine();
        }
    }
}
