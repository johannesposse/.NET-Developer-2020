using System;

namespace Hiearki_Övning
{
    class Program
    {
        static void Main(string[] args)
        {
            SchoolTeacher one = new SchoolTeacher("1@mail.com", "Eva", "History", "BEst School");
            UniversityTeacher two = new UniversityTeacher("2@mail.com", "Bert", "Art", "The Highscool");
            SeniorEmployee three = new SeniorEmployee("3@mail.com", "Lena", 55555, "Expert", 3);

            Console.WriteLine(one.ToString()+ "\n");
            Console.WriteLine(two.ToString() + "\n");
            Console.WriteLine(three.ToString() + "\n");
            Console.WriteLine();

            //Person test = new Person("1@mail.com", "namn");
            //Console.WriteLine(test.name);
            //Console.WriteLine();
            //Console.WriteLine(test.EMail);

        }
    }
}
