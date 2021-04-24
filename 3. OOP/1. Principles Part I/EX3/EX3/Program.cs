using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX3
{
    class Program
    {
        static void Main(string[] args)
        {
            Kittens k1 = new Kittens(10, "Lisa", false, false);
            Kittens k2 = new Kittens(5, "Sven", true, false);
            Kittens k3 = new Kittens(22, "Greger", false, false);
            Kittens k4 = new Kittens(7, "Sten", true, false);

            TomCats t1 = new TomCats(15, "Tom", true, true);
            TomCats t2 = new TomCats(10, "Inger", true, true);
            TomCats t3 = new TomCats(2, "Lena", true, false);
            TomCats t4 = new TomCats(23, "Migauel", true, true);

            Dog d1 = new Dog(17, "Best Boi", false);
            Dog d2 = new Dog(3, "Zoomie Boi", false);
            Dog d3 = new Dog(8, "Chunky Boi", true);
            Dog d4 = new Dog(9, "Woofer Boi", true);

            Frog f1 = new Frog(1, "Grodis", true, 200);
            Frog f2 = new Frog(5, "Grodan Boll", false, 20);
            Frog f3 = new Frog(67, "Slemmis", false, 55);
            Frog f4 = new Frog(54, "Hoppis", false, 352);

            Kittens[] kitten = new Kittens[] { k1, k2, k3, k4 };
            TomCats[] tomcat = new TomCats[] { t1, t2, t3, t4 };
            Dog[] dog = new Dog[] { d1, d2, d3, d4 };
            Frog[] frog = new Frog[] { f1, f2, f3, f4 };

            AverageAge(kitten, tomcat, dog, frog);

            Console.ReadLine();
        }

        static void AverageAge(Kittens[] kitten, TomCats[] tomcat, Dog[] dog, Frog[] frog)
        {
            int aKitten = 0;
            for (int i = 0; i < kitten.Length; i++)
            {
                aKitten += kitten[i].Age;
            }
            aKitten = aKitten / kitten.Length;

            int atomcat = 0;
            for (int i = 0; i < tomcat.Length; i++)
            {
                atomcat += tomcat[i].Age;
            }
            atomcat = atomcat / tomcat.Length;

            int adog = 0;
            for (int i = 0; i < dog.Length; i++)
            {
                adog += dog[i].Age;
            }
            adog = adog / dog.Length;

            int afrog = 0;
            for (int i = 0; i < frog.Length; i++)
            {
                afrog += frog[i].Age;
            }
            afrog = afrog / frog.Length;


            Console.WriteLine($"Kitten medelåler: {aKitten}\nTomcat medelåler: {atomcat}\nDog medelåler: {adog}\nFrog medelåler: {afrog}");
        }
    }
}
