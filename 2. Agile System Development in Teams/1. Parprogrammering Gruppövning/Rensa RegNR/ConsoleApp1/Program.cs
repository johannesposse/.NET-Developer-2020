using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buss
{
    class Buss
    {
        public int[] passagerare = new int[25];
        public int antal_passagerare;
        public void Run()

        {
            Console.WriteLine("Välkommen ombord på bussen!");

            int menu;
            do
            {
                Console.WriteLine("Välj ett alternativ: ");
                Console.WriteLine("1. Lägg till en passagerare. ");
                Console.WriteLine("2. Kontrollera åldern på passagerarna. ");
                Console.WriteLine("3. Beräkna den sammanlagda åldern på passagerarna. ");
                Console.WriteLine("4. Beräkna medelåldern på passagerarna. ");
                Console.WriteLine("5. Identifiera den äldsta passageraren. ");
                Console.WriteLine("6. Identifiera alla passagerare mellan 20-30. ");
                Console.WriteLine("0. Avsluta programmet. ");
                menu = int.Parse(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                        Add_passenger();
                        break;

                    case 2:
                        Print_buss();
                        break;

                    case 3:
                        Calc_total_age();
                        break;

                    case 4:
                        Calc_average_age();
                        break;

                    case 5:
                        Max_age();
                        break;

                    case 6:
                        Find_age();
                        break;
                    case 0:
                        menu = 0;
                        break;

                }
            } while (menu != 0);
        }
        public void Add_passenger()
        {
            Console.WriteLine("Hur många passagerare vill du lägga till?");
            string str1 = Console.ReadLine();
            int size = Convert.ToInt32(str1);
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("Lägg till en passagerare genom att skriva hens ålder: ");
                string answer = Console.ReadLine();//the user give str an value
                int nya_passagerare = Convert.ToInt32(answer);//Converting to int
                passagerare[i] = nya_passagerare; //Adding the value to the array
            }
            // Console.WriteLine("\nAlla passagerare har nu klivit på:");
            //foreach (int age in passagerare)
            //   Console.WriteLine(age);
            //Lägg till passagerare. Här skriver man då in ålder men eventuell annan information.
            //Om bussen är full kan inte någon passagerare stiga på
        }

        public void Print_buss()
        {
            foreach (var antal_passagerare in passagerare)
            {
                if (antal_passagerare != 0)
                Console.WriteLine("Passagerarnas ålder är: " + antal_passagerare);
            }

        }
        public void Calc_total_age()
        {
            int sum = 0;
            for (int i = 0; i < passagerare.Length; i++)
            {
                sum += passagerare[i];
            }
            Console.WriteLine("Den sammanlagda åldern på passagerarna är " + sum + ".");

            //Beräkna den totala åldern. 
            //För att koden ska fungera att köra så måste denna metod justeras, alternativt att man temporärt sätter metoden med void
        }
        //Metoder för betyget C

        public void Calc_average_age()
        {
            int sum = 0;
            for (int i = 0; i < antal_passagerare; i++)
            {
                sum += passagerare[i];
            }
            int sum1 = sum / passagerare.Length;
            Console.WriteLine("Passagerarnas medelålder är " + sum1 + " år.");
            //Betyg C
            //Beräkna den genomsnittliga åldern. Kanske kan man tänka sig att denna metod ska returnera något annat värde än heltal?
            //För att koden ska fungera att köra så måste denna metod justeras, alternativt att man temporärt sätter metoden med void
        }
        public void Max_age()
        {
            int maxAge = 0;
            for (int i = 0; i < passagerare.Length; i++)
            {
                if (passagerare[i] > maxAge)
                {
                    maxAge = passagerare[i];
                }
                
            }
            Console.WriteLine("Den äldsta passageraren är " + maxAge + " år gammal.");
            //Betyg C
            //ta fram den passagerare med högst ålder. Detta ska ske med egen kod och är rätt klurigt.
            //För att koden ska fungera att köra så måste denna metod justeras, alternativt att man temporärt sätter metoden med void
        }

        public void Find_age()
        {
            //Visa alla positioner med passagerare med en viss ålder
            //Man kan också söka efter åldersgränser - exempelvis 55 till 67
            //Betyg C
            //Beskrivs i läroboken på sidan 147 och framåt (kodexempel på sidan 149)
        }
        class Program
        {
            public static void Main(string[] args)
            {
                var minbuss = new Buss();
                minbuss.Run();
                Console.Write("Press any key to continue...");
                Console.ReadKey(true);
            }
        }
    }
}