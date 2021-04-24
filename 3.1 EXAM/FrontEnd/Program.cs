using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using System.Globalization;
using System.Runtime.Serialization.Formatters.Binary;


using BackEnd;

namespace FrontEnd
{
    class Program
    {
        //kod för att göra consolens storkek lika stor som skärmen
        #region MaxConsole
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        private static IntPtr ThisConsole = GetConsoleWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int HIDE = 0;
        private const int MAXIMIZE = 3;
        private const int MINIMIZE = 6;
        private const int RESTORE = 9;
        #endregion 
        static WareHouse SantasWorkShop = new WareHouse(); //skapar varuhuset
        static void Main(string[] args)
        {
            Starta(); //Metod som startar igång programmet
            Console.Read();

            Console.WriteLine("");

        }
        static void Starta()
        {
            try //sätter consollens storlek så att den blir lika stor som skärmen
            {
                Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
                ShowWindow(ThisConsole, MAXIMIZE);
            }
            catch //om det inte fick fångas det här
            {
                Console.WriteLine("Det blev lite fel...");
            }
            ReadData(); //metod för att läsa in data från fil
            Menu(); //metod för att visa menyn

            
        }
        static void Title()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\n\n\n\n\n\n\n███████  █████  ███    ██ ████████  █████  ███████     ██     ██  ██████  ██████  ██   ██ ███████ ██   ██  ██████  ██████  ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("██      ██   ██ ████   ██    ██    ██   ██ ██          ██     ██ ██    ██ ██   ██ ██  ██  ██      ██   ██ ██    ██ ██   ██");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("███████ ███████ ██ ██  ██    ██    ███████ ███████     ██  █  ██ ██    ██ ██████  █████   ███████ ███████ ██    ██ ██████ ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("     ██ ██   ██ ██  ██ ██    ██    ██   ██      ██     ██ ███ ██ ██    ██ ██   ██ ██  ██       ██ ██   ██ ██    ██ ██     ");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("███████ ██   ██ ██   ████    ██    ██   ██ ███████      ███ ███   ██████  ██   ██ ██   ██ ███████ ██   ██  ██████  ██     ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Probably the best workshop, in the world");
            Console.ResetColor();
        }//Metod för att skriva ut en ASCII titel på menyn


        //-----Menyer-----
        static void Menu()
        {
            string sWeight = SantasWorkShop.Weight(); //får information om vikten på warehouse
            Console.SetCursorPosition(32, 14); //skriver ut på bestämd plats
            Console.WriteLine("[" + sWeight + "]"); //skriver ut information om vikten på warehouse
            string prompt = "\n\n   Welcome To Santa's WorkShop\n "; //menyalternativ
            string[] options = {
                "Add new Box",
                "Auto Add new Box",
                "Find Box [ID]",
                "Retreive Box [ID]",
                "Move Box[ID]",
                "Print Santa's Workshop",
                "Find by Index [Clone]",
                "Exit Program"};
            Menu mainMenu = new Menu(prompt, options);
            int selextedIndex = mainMenu.Run();
            try //försöker välja meny
            {
                MenuChoise(selextedIndex);
            }
            catch (ArgumentOutOfRangeException fe) //fångar fel
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n"+fe.Message); //skriver ut felmeddelande
                Console.ResetColor();
                Console.WriteLine("You made all the elves on the north pole cry...");
                Console.ReadLine();
                Console.Clear();
                Menu(); //Kallar på meny
            }
            catch (ArgumentException x) //fångar fel
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n"+x.Message); //skriver ut felmeddelande
                Console.ResetColor();
                Console.WriteLine("Mistakes were made, you made Santa cry...");
                Console.ReadLine();
                Console.Clear();
                Menu(); //Kallar på meny
            }

        } //Metod för att visa menyn
        static void MenuChoise(int choise)
        {
            switch (choise)
            {
                case 0:
                    ChooseBox();
                    break;
                case 1:
                    ChooseAutoBox();
                    break;
                case 2:
                    FindBox();
                    break;
                case 3:
                    RetreiveBox();
                    break;
                case 4:
                    MoveBox();
                    break;
                case 5:
                    Print();
                    break;
                case 6:
                    FindIndex();
                    break;
                case 7:
                    Exit();
                    break;

            }
        } //metod som tar emot ett menyval och går till motsvarande metod
        static void ChooseBox()
        {
            Console.SetCursorPosition(0, 30); //skriver ut på vald plats

            //skickar in menyval till menu classen
            string bPrompt = "\n\n   Select boxtype: ";
            string[] bOptions = { "CubeBox", "CubeoidBox", "SphereBox", "BlobBox" };
            Menu selectBox = new Menu(bPrompt, bOptions);
            Console.Clear();
            int selectedBox = selectBox.Run();

            if (selectedBox == 0) //kallar på den metoden som blev vald
            {
                AddNewCubeBox();
            }
            if (selectedBox == 1)
            {
                AddNewCubeoideBox();
            }
            if (selectedBox == 2)
            {
                AddNewSphereBox();
            }
            if (selectedBox == 3)
            {
                AddNewBlobBox();
            }
        } //Metod för att välja vilen typ av box som manuellt läggs till på plats
        static void ChooseAutoBox()
        {
            Console.SetCursorPosition(0, 30); //skriver ut på vald plats
            
            //skickar in menyval till menu classen
            string bPrompt = "\n\n   Select boxtype: ";
            string[] bOptions = { "CubeBox", "CubeoidBox", "SphereBox", "BlobBox" };
            Menu selectBox = new Menu(bPrompt, bOptions);
            Console.Clear();
            int selectedBox = selectBox.Run();

            if (selectedBox == 0) //kallar på den metoden som blev vald
            {
                AutoAddNewCubeBox();
            }
            if (selectedBox == 1)
            {
                AutoAddNewCubeoidBox();
            }
            if (selectedBox == 2)
            {
                AutoAddNewSpeherBox();
            }
            if (selectedBox == 3)
            {
                AutoAddNewBlobBox();
            }
        } //Metod för att välja vilken typ av box som automatiskt ska läggas till på plats



        //-----Lägg till box manuellt-----
        static void AddNewCubeBox()
        {
            bool valid = false;

            Console.WriteLine("\n\nAdd new CubeBox");
            Console.CursorVisible = true;

            Console.Write("\nEnter ID: "); //ber användaren att skriva in ett id
            int iD;
            valid = int.TryParse(Console.ReadLine(), out iD); //försöker göra om invärdet till en int
            if (valid == false)
                throw new ArgumentException("Please enter only digits"); //felmeddelande om det inte bara var siffror
            if (iD < 1)
                throw new ArgumentException("Please a number above 0"); //felmeddelande om talet var minde än 1


            Console.Write("\nEnter Weight in kG: "); //ber användaren att skriva in ett vikt i kg
            uint weight;
            valid = uint.TryParse(Console.ReadLine(), out weight); //försöker göra om invärdet till en uint
            if (valid == false)
                throw new ArgumentException("Please enter only digits"); //felmeddelande om det inte bara var siffror
            if (weight < 1)
                throw new ArgumentException("Please a number above 0"); //felmeddelande om talet var minde än 1


            Console.Write("\nEnter Size in Cm: "); //ber användaren att skriva in storlek i cm
            decimal side;
            valid = decimal.TryParse(Console.ReadLine(), out side); //försöker göra om invärdet till en decimal
            if (valid == false)
                throw new ArgumentException("Please enter only digits"); //felmeddelande om det inte bara var siffror
            if (side < 1 )
                throw new ArgumentException("Please a number above 0"); //felmeddelande om talet var minde än 1
            side = Math.Round(side, 0); //rundar av talet till 0 decimaler



            Console.Write("\nEnter Insurace Value: "); //ber användaren att skriva in Insurance Value
            int insurance;
            valid = int.TryParse(Console.ReadLine(), out insurance); //försöker göra om invärdet till en int
            if (valid == false)
                throw new ArgumentException("Please enter only digits"); //felmeddelande om det inte bara var siffror
            if (insurance < 1)
                throw new ArgumentException("Please a number above 0"); //felmeddelande om talet var minde än 1


            Console.Write("\nEnter Floor (1-3): ");  //ber användaren att skriva in vilken våning
            int floor;
            valid = int.TryParse(Console.ReadLine(), out floor); //försöker göra om invärdet till en int
            if (valid == false)
                throw new ArgumentException("Please enter only digits"); //felmeddelande om det inte bara var siffror
            if (floor < 1 ^ floor > 3)
                throw new ArgumentException("Please a number above 0"); //felmeddelande om talet var minde än 1
            floor += -1; //tar bort 1 för att komma till rätt plats i arrayen


            Console.Write("\nEnter Shelf (1-100): "); //ber användaren att skriva in vilken hylla
            int shelf;
            valid = int.TryParse(Console.ReadLine(), out shelf); //försöker göra om invärdet till en int
            if (valid == false)
                throw new ArgumentException("Please enter only digits"); //felmeddelande om det inte bara var siffror
            if (shelf < 1 ^ shelf > 100)
                throw new ArgumentException("Please a number above 0"); //felmeddelande om talet var minde än 1
            shelf += -1; //tar bort 1 för att komma till rätt plats i arrayen


            Console.Clear(); //rensar konsollen
            string sTotalWeight = SantasWorkShop.Weight(); //får information om warehouse vikt
            Console.SetCursorPosition(32, 14); //skriver ut på bestämd plats
            Console.WriteLine("[" + sTotalWeight + "]"); //skriver ut warehouses vikt
            string prompt = "\n\n   Is it fragile?: "; //menyalternativ för att välja om lådan är fragile
            string[] options = { "Yes", "No" };
            bool isFragile = false;
            Menu fragile = new Menu(prompt, options);
            int selextedIndex = fragile.Run();
            if (selextedIndex == 0) //returvärdet från menyalternativet bestämmer om lådan är fragile eller inte
                isFragile = true;
            if (selextedIndex == 1)
                isFragile = false;

            string result;
            SantasWorkShop.AddNewCubeBox(iD, weight, isFragile, insurance, side, floor, shelf, out result); //försöker lägga till lådan
            Console.WriteLine(result); //skriver ut resultatet
            Console.WriteLine("Press any key to continue...");
            SaveData(); //sparar data till fil
            Console.ReadLine();
            Console.Clear();
            Menu(); //kallar på menyn
        } //Metod för att läga till Cubebox på vald plats
        static void AddNewCubeoideBox()
        {
            bool valid = false;
            Console.WriteLine("\n\nAdd new CubeoidBox");
            Console.CursorVisible = true;

            Console.Write("\nEnter ID: "); //ber användaren att skriva in ett id
            int iD;
            valid = int.TryParse(Console.ReadLine(), out iD); //försöker göra om invärdet till en int
            if (valid == false)
                throw new ArgumentException("Please enter only digits"); //felmeddelande om det inte bara var siffror
            if (iD < 1)
                throw new ArgumentException("Please a number above 0"); //felmeddelande om talet var minde än 1

              
            Console.Write("\nEnter Weight in kG: "); //ber användaren att skriva in ett vikt i kg
            uint weight;
            valid = uint.TryParse(Console.ReadLine(), out weight); //försöker göra om invärdet till en uint
            if (valid == false)
                throw new ArgumentException("Please enter only digits"); //felmeddelande om det inte bara var siffror
            if (weight < 1)
                throw new ArgumentException("Please a number above 0"); //felmeddelande om talet var minde än 1


            Console.Write("\nEnter Size for Width: "); //ber användaren att skriva in bredd i cm
            decimal xSide;
            valid = decimal.TryParse(Console.ReadLine(), out xSide); //försöker göra om invärdet till en decimal
            if (valid == false)
                throw new ArgumentException("Please enter only digits"); //felmeddelande om det inte bara var siffror
            if (xSide < 1)
                throw new ArgumentException("Please a number above 0"); //felmeddelande om talet var minde än 1
            xSide = Math.Round(xSide, 0); //rundar av talet till 0 decimaler


            Console.Write("\nEnter Size for Hegiht: "); //ber användaren att skriva in höjd i cm
            decimal ySide;
            valid = decimal.TryParse(Console.ReadLine(), out ySide); //försöker göra om invärdet till en decimal
            if (valid == false)
                throw new ArgumentException("Please enter only digits"); //felmeddelande om det inte bara var siffror
            if (ySide < 1)
                throw new ArgumentException("Please a number above 0"); //felmeddelande om talet var minde än 1
            ySide = Math.Round(ySide, 0); //rundar av talet till 0 decimaler


            Console.Write("\nEnter Size for Depth: "); //ber användaren att skriva in djup i cm
            decimal zSide;
            valid = decimal.TryParse(Console.ReadLine(), out zSide); //försöker göra om invärdet till en decimal
            if (valid == false)
                throw new ArgumentException("Please enter only digits"); //felmeddelande om det inte bara var siffror
            if (zSide < 1)
                throw new ArgumentException("Please a number above 0"); //felmeddelande om talet var minde än 1
            zSide = Math.Round(zSide, 0); //rundar av talet till 0 decimaler


            Console.Write("\nEnter Insurace Value: "); //ber användaren att skriva in Insurance Value
            int insurance;
            valid = int.TryParse(Console.ReadLine(), out insurance); //försöker göra om invärdet till en int
            if (valid == false)
                throw new ArgumentException("Please enter only digits"); //felmeddelande om det inte bara var siffror
            if (iD < 1)
                throw new ArgumentException("Please a number above 0"); //felmeddelande om talet var minde än 1


            Console.Write("\nEnter Floor (1-3): "); //ber användaren att skriva in vilken våning
            int floor;
            valid = int.TryParse(Console.ReadLine(), out floor); //försöker göra om invärdet till en int
            if (valid == false)
                throw new ArgumentException("Please enter only digits"); //felmeddelande om det inte bara var siffror
            if (floor < 1 ^ floor > 3)
                throw new ArgumentException("Please a number above 0"); //felmeddelande om talet var minde än 1
            floor += -1; //tar bort 1 för att komma till rätt plats i arrayen


            Console.Write("\nEnter Shelf (1-100): "); //ber användaren att skriva in vilken hylla
            int shelf;
            valid = int.TryParse(Console.ReadLine(), out shelf); //försöker göra om invärdet till en int
            if (valid == false)
                throw new ArgumentException("Please enter only digits"); //felmeddelande om det inte bara var siffror
            if (shelf < 1 ^ shelf > 100)
                throw new ArgumentException("Please a number above 0"); //felmeddelande om talet var minde än 1
            shelf += -1; //tar bort 1 för att komma till rätt plats i arrayen


            Console.Clear(); //rensar konsollen
            string sTotalWeight = SantasWorkShop.Weight(); //får information om warehouse vikt
            Console.SetCursorPosition(32, 14); //skriver ut på bestämd plats
            Console.WriteLine("[" + sTotalWeight + "]"); //skriver ut warehouses vikt
            string prompt = "\n\n   Is it fragile?: "; //menyalternativ för att välja om lådan är fragile
            string[] options = { "Yes", "No" };
            bool isFragile = false;
            Menu fragile = new Menu(prompt, options);
            int selextedIndex = fragile.Run();
            if (selextedIndex == 0) //returvärdet från menyalternativet bestämmer om lådan är fragile eller inte
                isFragile = true;
            if (selextedIndex == 1)
                isFragile = false;

            string result;
            SantasWorkShop.AddNewCubeoidBox(iD, weight, isFragile, insurance, xSide, ySide, zSide, floor, shelf, out result); //försöker lägga till lådan
            Console.WriteLine(result); //skriver ut resultatet

            Console.WriteLine("Press any key to continue...");
            SaveData(); //sparar data till fil
            Console.ReadLine();
            Console.Clear();
            Menu(); //kallar på menyn
        } //Metod för att läga till Cubeoidbox på vald plats
        static void AddNewSphereBox()
        {
            bool valid = false;
            Console.WriteLine("\n\nAdd new SphereBox");
            Console.CursorVisible = true;

            Console.Write("\nEnter ID: "); //ber användaren att skriva in ett id
            int iD;
            valid = int.TryParse(Console.ReadLine(), out iD); //försöker göra om invärdet till en int
            if (valid == false)
                throw new ArgumentException("Please enter only digits"); //felmeddelande om det inte bara var siffror
            if (iD < 1)
                throw new ArgumentException("Please a number above 0"); //felmeddelande om talet var minde än 1



            Console.Write("\nEnter Weight in kG: "); //ber användaren att skriva in ett vikt i kg
            uint weight;
            valid = uint.TryParse(Console.ReadLine(), out weight); //försöker göra om invärdet till en uint
            if (valid == false)
                throw new ArgumentException("Please enter only digits"); //felmeddelande om det inte bara var siffror
            if (weight < 1)
                throw new ArgumentException("Please a number above 0"); //felmeddelande om talet var minde än 1



            Console.Write("\nEnter Size in Cm: "); //ber användaren att skriva in storlek i cm
            decimal radius;
            valid = decimal.TryParse(Console.ReadLine(), out radius); //försöker göra om invärdet till en decimal
            if (valid == false)
                throw new ArgumentException("Please enter only digits"); //felmeddelande om det inte bara var siffror
            if (radius < 1)
                throw new ArgumentException("Please a number above 0"); //felmeddelande om talet var minde än 1
            radius = Math.Round(radius, 0); //rundar av talet till 0 decimaler



            Console.Write("\nEnter Insurace Value: "); //ber användaren att skriva in Insurance Value
            int insurance;
            valid = int.TryParse(Console.ReadLine(), out insurance); //försöker göra om invärdet till en int
            if (valid == false)
                throw new ArgumentException("Please enter only digits"); //felmeddelande om det inte bara var siffror
            if (insurance < 1)
                throw new ArgumentException("Please a number above 0"); //felmeddelande om talet var minde än 1


            Console.Write("\nEnter Floor (1-3): "); //ber användaren att skriva in vilken våning
            int floor;
            valid = int.TryParse(Console.ReadLine(), out floor); //försöker göra om invärdet till en int
            if (valid == false)
                throw new ArgumentException("Please enter only digits"); //felmeddelande om det inte bara var siffror
            if (floor < 1 ^ floor > 3)
                throw new ArgumentException("Please a number above 0"); //felmeddelande om talet var minde än 1
            floor += -1; //tar bort 1 för att komma till rätt plats i arrayen



            Console.Write("\nEnter Shelf (1-100): "); //ber användaren att skriva in vilken hylla
            int shelf;
            valid = int.TryParse(Console.ReadLine(), out shelf); //försöker göra om invärdet till en int
            if (valid == false)
                throw new ArgumentException("Please enter only digits"); //felmeddelande om det inte bara var siffror
            if (shelf < 1 ^ shelf > 100)
                throw new ArgumentException("Please a number above 0"); //felmeddelande om talet var minde än 1
            shelf += -1; //tar bort 1 för att komma till rätt plats i arrayen



            Console.Clear(); //rensar konsollen
            string sTotalWeight = SantasWorkShop.Weight(); //får information om warehouse vikt
            Console.SetCursorPosition(32, 14); //skriver ut på bestämd plats
            Console.WriteLine("[" + sTotalWeight + "]"); //skriver ut warehouses vikt
            string prompt = "\n\n   Is it fragile?: "; //menyalternativ för att välja om lådan är fragile
            string[] options = { "Yes", "No" };
            bool isFragile = false;
            Menu fragile = new Menu(prompt, options); 
            int selextedIndex = fragile.Run();
            if (selextedIndex == 0) //returvärdet från menyalternativet bestämmer om lådan är fragile eller inte
                isFragile = true;
            if (selextedIndex == 1)
                isFragile = false;

            string result;
            SantasWorkShop.AddNewSphereBox(iD, weight, isFragile, insurance, radius, floor, shelf, out result); //försöker lägga till lådan
            Console.WriteLine(result); //skriver ut resultatet

            Console.WriteLine("Press any key to continue...");
            SaveData(); //sparar data till fil
            Console.ReadLine();
            Console.Clear();
            Menu(); //kallar på menyn
        } //Metod för att läga till SphereBox på vald plats
        static void AddNewBlobBox()
        {
            bool valid = false;
            Console.WriteLine("\n\nAdd new BlobBox");
            Console.CursorVisible = true;

            Console.Write("\nEnter ID: "); //ber användaren att skriva in ett id
            int iD;
            valid = int.TryParse(Console.ReadLine(), out iD); //försöker göra om invärdet till en int
            if (valid == false)
                throw new ArgumentException("Please enter only digits"); //felmeddelande om det inte bara var siffror
            if (iD < 1)
                throw new ArgumentException("Please a number above 0"); //felmeddelande om talet var minde än 1



            Console.Write("\nEnter Weight in kG: "); //ber användaren att skriva in ett vikt i kg
            uint weight;
            valid = uint.TryParse(Console.ReadLine(), out weight); //försöker göra om invärdet till en uint
            if (valid == false)
                throw new ArgumentException("Please enter only digits"); //felmeddelande om det inte bara var siffror
            if (weight < 1)
                throw new ArgumentException("Please a number above 0"); //felmeddelande om talet var minde än 1


            Console.Write("\nEnter Size in Cm: "); //ber användaren att skriva in storlek i cm
            decimal side;
            valid = decimal.TryParse(Console.ReadLine(), out side); //försöker göra om invärdet till en decimal
            if (valid == false)
                throw new ArgumentException("Please enter only digits"); //felmeddelande om det inte bara var siffror
            if (side < 1)
                throw new ArgumentException("Please a number above 0"); //felmeddelande om talet var minde än 1
            side = Math.Round(side, 0); //rundar av talet till 0 decimaler


            Console.Write("\nEnter Insurace Value: "); //ber användaren att skriva in Insurance Value
            int insurance;
            valid = int.TryParse(Console.ReadLine(), out insurance); //försöker göra om invärdet till en int
            if (valid == false)
                throw new ArgumentException("Please enter only digits"); //felmeddelande om det inte bara var siffror
            if (insurance < 1)
                throw new ArgumentException("Please a number above 0"); //felmeddelande om talet var minde än 1


            Console.Write("\nEnter Floor (1-3): "); //ber användaren att skriva in vilken våning
            int floor;
            valid = int.TryParse(Console.ReadLine(), out floor); //försöker göra om invärdet till en int
            if (valid == false)
                throw new ArgumentException("Please enter only digits"); //felmeddelande om det inte bara var siffror
            if (floor < 1 ^ floor > 3)
                throw new ArgumentException("Please a number above 0"); //felmeddelande om talet var minde än 1
            floor += -1; //tar bort 1 för att komma till rätt plats i arrayen


            Console.Write("\nEnter Shelf (1-100): "); //ber användaren att skriva in vilken hylla
            int shelf;
            valid = int.TryParse(Console.ReadLine(), out shelf); //försöker göra om invärdet till en int
            if (valid == false)
                throw new ArgumentException("Please enter only digits"); //felmeddelande om det inte bara var siffror
            if (shelf < 1 ^ shelf > 100)
                throw new ArgumentException("Please a number above 0"); //felmeddelande om talet var minde än 1
            shelf += -1; //tar bort 1 för att komma till rätt plats i arrayen

            string result;
            SantasWorkShop.AddNewBlobBox(iD, weight, insurance, side, floor, shelf, out result); //försöker lägga till lådan
            Console.WriteLine(result); //skriver ut resultatet


            Console.WriteLine("Press any key to continue...");
            SaveData(); //sparar data till fil
            Console.ReadLine();
            Console.Clear();
            Menu(); //kallar på menyn
        } //Metod för att läga till BlobBox på vald plats


        //-----Lägg till box automatiskt-----
        static void AutoAddNewCubeBox()
        {

            bool valid = false;

            Console.WriteLine("\n\nAdd new CubeBox");
            Console.CursorVisible = true;

            Console.Write("\nEnter ID: "); //ber användaren att skriva in ett id
            int iD;
            valid = int.TryParse(Console.ReadLine(), out iD); //försöker göra om invärdet till en int
            if (valid == false)
                throw new ArgumentException("Please enter only digits"); //felmeddelande om det inte bara var siffror
            if (iD < 1)
                throw new ArgumentException("Please a number above 0"); //felmeddelande om talet var minde än 1


            Console.Write("\nEnter Weight in kG: ");  //ber användaren att skriva in ett vikt i kg
            uint weight;
            valid = uint.TryParse(Console.ReadLine(), out weight); //försöker göra om invärdet till en uint
            if (valid == false)
                throw new ArgumentException("Please enter only digits"); //felmeddelande om det inte bara var siffror
            if (weight < 1)
                throw new ArgumentException("Please a number above 0"); //felmeddelande om talet var minde än 1


            Console.Write("\nEnter Size in Cm: "); //ber användaren att skriva in storlek i cm
            decimal side;
            valid = decimal.TryParse(Console.ReadLine(), out side); //försöker göra om invärdet till en decimal
            if (valid == false)
                throw new ArgumentException("Please enter only digits"); //felmeddelande om det inte bara var siffror
            if (side < 1)
                throw new ArgumentException("Please a number above 0"); //felmeddelande om talet var minde än 1
            side = Math.Round(side, 0); //rundar av talet till 0 decimaler



            Console.Write("\nEnter Insurace Value: "); //ber användaren att skriva in Insurance Value
            int insurance;
            valid = int.TryParse(Console.ReadLine(), out insurance); //försöker göra om invärdet till en int
            if (valid == false)
                throw new ArgumentException("Please enter only digits"); //felmeddelande om det inte bara var siffror
            if (insurance < 1)
                throw new ArgumentException("Please a number above 0"); //felmeddelande om talet var minde än 1


            Console.Clear(); //rensar konsollen
            string sTotalWeight = SantasWorkShop.Weight(); //får information om warehouse vikt
            Console.SetCursorPosition(32, 14); //skriver ut på bestämd plats
            Console.WriteLine("[" + sTotalWeight + "]"); //skriver ut warehouses vikt
            string prompt = "\n\n   Is it fragile?: "; //menyalternativ för att välja om lådan är fragile
            string[] options = { "Yes", "No" };
            bool isFragile = false;
            Menu fragile = new Menu(prompt, options);
            int selextedIndex = fragile.Run();
            if (selextedIndex == 0) //returvärdet från menyalternativet bestämmer om lådan är fragile eller inte
                isFragile = true;
            if (selextedIndex == 1)
                isFragile = false;

            string result = "";

            try
            {
                SantasWorkShop.AutoAddNewCubeBox(iD, weight, isFragile, insurance, side, out result); //försöker lägga till lådan
            }
            catch (ArgumentOutOfRangeException fe) //fångar felmeddelande
            {
                Console.WriteLine(fe.Message); //skriver ut felmeddelande
            }
            catch (ArgumentException fe) //fångar felmeddelande
            {
                Console.WriteLine(fe.Message); //skriver ut felmeddelande
            }

            Console.WriteLine(result); //skriver ut resultatet
            Console.WriteLine("Press any key to continue...");
            SaveData(); //sparar data till fil
            Console.ReadLine();
            Console.Clear();
            Menu(); //kallar på menyn
        } //Metod för att läga till Cubebox på automatisk plats
        static void AutoAddNewCubeoidBox()
        {
            bool valid = false;
            Console.WriteLine("\n\nAdd new CubeoidBox");
            Console.CursorVisible = true;

            Console.Write("\nEnter ID: "); //ber användaren att skriva in ett id
            int iD;
            valid = int.TryParse(Console.ReadLine(), out iD); //försöker göra om invärdet till en int
            if (valid == false)
                throw new ArgumentException("Please enter only digits"); //felmeddelande om det inte bara var siffror
            if (iD < 1)
                throw new ArgumentException("Please a number above 0"); //felmeddelande om talet var minde än 1


            Console.Write("\nEnter Weight in kG: "); //ber användaren att skriva in ett vikt i kg
            uint weight;
            valid = uint.TryParse(Console.ReadLine(), out weight); //försöker göra om invärdet till en uint
            if (valid == false)
                throw new ArgumentException("Please enter only digits"); //felmeddelande om det inte bara var siffror
            if (weight < 1)
                throw new ArgumentException("Please a number above 0"); //felmeddelande om talet var minde än 1


            Console.Write("\nEnter Size for Width: ");  //ber användaren att skriva in bredd i cm
            decimal xSide;
            valid = decimal.TryParse(Console.ReadLine(), out xSide); //försöker göra om invärdet till en decimal
            if (valid == false)
                throw new ArgumentException("Please enter only digits"); //felmeddelande om det inte bara var siffror
            if (xSide < 1)
                throw new ArgumentException("Please a number above 0"); //felmeddelande om talet var minde än 1
            xSide = Math.Round(xSide, 0); //rundar av talet till 0 decimaler


            Console.Write("\nEnter Size for Hegiht: "); //ber användaren att skriva in höjd i cm
            decimal ySide;
            valid = decimal.TryParse(Console.ReadLine(), out ySide); //försöker göra om invärdet till en decimal
            if (valid == false)
                throw new ArgumentException("Please enter only digits"); //felmeddelande om det inte bara var siffror
            if (ySide < 1)
                throw new ArgumentException("Please a number above 0"); //felmeddelande om talet var minde än 1
            ySide = Math.Round(ySide, 0); //rundar av talet till 0 decimaler


            Console.Write("\nEnter Size for Depth: "); //ber användaren att skriva in djup i cm
            decimal zSide;
            valid = decimal.TryParse(Console.ReadLine(), out zSide);  //försöker göra om invärdet till en decimal
            if (valid == false)
                throw new ArgumentException("Please enter only digits"); //felmeddelande om det inte bara var siffror
            if (zSide < 1)
                throw new ArgumentException("Please a number above 0"); //felmeddelande om talet var minde än 1
            zSide = Math.Round(zSide, 0); //rundar av talet till 0 decimaler


            Console.Write("\nEnter Insurace Value: "); //ber användaren att skriva in Insurance Value
            int insurance;
            valid = int.TryParse(Console.ReadLine(), out insurance); //försöker göra om invärdet till en int
            if (valid == false)
                throw new ArgumentException("Please enter only digits"); //felmeddelande om det inte bara var siffror
            if (iD < 1)
                throw new ArgumentException("Please a number above 0"); //felmeddelande om talet var minde än 1


            Console.Clear(); //rensar konsollen
            string sTotalWeight = SantasWorkShop.Weight(); //får information om warehouse vikt
            Console.SetCursorPosition(32, 14); //skriver ut på bestämd plats
            Console.WriteLine("[" + sTotalWeight + "]"); //skriver ut warehouses vikt
            string prompt = "\n\n   Is it fragile?: "; //menyalternativ för att välja om lådan är fragile
            string[] options = { "Yes", "No" };
            bool isFragile = false;
            Menu fragile = new Menu(prompt, options);
            int selextedIndex = fragile.Run();
            if (selextedIndex == 0) //returvärdet från menyalternativet bestämmer om lådan är fragile eller inte
                isFragile = true;
            if (selextedIndex == 1)
                isFragile = false;

            string result;
            SantasWorkShop.AutoAddNewCubeoidBox(iD, weight, isFragile, insurance, xSide, ySide, zSide, out result); //försöker lägga till lådan

            Console.WriteLine(result); //skriver ut resultatet
            Console.WriteLine("Press any key to continue...");
            SaveData(); //sparar data till fil
            Console.ReadLine();
            Console.Clear();
            Menu(); //kallar på menyn
        } //Metod för att läga till Cubeoidbox på automatisk plats
        static void AutoAddNewSpeherBox()
        {
            bool valid = false;
            Console.WriteLine("\n\nAdd new SphereBox");
            Console.CursorVisible = true;

            Console.Write("\nEnter ID: "); //ber användaren att skriva in ett id
            int iD;
            valid = int.TryParse(Console.ReadLine(), out iD); //försöker göra om invärdet till en int
            if (valid == false)
                throw new ArgumentException("Please enter only digits"); //felmeddelande om det inte bara var siffror
            if (iD < 1)
                throw new ArgumentException("Please a number above 0"); //felmeddelande om talet var minde än 1



            Console.Write("\nEnter Weight in kG: "); //ber användaren att skriva in ett vikt i kg
            uint weight;
            valid = uint.TryParse(Console.ReadLine(), out weight); //försöker göra om invärdet till en uint
            if (valid == false)
                throw new ArgumentException("Please enter only digits"); //felmeddelande om det inte bara var siffror
            if (weight < 1)
                throw new ArgumentException("Please a number above 0"); //felmeddelande om talet var minde än 1



            Console.Write("\nEnter Size in Cm: "); //ber användaren att skriva in storlek i cm
            decimal radius;
            valid = decimal.TryParse(Console.ReadLine(), out radius); //försöker göra om invärdet till en decimal
            if (valid == false)
                throw new ArgumentException("Please enter only digits"); //felmeddelande om det inte bara var siffror
            if (radius < 1)
                throw new ArgumentException("Please a number above 0"); //felmeddelande om talet var minde än 1
            radius = Math.Round(radius, 0); //rundar av talet till 0 decimaler



            Console.Write("\nEnter Insurace Value: "); //ber användaren att skriva in Insurance Value
            int insurance;
            valid = int.TryParse(Console.ReadLine(), out insurance); //försöker göra om invärdet till en int
            if (valid == false)
                throw new ArgumentException("Please enter only digits"); //felmeddelande om det inte bara var siffror
            if (insurance < 1)
                throw new ArgumentException("Please a number above 0"); //felmeddelande om talet var minde än 1


            Console.Clear(); //rensar konsollen
            string sTotalWeight = SantasWorkShop.Weight(); //får information om warehouse vikt
            Console.SetCursorPosition(32, 14); //skriver ut på bestämd plats
            Console.WriteLine("[" + sTotalWeight + "]"); //skriver ut warehouses vikt
            string prompt = "\n\n   Is it fragile?: "; //menyalternativ för att välja om lådan är fragile
            string[] options = { "Yes", "No" };
            bool isFragile = false;
            Menu fragile = new Menu(prompt, options);
            int selextedIndex = fragile.Run();
            if (selextedIndex == 0) //returvärdet från menyalternativet bestämmer om lådan är fragile eller inte
                isFragile = true;
            if (selextedIndex == 1)
                isFragile = false;

            string result;
            SantasWorkShop.AutoAddNewSphereBox(iD, weight, isFragile, insurance, radius, out result); //försöker lägga till lådan

            Console.WriteLine(result); //skriver ut resultatet
            Console.WriteLine("Press any key to continue...");
            SaveData(); //sparar data till fil
            Console.ReadLine();
            Console.Clear();
            Menu(); //kallar på menyn
        } //Metod för att läga till SpeherBox på automatisk plats
        static void AutoAddNewBlobBox()
        {
            bool valid = false;
            Console.WriteLine("\n\nAdd new BlobBox");
            Console.CursorVisible = true;

            Console.Write("\nEnter ID: "); //ber användaren att skriva in ett id
            int iD;
            valid = int.TryParse(Console.ReadLine(), out iD); //försöker göra om invärdet till en int
            if (valid == false)
                throw new ArgumentException("Please enter only digits"); //felmeddelande om det inte bara var siffror
            if (iD < 1)
                throw new ArgumentException("Please a number above 0"); //felmeddelande om talet var minde än 1



            Console.Write("\nEnter Weight in kG: "); //ber användaren att skriva in ett vikt i kg
            uint weight;
            valid = uint.TryParse(Console.ReadLine(), out weight); //försöker göra om invärdet till en uint
            if (valid == false)
                throw new ArgumentException("Please enter only digits"); //felmeddelande om det inte bara var siffror
            if (weight < 1)
                throw new ArgumentException("Please a number above 0"); //felmeddelande om talet var minde än 1


            Console.Write("\nEnter Size in Cm: "); //ber användaren att skriva in storlek i cm
            decimal side;
            valid = decimal.TryParse(Console.ReadLine(), out side); //försöker göra om invärdet till en decimal
            if (valid == false)
                throw new ArgumentException("Please enter only digits"); //felmeddelande om det inte bara var siffror
            if (side < 1)
                throw new ArgumentException("Please a number above 0"); //felmeddelande om talet var minde än 1
            side = Math.Round(side, 0); //rundar av talet till 0 decimaler


            Console.Write("\nEnter Insurace Value: "); //ber användaren att skriva in Insurance Value
            int insurance;
            valid = int.TryParse(Console.ReadLine(), out insurance); //försöker göra om invärdet till en int
            if (valid == false)
                throw new ArgumentException("Please enter only digits"); //felmeddelande om det inte bara var siffror
            if (insurance < 1)
                throw new ArgumentException("Please a number above 0"); //felmeddelande om talet var minde än 1


            string result;

            SantasWorkShop.AutoAddNewBlobBox(iD, weight, insurance, side, out result); //försöker lägga till lådan

            Console.WriteLine(result); //skriver ut resultatet

            Console.WriteLine("Press any key to continue...");
            SaveData(); //sparar data till fil
            Console.ReadLine();
            Console.Clear();
            Menu(); //kallar på menyn
        } //Metod för att läga till Blob på automatisk plats


        //-----Övrigt-----
        static void RetreiveBox()
        {
            bool valid = false;

            Console.WriteLine("\n\nEnter ID for the box you want to retreive: "); 
            Console.CursorVisible = true;

            Console.Write("\nEnter ID: "); //ber användaren att skriva in ett id
            int iD;
            valid = int.TryParse(Console.ReadLine(), out iD); //försöker göra om invärdet till en int
            if (valid == false)
                throw new ArgumentException("Please enter only digits"); //felmeddelande om det inte bara var siffror
            if (iD < 1)
                throw new ArgumentException("Please a number above 0"); //felmeddelande om talet var minde än 1

            string result;
            I3DStorageObject box; //skapar en temportärt box
            valid = SantasWorkShop.RetreiveBox(iD, out box, out result); //försöker hämta ut lådan
            Console.WriteLine(result);
            if(valid == true) //om det gick att hämta lådan
            {
                Console.WriteLine(box); //skriver ut information om den hämtade lådan
            
            }
            Console.ReadLine();
            Console.Clear();
            SaveData(); //sparar till fil
            Menu(); //kallar på meny
        } //Metod för att plocka ut låda
        static void MoveBox()
        {
            bool valid = false;

            Console.WriteLine("\n\nEnter ID for the box you want to move: ");
            Console.CursorVisible = true;

            Console.Write("\nEnter ID: "); //ber användaren att skriva in ett id
            int iD;
            valid = int.TryParse(Console.ReadLine(), out iD); //försöker göra om invärdet till en int
            if (valid == false)
                throw new ArgumentException("Please enter only digits"); //felmeddelande om det inte bara var siffror
            if (iD < 1)
                throw new ArgumentException("Please a number above 0"); //felmeddelande om talet var minde än 1



            Console.Write("\nEnter Floor to move the box to (1-3): "); //ber användaren att skriva in vilken våning
            int floor;
            valid = int.TryParse(Console.ReadLine(), out floor); //försöker göra om invärdet till en int
            if (valid == false)
                throw new ArgumentException("Please enter only digits"); //felmeddelande om det inte bara var siffror
            if (floor < 1 ^ floor > 3)
                throw new ArgumentException("Please a number above 0"); //felmeddelande om talet var minde än 1
            floor += -1; //tar bort 1 för att komma till rätt plats i arrayen


            Console.Write("\nEnter Shelf to move the box to  (1-100): "); //ber användaren att skriva in vilken hylla
            int shelf;
            valid = int.TryParse(Console.ReadLine(), out shelf); //försöker göra om invärdet till en int
            if (valid == false)
                throw new ArgumentException("Please enter only digits"); //felmeddelande om det inte bara var siffror
            if (shelf < 1 ^ shelf > 100)
                throw new ArgumentException("Please a number above 0"); //felmeddelande om talet var minde än 1
            shelf += -1; //tar bort 1 för att komma till rätt plats i arrayen

            string result = "";
            try
            {
                SantasWorkShop.MoveBox(iD, floor, shelf, out result); //försöker hämta ut lådan
            }
            catch (ArgumentOutOfRangeException fe) //fångar felmeddelande
            {
                Console.WriteLine(fe.Message); //skriver ut felmeddelande
            }
            catch (ArgumentException fe) //fångar felmeddelande
            {
                Console.WriteLine(fe.Message); //skriver ut felmeddelande
            }

            Console.WriteLine(result); //skriver ut om det gick eller inte att hämta lådan
            Console.ReadLine();
            SaveData(); //Sparar data 
            Console.Clear();
            Menu(); //Kallar på menyn
        } //Metod för att flytta låda till ny plats
        static void FindBox()
        {
            bool valid = false;
            Console.Write("\nEnter ID: "); //ber användaren att skriva in ett id
            int iD;
            valid = int.TryParse(Console.ReadLine(), out iD); //försöker göra om invärdet till en int
            if (valid == false)
                throw new ArgumentException("Please enter only digits"); //felmeddelande om det inte bara var siffror
            if (iD < 1)
                throw new ArgumentException("Please a number above 0"); //felmeddelande om talet var minde än 1


            string result;
            SantasWorkShop.FindBox(iD, out result); //skickar in id till FindBox metoden och får tillbaka om det gick eller inte i en string
            Console.WriteLine(result); //skriver ut resultatet
            Console.ReadLine();
            Console.Clear();
            Console.SetCursorPosition(32, 14); //skriver ut på en bestämd plats
            string prompt = "\n\n   Do you want to change the Insurance Value of the box ?\n "; //frågar användaren om man vill byta på insurance value
            string[] options = {
                "Yes",
                "No"};
            Menu insurance = new Menu(prompt, options);
            int selextedIndex = insurance.Run();

            if(selextedIndex == 0) //om man valde ja
            { 
                Console.Write("\nEnter new value: ");  //ber användaren att skriva in Insurance Value
                int value;
                valid = int.TryParse(Console.ReadLine(), out value); //försöker göra om invärdet till en int
                if (valid == false)
                    throw new ArgumentException("Please enter only digits"); //felmeddelande om det inte bara var siffror
                if (value < 1)
                    throw new ArgumentException("Please a number above 0"); //felmeddelande om talet var minde än 1

                bool boolInsurance = SantasWorkShop.ChangeInsurance(iD, value); //försöker ändra på lådans insurance value
                if(boolInsurance == true) //om det gick
                {
                    Console.WriteLine("You changed the value to: " + value); //skriver ut resultatet
                }
                else //om det inte gick
                {
                    Console.WriteLine("The value could not be changed...."); //skriver ut resultatet
                }
            }
            if (selextedIndex == 1) //om man valde nej
            {
                Console.Clear();
                Menu(); //kallar på menyn
            }

            Console.ReadLine();
            Console.Clear();
            SaveData();//sparar data till fil
            Menu();//kallar på meny
        } //Metod för att hitta låda och kunna ändra på insurance value
        static void Print()
        {
            int a = 0;
            foreach (var line in SantasWorkShop.Print()) //skriver ut information om warehouse
            {
                a++;
                if (a % 50 == 0) //detta händer var 50e gång
                {
                    System.Threading.Thread.Sleep(1); //pausar till i en ms
                }
                if (line.ToString().Contains("-")) //om det innehåller teknet
                {
                    Console.ForegroundColor = ConsoleColor.Red; //skriver ut i röd färg
                    Console.Write(line); //skriver ut teknet
                    Console.ForegroundColor = ConsoleColor.White; //skriver ut i vit färg

                }
                else if (line.ToString().Contains("_") ^ line.ToString().Contains(">")) //om den innehåller nåt av tecknena
                {
                    Console.ForegroundColor = ConsoleColor.Green; //skriver ut i grön färg
                    Console.Write(line);//skriver ut teknet
                    Console.ForegroundColor = ConsoleColor.White; //skriver ut i vit färg
                }
                else
                {
                Console.Write(line); //skriver ut teknet
                }
                

            }
            Console.ReadLine();
            Console.Clear();
            Menu(); //kallar på menyn
        } //Metod för att skriva ut information om warehouse
        static void FindIndex()
        {
            bool valid = false;

            Console.Write("\nEnter Floor (1-3): "); //ber användaren att skriva in vilken våning
            int floor;
            valid = int.TryParse(Console.ReadLine(), out floor); //försöker göra om invärdet till en int
            if (valid == false)
                throw new ArgumentException("Please enter only digits"); //felmeddelande om det inte bara var siffror
            if (floor < 1 ^ floor > 3)
                throw new ArgumentException("Please a number between 1-3"); //felmeddelande om talet var minde än 1
            floor += -1; //tar bort 1 för att komma till rätt plats i arrayen


            Console.Write("\nEnter Shelf (1-100): "); //ber användaren att skriva in vilken hylla
            int shelf;
            valid = int.TryParse(Console.ReadLine(), out shelf); //försöker göra om invärdet till en int
            if (valid == false)
                throw new ArgumentException("Please enter only digits"); //felmeddelande om det inte bara var siffror
            if (shelf < 1 ^ shelf > 100)
                throw new ArgumentException("Please a number between 1-100"); //felmeddelande om talet var minde än 1
            shelf += -1; //tar bort 1 för att komma till rätt plats i arrayen

            List<I3DStorageObject> clone = SantasWorkShop[floor, shelf]; //tar emot en klon av hyllplats listan på vald plats
            
            if (clone.Count > 0) //om listan inte är tom
            {
                Console.WriteLine("\nThis is a clone");
                Console.WriteLine("Changed the Insurance Value of the clone lists boxes to 23\n");
                foreach (var c in clone)
                {
                    c.InsuranceValue = 23;
                    Console.WriteLine(c); //skriver ut information om alla lådor i hyllan
                }
            }
            else //omm den är tom
            {
                Console.WriteLine("This position is empety..."); 
            }
                


            Console.ReadLine();
            Console.Clear();
            Menu();//kallar på meny
        } //Metod för att hitta en låda med index
        static void Exit() 
        {
            Environment.Exit(0); //stänger av programmet
        } //Medtod för att stänga av programmet


        //----Läs Data----
        static void SaveData()
        {
            string filePath = "data.save"; //där filen ska sparas
            var dataSerializer = new DataSerializer(); //skapar en ny dataserializer
            dataSerializer.BinarySerialize(SantasWorkShop, filePath); //skickar till BinarySerialize metoden
        } //sparar data till fil
        static void ReadData()
        {
            string filePath = "data.save"; //där filen ska sparas
            var dataSerializer = new DataSerializer(); //skapar en ny dataserializer
            WareHouse temp = new WareHouse(); //skapar en temp WareHouse
            temp = dataSerializer.BinaryDeserialize(filePath) as WareHouse; //temp får värdet av det som läses in från fil
            if (temp != null) //om filen inte är tom
            {
                SantasWorkShop = temp; //varuhuset får värdet av temp
            }
        } //läser in data till fil
    }
    class DataSerializer
    {
        public void BinarySerialize(object data, string filePath) //metod för att spara data till fil
        {
            FileStream filestream; //skapar en ny filestream
            var bf = new BinaryFormatter(); //skapar en ny binaryformatter
            if (File.Exists(filePath)) File.Delete(filePath); //om filen redan finns, tas den bort
            filestream = File.Create(filePath); //filen skapas
            bf.Serialize(filestream, data); //data skrivs till filen
            filestream.Close(); //filestream stängs ner
        }
        public object BinaryDeserialize(string filepath) //metod för att läsa från fil
        {
            object obj = null; //skapar ett nytt null object
            FileStream filestream; //skapar en ny filestream
            var bf = new BinaryFormatter(); //skapar en ny binaryformatter
            if (File.Exists(filepath)) //om filen finns
            {
                filestream = File.OpenRead(filepath); //läser in data från fil
                obj = bf.Deserialize(filestream); //objectet får datan från BinaryFormatter
                filestream.Close(); //Filestream stängs
            }
            return obj; //obj retuneras
        }
    }

}
