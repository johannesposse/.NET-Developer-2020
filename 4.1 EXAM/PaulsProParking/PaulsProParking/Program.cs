using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BackEnd;

namespace PaulsProParking
{
    class Program
    {
        static Parking PaulsProParking = new Parking();

        static void Main(string[] args)
        {
            Start(); //Kallar på start metod för programmet

            Console.ReadLine();
        }

        static void Start() //start metod för programmet
        {
            try //försökter sätta consollen till en viss storlek
            {
                Console.SetWindowSize(210, 60);
            }
            catch //om det inte går fångas det här
            {
                Console.WriteLine("Resolution too low");
                System.Threading.Thread.Sleep(200);
            }
            Console.ForegroundColor = ConsoleColor.Green;

            MainMenu(); //Kallar på huvudmenyn
        }

        static void MainMenu()
        {
            Console.Clear();
            string prompt = "Welcome To Pauls Pro Parking, The SQL Version"; //menyalternativ
            string[] options = {
                "Park Vehicle",
                "Retreive Vehicle",
                "Search Vehicle [RegNr]",
                "Search Parking slot",
                "Move Vehicle",
                "Print Parking Lot",
                "Optimize Mc Parking",
                "View Vehicles Parked More Than 48h",
                "Empty Parkinglot",
                "Show History",
                "Show empty parking spots",
                "Show Income Per Day",
                "Show Income (Specific day or intervall)",
                "Exit Program"};

            Menu mainMenu = new Menu(prompt, options); //skickar in menyalternativerna till menu classen
            int selectedIndex = mainMenu.Run(); //får tillbaka vilken meny som valdes
            MenuChoise(selectedIndex); //skickar det som valdes till en switch metod
        }

        static void MenuChoise(int i)
        {
            switch (i) //beroende på vad som valdes i menyn så anropas en metod
            {
                case 0:
                    ParkVehicle();
                    break;
                case 1:
                    RemoveVehicle();
                    break;
                case 2:
                    SearchRegNr();
                    break;
                case 3:
                    SearchParkingSlot();
                    break;
                case 4:
                    MoveVehicle();
                    break;
                case 5:
                    Print();
                    break;
                case 6:
                    OptimizeMcParking();
                    break;
                case 7:
                    MoreThan48h();
                    break;
                case 8:
                    EmptyParkingLot();
                    break;
                case 9:
                    ShowHistory();
                    break;
                case 10:
                    ShowEmptyParkingSpots();
                    break;
                case 11:
                    ShowIncomePerDay();
                    break;
                case 12:
                    ShowIncomeIntervall();
                    break;
                case 13:
                    ExitProgram();
                    break;
                default:
                    break;
            }
        }

        static string CreateRegNr() //hjälpmedtod för att generera registreringsnummer
        {
            string regNr = "";
            Console.Write("Enter RegNr: ");
            try
            {
                regNr = Console.ReadLine().ToUpper();

                if (string.IsNullOrWhiteSpace(regNr) ^ !regNr.All(c => char.IsLetterOrDigit(c))) //om inputen inte är nåntin, en bokstav eller siffra så skapas ett felmeddelande
                {
                    throw new Exception("Please enter letters and numbers");
                }
            }
            catch (Exception x) //felmeddelandet fångas, skrivs ut och användaren kommer tillbaka till menyn
            {
                Console.WriteLine(x.Message);
                Console.ReadLine();
                MainMenu();
            }

            return regNr; //retunerar registreringsnummret
        }

        static int CreateVehicleType() //hjälpmetod för att generera typ av fordon
        {

            int vehicleType = 0;
            Console.Write("Enter Vehicle Type, (1) = Mc (2) = Car: ");
            try
            {
                string temp = Console.ReadLine();
                bool valid = int.TryParse(temp, out vehicleType); //om inputen inte är nåntin, eller karaktär så skapas ett felmeddelande

                if (valid == false)
                {
                    throw new Exception("Please enter (1) for M or (2) for Car");
                }

                if (vehicleType > 2 ^ vehicleType < 1)
                {
                    throw new Exception("Please enter (1) for M or (2) for Car");
                }
            }
            catch (Exception x) //felmeddelandet fångas, skrivs ut och användaren kommer tillbaka till menyn
            {
                Console.WriteLine(x.Message);
                Console.ReadLine();
                MainMenu();
            }

            return vehicleType; //retunerar fordonstypen
        }

        static int CreateYesOrNo(string message) //hjälpmedtod för att skapa ja eller nej frågor
        {
            int result = 0;
            Console.Write(message);
            try
            {
                string temp = Console.ReadLine();
                bool valid = int.TryParse(temp, out result); //om inputen inte är nåntin, eller karaktär så skapas ett felmeddelande

                if (valid == false)
                {
                    throw new Exception("Please enter a number between 1-2");
                }
                if(result < 1 ^ result > 2)
                {
                    throw new Exception("Please enter a number between 1-2");
                }

            }
            catch (Exception x) //felmeddelandet fångas, skrivs ut och användaren kommer tillbaka till menyn
            {
                Console.WriteLine(x.Message);
                Console.ReadLine();
                MainMenu();
            }

            return result; //retunerar ja eller nej som en int
        }

        static int CreateOneToHundred() //hjälpmedtod för att generera parkeringsplats input
        {
            int parkingSlot = 0;

            Console.Write("Enter the parkingslot (1-100): ");
            try
            {
                string temp = Console.ReadLine();
                bool valid = int.TryParse(temp, out parkingSlot); //om inputen inte är nåntin, eller karaktär så skapas ett felmeddelande

                if (valid == false)
                {
                    throw new Exception("Please enter a number between 1-100");
                }
            }
            catch (Exception x) //felmeddelandet fångas, skrivs ut och användaren kommer tillbaka till menyn
            {
                Console.WriteLine(x.Message);
                Console.ReadLine();
                MainMenu();
            }

            return parkingSlot; //retunerar parkingsplats som en int
        }

        static string CreateDate(string message) //hjälpmedtod för att generera datum input
        {
            string date = "";
            Console.Write(message);
            try
            {
                date = Console.ReadLine().ToUpper();

                if (string.IsNullOrWhiteSpace(date)) //om inputen inte är nåntin skapas ett felmeddelande
                {
                    throw new Exception("Please enter a date as (YYYY-MM-DD)");
                }
            }
            catch (Exception x) //felmeddelandet fångas, skrivs ut och användaren kommer tillbaka till menyn
            {
                Console.WriteLine(x.Message);
                Console.ReadLine();
                MainMenu();
            }

            return date; //retunerar datumen som en string
        }

        static void ParkVehicle() //metod för att lägga till fordon
        {
            string regNr = "";
            int vehicleType = 0;
            string result = "";

            regNr = CreateRegNr(); //genererar registreringsnummer
            vehicleType = CreateVehicleType(); //genererar fordonstyp

            try
            {
                result = PaulsProParking.AddToDataBase(regNr, vehicleType); //kallar på metod i backend för att lägga till fordon 
            }
            catch (Exception x) //fångar möjliga fel, skriver ut användar vänliga felmeddelanden
            {

                if (x.Message.Contains("Violation of UNIQUE KEY constraint 'CK_RegNr'. Cannot insert duplicate key in object 'dbo.Vehicle'."))
                {
                    Console.WriteLine("The RegNr is aldready parked");
                }
                else if (x.Message.Contains(@"The INSERT statement conflicted with the CHECK constraint ""CK__Vehicle__RegNr__282DF8C2""."))
                {
                    Console.WriteLine("The RegNr was too short, please enter 3-10 characters");
                }
                else if (x.Message.Contains("String or binary data would be truncated in table 'PPDBJohannesPosse.dbo.Vehicle', column 'RegNr'"))
                {
                    Console.WriteLine("The RegNr was too long, please enter 3-10 characters");
                }
                else if (x.Message.Contains("Cannot insert the value NULL into column 'ParkingSpaceID'"))
                {
                    Console.WriteLine("No available parking spots");
                }

            }

            Console.WriteLine(result); //skriver ut resultatet som retunerades från skapa fordon metoden
            Console.ReadLine();
            MainMenu(); //huvudmenyn kallas på
        }

        static void RemoveVehicle() //metod för att ta bort fordon
        {
            string regNr = "";
            string result = "";
            string info = "";
            int forFree = 0;

            regNr = CreateRegNr(); //genererar registreringsnummer
            forFree = CreateYesOrNo("Do you want to retreive the vehicle for free (1) = No, (2) = Yes: "); //genererar ja eller nej

            try
            {
                result = PaulsProParking.RemoveFromDataBase(regNr); //kallar på metod i backend för att ta bort fordon 
            }
            catch (Exception x) //fångar möjliga fel, skriver ut användar vänliga felmeddelanden
            {
                Console.WriteLine(x.Message);
            }

            if (result.Length > 1) //om string resultatet längd som retuneras är större än ett 
            {
                Console.WriteLine(result);
                PaulsProParking.PrintRemovedVehicle(regNr, forFree, out info); //kallar på metod i backend för att hämta ut det senaste fordonet som blev inlaggt i loggen
                Console.WriteLine("[Info]\n" + info); //skriver ut info om det borttagna fordonen
            }

            Console.ReadLine();
            MainMenu(); //kallar på huvudmenyn
        }

        static void SearchRegNr() //metod för att söka på fordon med registreringsnummer
        {
            string regNr = "";
            string result = "";

            regNr = CreateRegNr(); //genererar registreringsnummer

            result = PaulsProParking.SearchRegNr(regNr); //kallar på metod i backend för att söka efter regnr, retunerar resultat i en string 
            Console.WriteLine(result + "\n\nPress anykey to continue...");
            Console.ReadLine();
            MainMenu(); //kallar på huvudmenyn


        }

        static void SearchParkingSlot() //medtod för att söka på parkeringsplats
        {
            int parkingSlot = 0;
            string result = "";

            parkingSlot = CreateOneToHundred(); //genererar parkeringsplats input
            try
            {
            result = PaulsProParking.SearchParkingSlot(parkingSlot); //kallar på metod i backend för att söka efter parkeringsplats, retunerar resultat i en string 
            }
            catch(Exception x) //fångar möjliga fel
            {
                Console.WriteLine(x.Message);
            }

            Console.WriteLine(result + "\n\nPress anykey to continue...");
            Console.ReadLine();
            MainMenu(); //kallar på huvudmenyn
        }

        static void MoveVehicle() //metod för att flytta fordon
        {
            string regNr = "";
            int parkingSlot = 0;
            string result = "";

            regNr = CreateRegNr(); //genererar registreringsnummer
            parkingSlot = CreateOneToHundred(); //genererar parkeringsplats input

            try
            {
                result = PaulsProParking.MoveVehicle(regNr, parkingSlot); //kallar på metod i backend för att flytta fordon, retunerar resultat i en string 

            }
            catch (Exception x) //fångar möjliga fel, skriver ut användar vänliga felmeddelanden
            {
                if (x.Message.Contains(@"The UPDATE statement conflicted with the CHECK constraint ""CK__ParkedVeh__Parki__31B762FC"""))
                {
                    Console.WriteLine("The parking spot dont exist, please enter a parking spot between 1-100");
                }
                else if (x.Message.Contains(@"The UPDATE statement conflicted with the CHECK constraint ""CK__ParkingSpa__Size__3B40CD36"""))
                {
                    Console.WriteLine("The vehicle could not be moved here as the parking spot if full");
                }
                else if (x.Message.Contains("Vehicle not found"))
                {
                    Console.WriteLine("Vehicle not found");
                }
            }

            Console.WriteLine(result + "\n\nPress anykey to continue...");
            Console.ReadLine();
            MainMenu(); //kallar på huvudmenyn
        }

        static void OptimizeMcParking() //metod för att optimisera motorcyklar på parkeringsplatsen
        {
            string result = "";
            try
            {
                result = PaulsProParking.OptimizeMcParking();  //kallar på metod i backend för att optimisera, retunerar resultat i en string 
            }
            catch (Exception x) //fångar möjliga fel, skriver ut användar vänliga felmeddelanden
            {
                Console.WriteLine(x.Message);
            }
            Console.WriteLine(result);
            Console.WriteLine(PaulsProParking.GetMc() + "\n\nPress anykey to continue..."); //skriver ut de motorcyklar som finns på parkeringen
            Console.ReadLine();
            MainMenu(); //kallar på huvudmenyn
        }

        static void MoreThan48h() //metod för att visa fordon som vart parkerade mer än 48h
        {
            string result = "";
            try
            {
                result = PaulsProParking.MoreThan48h(); //kallar på metod i backend för att skriva ut fordon som vart parkerade >48h
            }
            catch (Exception x) //fångar möjliga fel
            {
                Console.WriteLine(x.Message);
            }

            Console.WriteLine(result + "\n\nPress anykey to continue...");
            Console.ReadLine();
            MainMenu(); //kallar på huvudmeny

        }

        static void EmptyParkingLot() //metod för att tömma parkeringen på forodn
        {
            int remove = 0;
            string result = "";

            remove = CreateYesOrNo("Do you want to remove all vehicle from the parking lot (1) = No, (2) = Yes: "); //genererar ja eller nej

            try
            {
                if (remove == 2)
                {
                    result = PaulsProParking.RemoveAllVehicles(); //kallar på metod i backend för att ta bort alla fordon 
                }
                else if (remove == 1)
                {
                    Console.WriteLine("Nothing was removed");
                }

            }
            catch (Exception x) //fångar möjliga fel
            {
                Console.WriteLine(x.Message);
            }

            Console.WriteLine(result + "\n\nPress anykey to continue...");
            Console.ReadLine();
            MainMenu(); //kallar på huvudmenyn
        }

        static void ShowHistory() //metod för att visa fordon som har varit parkerade tidigare
        {
            string result = "";

            try
            {
                result = PaulsProParking.ShowHistory(); //kallar på metod i backend för att visa fordon som har varit parkerade tidigare
            }
            catch (Exception x)
            {
                Console.WriteLine(x); //fångar möjliga fel
            }

            if (result.Length > 1) //om retur stringen är större än 1 så skrivs resultatet ut
            {
                Console.WriteLine(result);
            }
            else //annars finns det ingen historik
            {
                Console.WriteLine("There is no history");
            }

            Console.WriteLine("\n\nPress anykey to continue...");
            Console.ReadLine();
            MainMenu(); //kallar på huvudmenyn

        }

        static void ShowEmptyParkingSpots() //metod för att visa tomma parkeringsplatser
        {
            string result = "";
            try
            {
                result = PaulsProParking.ShowEmptyParkingSpots(); //kallar på metod i backend för att visa tomma parkeringsplatser
            }
            catch (Exception x) //fångar möjliga fel
            {
                Console.WriteLine(x.Message);
            }

            Console.WriteLine(result + "\n\nPress anykey to continue...");
            Console.ReadLine();
            MainMenu(); //kallar på huvudmenyn
        }

        static void ShowIncomePerDay() //metod för att visa inkomstdagar
        {
            string result = "";

            try
            {
                result = PaulsProParking.ShowIncomePerDay(); //kallar på metod i backend för att visa inkomstdagar
            }
            catch (Exception x) //fångar möjliga fel
            {
                Console.WriteLine(x.Message);
            }


            Console.WriteLine(result + "\n\nPress anykey to continue...");
            Console.ReadLine();
            MainMenu(); //kallar på huvudmenyn
        }

        static void ShowIncomeIntervall()  //metod för att visa inkomstdagar i intervall eller enskilld dag
        {
            string result = "";
            string startDate = "";
            string endDate = "";
            int choise = 0;

            startDate = CreateDate("Enter start date (YYYY-MM-DD): "); //genererar startdatum
            choise = CreateYesOrNo("Do you want to enter an end date? (1) = Yes, (2) = No: "); //generar ja eller nej
            

            if (choise == 1) //om nej
            {
                endDate = CreateDate("Enter end date (YYYY-MM-DD): "); //slutdatum blir samma som startdatum
            }
            else //om ja
            {
                endDate = startDate; //genererar slutdatum
            }

            try
            {
                result = PaulsProParking.ShowIncomeIntervall(startDate, endDate); //kallar på metod i backend för att visa inkomstdagar i intervall eller enskilld dag
            }
            catch (Exception x) //fångar möjliga fel, skriver ut användar vänliga felmeddelanden
            {
                if (x.Message == "Det gick inte att konvertera parametervärdet från en String till en DateTime.")
                {
                    Console.WriteLine("You entered the date(s) in an incorrect format");
                }
                else
                {
                    Console.WriteLine(x);
                }
            }

            if(result.Length < 1) //om resultatet är mindre än ett fanns det inget att visa de datumen
            {
                result = "There was nothing to show";
            }

            Console.WriteLine(result + "\n\nPress anykey to continue...");
            Console.ReadLine();
            MainMenu(); //kallar på huvudmenyn

        }

        static void Print() //metod för att visa alla parkeringsplatser och vad som är parkerat på dom
        {
            string printParking = PaulsProParking.Print(); //kallar på metod i backend för att visa alla parkeringsplatser och vad som är parkerat på dom
            Console.WriteLine(printParking);
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            MainMenu(); //kallar på huvudmeny
        }

        static void ExitProgram() //metod för att stänga av programmet
        {
            Console.WriteLine("The application is closing down...\nBye...");
            System.Threading.Thread.Sleep(500);
            Environment.Exit(0);
        }
    }
}
