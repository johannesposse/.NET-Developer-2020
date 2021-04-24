using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Media;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;
using System.Runtime.InteropServices;

namespace CarPark_v2_Test
{
    #region Att fixa
    //ATT FIXA
    //Ta bort utkommenterad kod
    //Kan inte läsa kinesiska tecken, ararbiska går bra...


    //FIXADE
    //FIXAD - Fixa full parkeringsplats meddelande
    //FIXAD - Skicka bra felmeddelanden...
    //FIXAD - parkeringsplats räknaren räknar lite fel...
    //FIXAD - Fixa texten i optimizera motorcykel

    //G krav
    //Kvar att göra:
    //Kolla buggar/felinmatning m.m.
    //skriva kommentarer i koden

    //Fixade för G
    //FIXAD - sök parkeringsruta ska skriva ut båda om det står 2
    //FIXAD - fixa motorcykelplatsparkering
    //FIXAD - fixa read only på regnr, kan göras via konstruktor?
    //FIXAD - får inte finnas flera regnummer som är samma
    //FIXAD - i sök ska den visa tid / kr
    //FIXAD - motorcykel kan optimeras direkt när den körs in
    //FIXAD - sök behöver göras om för 2st motorcyklar
    //FIXAD - Fixa motorcykelpris 10kr /h
    //FIXAD - flytta motorcyklar
    //FIXAD - flytta behöver göras om för 2st motorcyklar
    //FIXAD - fixa så att den skapar en databas om filen inte finns
    //FIXAD - rensa parkeringsplatsen
    //FIXAD - Göra en funktionerande initializer, kan skicka in till addToDatabase funtionen
    //FIXAD - kika över antal lediga platser funktionen, visar lite fel tal tror jag?
    //TROR DEN ÄR FIXAD - RegNr Property ska vara readonly...

    //Fixade för VG
    //FIXAD - Hantera andra alfabet än det latinska
    //FIXAD - Sparar och läser från databas efter alla ändringar
    //FIXAD - Visar en visuell presentation av parkeringshuset
    //FIXAD - flytta på mc..
    //FIXAD - måste ha ett menyalternativ för mc optimisering

    //Extra
    //ta bort de första 5 minuterba när det ska ta betalt
    //kanske byta tom plats från "0" till "!"
    //Snygga till presentation av parkeringshus
    //Coolt intro 
    #endregion

    class Program
    {
        static string filePath = "exempeldata.csv"; //här skriver man in namnet på .csv filen man vill läsa
        static List<ParkVehicle> Vehicles = new List<ParkVehicle>();
        static List<IntVehicle> iVehicle = new List<IntVehicle>();
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            Console.Title = "Pauls Pro Parking 2.0";
            try //Om det är en körs på en skärm med för låg skärmupplösning så fångar den det här
            {
                Console.SetWindowSize(210, 60);
            }
            catch
            {
                string logo = @"
  _____            _       _____             _____           _    _             
 |  __ \          | |     |  __ \           |  __ \         | |  (_)            
 | |__) |_ _ _   _| |___  | |__) | __ ___   | |__) |_ _ _ __| | ___ _ __   __ _ 
 |  ___/ _` | | | | / __| |  ___/ '__/ _ \  |  ___/ _` | '__| |/ / | '_ \ / _` |
 | |  | (_| | |_| | \__ \ | |   | | | (_) | | |  | (_| | |  |   <| | | | | (_| |
 |_|   \__,_|\__,_|_|___/ |_|   |_|  \___/  |_|   \__,_|_|  |_|\_\_|_| |_|\__, |
                                                                           __/ |
                                                                          |___/ 
";

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(logo);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Your computer might have low screen resolution...");
                Console.WriteLine("Press anykey to continue...");
                Console.ReadLine();
            }
            LoadingScreen(); //En liten intro snutt
            ReadFromDataBase(); //läser in data från .csv fil
            MenuChoise(); //laddar in menyn
        }
        static void LoadingScreen()
        {
            Console.Clear();
            string logo = @"
  _____            _       _____             _____           _    _             
 |  __ \          | |     |  __ \           |  __ \         | |  (_)            
 | |__) |_ _ _   _| |___  | |__) | __ ___   | |__) |_ _ _ __| | ___ _ __   __ _ 
 |  ___/ _` | | | | / __| |  ___/ '__/ _ \  |  ___/ _` | '__| |/ / | '_ \ / _` |
 | |  | (_| | |_| | \__ \ | |   | | | (_) | | |  | (_| | |  |   <| | | | | (_| |
 |_|   \__,_|\__,_|_|___/ |_|   |_|  \___/  |_|   \__,_|_|  |_|\_\_|_| |_|\__, |
                                                                           __/ |
                                                                          |___/ 
";

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(logo);
            Console.ForegroundColor = ConsoleColor.White;
            string anyKey = "\t\t\t\tWelcome!\n";
            for (int i = 0; i < anyKey.Length; i++) 
            {
                Console.Write(anyKey[i]);
                Thread.Sleep(50);
            }
            Thread.Sleep(1000);
        } //En liten enkel laddninskärm innan menyn visas
        static void FillParkingLot()
        {
            Console.Clear();
            Menu();
            Random rnd = new Random();
            string letters = "";
            string vehicle = "";
            string numbers = "";
            string reg = "";
            string typeOfVehicle = "";
            string parkTime = "";
            for (int i = 0; i < 10; i++) //en loop som genererar 10 st fordon, 5st car och 5st mc
            {
                letters = "";
                for (int j = 0; j < 3; j++)
                {
                    char randomChar = (char)rnd.Next('a', 'z'); //skapar random bokstav
                    letters = letters + randomChar;
                }
                numbers = rnd.Next(1, 9).ToString() + rnd.Next(1, 9).ToString() + rnd.Next(1, 9).ToString(); //skapar random siffra
                string regNr = letters.ToUpper() + numbers;

                numbers = rnd.Next(1, 3).ToString();
                if (i < 4)
                {
                    typeOfVehicle = "car";
                }
                if (i > 4)
                {
                    typeOfVehicle = "mc";
                }
                parkTime = DateTime.Now.ToString();
                AddToDataBase(regNr, typeOfVehicle, parkTime);
                Thread.Sleep(200);
            }
            BackToMenu();
        } //Parkerar 5st random bilar och 5st random motocyklar
        static void Menu()
        {
            string logo = @"
  _____            _       _____             _____           _    _             
 |  __ \          | |     |  __ \           |  __ \         | |  (_)            
 | |__) |_ _ _   _| |___  | |__) | __ ___   | |__) |_ _ _ __| | ___ _ __   __ _ 
 |  ___/ _` | | | | / __| |  ___/ '__/ _ \  |  ___/ _` | '__| |/ / | '_ \ / _` |
 | |  | (_| | |_| | \__ \ | |   | | | (_) | | |  | (_| | |  |   <| | | | | (_| |
 |_|   \__,_|\__,_|_|___/ |_|   |_|  \___/  |_|   \__,_|_|  |_|\_\_|_| |_|\__, |
                                                                           __/ |
                                                                          |___/ 
";

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(logo);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1. Park Vehicle");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("2. Retrive Vehicle");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("3. Search Vehicle");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("4. Search Parking Slot");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("5. Move Vehicle");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("6. Show Parking lot");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("7. Optimize Mc parking lots");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("8. Empty Parking Lot");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("9. Park 5 cars and 5 bikes (For testing purposes)");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("10. Exit program");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»\n");
            Console.ForegroundColor = ConsoleColor.White;
            VacantPlaces();
            Console.WriteLine("\n");
        } //Printar menyvalen
        static void MenuChoise()
        {
            Console.Clear();
            Menu();
            int menuChoise = 1;
            bool menuBool = false;

            while (menuBool == false) //Här körs en whileloop som kommer att göras tills en siffra mellan 1 - 10 blir skrivet. Skrivs 1-10 in så bryts loopen
            {
                try
                {
                    menuChoise = int.Parse(Console.ReadLine());

                    if (menuChoise < 1 || menuChoise > 10) //Här kollar koden om den är mindre än ett eller större än 10, är det inte det så skriver den ut ett felmeddelande
                    {
                        throw new ArgumentOutOfRangeException("You can only enter a number between 1-10");
                    }
                    else //Om det är mellan 1 - 10 bryts loopen
                    {
                        menuBool = true;
                    }
                }
                catch (ArgumentOutOfRangeException fe)
                {
                    Console.WriteLine(fe.Message);
                }
                catch (Exception fe)
                {
                    Console.WriteLine(fe.Message);
                }
            }

            int places = 0;
            for (int i = 0; i < iVehicle.Count; i++) //Här kollar den ifall parkeringsplatsen är full,
            {
                if (iVehicle[i].RegNr != "0")
                {
                    places++;
                }
            }
            int mcSlots = VacantPlaces();
            if (places == 100 & mcSlots == 0) // är parkeringsplatsen fukk går det inte att parkera fler fordon.
            {
                switch (menuChoise) //Här skikas man vidare till sitt menyval
                {
                    case 1:
                        Console.Clear();
                        Menu();
                        Console.WriteLine("Parking lot full");
                        BackToMenu();
                        break;
                    case 2:
                        RetriveCar();
                        break;
                    case 3:
                        SearchCar();
                        break;
                    case 4:
                        SearchParkingSlot();
                        break;
                    case 5:
                        MoveCar();
                        break;
                    case 6:
                        ShowParkingLot();
                        break;
                    case 7:
                        OptimizeParkingLot();
                        break;
                    case 8:
                        EmptyParkingLot();
                        break;
                    case 9:
                        FillParkingLot();
                        break;
                    case 10:
                        ExitProgram();
                        break;
                }
            }
            else
            {
                switch (menuChoise) //Här skikas man vidare till sitt menyval
                {
                    case 1:
                        ParkCar();
                        break;
                    case 2:
                        RetriveCar();
                        break;
                    case 3:
                        SearchCar();
                        break;
                    case 4:
                        SearchParkingSlot();
                        break;
                    case 5:
                        MoveCar();
                        break;
                    case 6:
                        ShowParkingLot();
                        break;
                    case 7:
                        OptimizeParkingLot();
                        break;
                    case 8:
                        EmptyParkingLot();
                        break;
                    case 9:
                        FillParkingLot();
                        break;
                    case 10:
                        ExitProgram();
                        break;
                }
            }
        } //Här väljer man vilken meny man ska till
        static void ParkCar()
        {
            Console.Clear();
            Menu();
            ParkVehicle Vehicle = new ParkVehicle();
            string regNr = "";
            string typeOfVehicle = "";
            string parkTime = "";
            bool a = false;
            bool valid;
            while (a == false)
            {
                try
                {
                    Console.Write("Enter registration number: ");
                    regNr = Console.ReadLine().ToUpper();
                    regNr = regNr.Replace(" ", ""); //tar bort mellanrum 
                    valid = regNr.All(c => char.IsLetterOrDigit(c)); //här kollar den om det man skriver in är en bokstav eller siffra
                    Console.WriteLine(regNr);
                    if (valid == false)
                    {
                        throw new ArgumentException("Only use letters or digits when entering a registration number"); //kastar felmeddelande om det är annat tecken än bokstav eller siffra
                    }
                    else
                    {
                        if (regNr == "") //om man inte skriver in något
                        {
                            Console.WriteLine("You didnt typ anything, heading back to menu...");
                            BackToMenu();
                        }
                    }
                    Console.Write("Enter vehicle type, 1 for car and 2 for mc: "); //här väljer man 1 för car och 2 för mc
                    int carOrMc = int.Parse(Console.ReadLine());
                    if (carOrMc < 1 || carOrMc > 2)
                    {
                        throw new ArgumentOutOfRangeException("You can only enter 1 for car or 2 for mc"); //kastar felmeddelande om man skriver något annat än 1 eller 2
                    }
                    else
                    {
                        switch (carOrMc)
                        {
                            case 1:
                                typeOfVehicle = "car";
                                break;
                            case 2:
                                typeOfVehicle = "mc";
                                break;
                        }
                    }
                    parkTime = DateTime.Now.ToString();
                    a = true;
                }
                catch (ArgumentOutOfRangeException fe)
                {
                    Console.WriteLine(fe.Message);
                }
                catch (ArgumentException fe)
                {
                    Console.WriteLine(fe.Message);
                }
                catch (Exception fe)
                {
                    Console.WriteLine(fe.Message);
                }
            }
            AddToDataBase(regNr, typeOfVehicle, parkTime); //skickar fordonet till AddToDataBase metoden
            BackToMenu();
        } //Metod för att parkera fordon på första lediga plars, optimizerar motorcyklar vid parkering
        static void RetriveCar()
        {
            Console.Clear();
            Menu();
            Console.Write("Enter registration number for the car you want to retrive: "); //Här skriver man in regnr på fordonet man vill ta bort
            RemoveFromDataBase(Console.ReadLine().ToUpper()); //och det man skriver in skickas till RemoveFromDatabase metoden
            BackToMenu();
        } //Metod för att hämta ut fordon
        static void MoveCar()
        {
            Console.Clear();
            Menu();
            for (int i = 0; i < iVehicle.Count; i++) //här visar den den första lediga parkeringsplatesen för bilar
            {
                if (iVehicle[i].RegNr == "0" & iVehicle[i].RegNr2 == "0")
                {
                    Console.WriteLine("First vacant place for car: {0}", i + 1);
                    break;
                }
            }

            Console.Write("Enter regnr for the vechicle you want to move: ");
            string regNr = Console.ReadLine().ToUpper();
            bool found = false;
            string regNrTemp = "";
            string typeOfVehicleTemp = "";
            string parkTimeTemp = "";
            int parkingSlotFound = 0;
            int oneOrTwo = 0;
            for (int i = 0; i < iVehicle.Count; i++) // här letar den efter fordonet som man vill flytta på
            {
                if (iVehicle[i].RegNr == regNr) //parkeringsplats del 1
                {
                    Console.WriteLine("{0} was found on parking slot {1}", regNr, (i + 1));
                    regNrTemp = iVehicle[i].RegNr;
                    typeOfVehicleTemp = iVehicle[i].TypeOfVehicle;
                    parkTimeTemp = iVehicle[i].ParkTime;
                    parkingSlotFound = i;
                    oneOrTwo = 1;
                    found = true;
                    break;
                }
                if (iVehicle[i].RegNr2 == regNr)//parkeringsplats del 1
                {
                    Console.WriteLine("{0} was found on parking slot {1}", regNr, (i + 1));
                    regNrTemp = iVehicle[i].RegNr2;
                    typeOfVehicleTemp = iVehicle[i].TypeOfVehicle2;
                    parkTimeTemp = iVehicle[i].ParkTime2;
                    parkingSlotFound = i;
                    oneOrTwo = 2;
                    found = true;
                    break;
                }
            }
            if (found == false) //om den inte hittas så kör denna koden
            {
                Console.WriteLine("{0} is not parked here", regNr);
                BackToMenu();
            }
            Console.Write("Where do you want to move {0}: ", regNr); //sen frågar den vart fordonet ska flyttas
            int parkingSlot = 0;
            try
            {
                parkingSlot = int.Parse(Console.ReadLine());
                if (parkingSlot < 1 || parkingSlot > 100)
                {
                    throw new ArgumentOutOfRangeException("You can only enter a number between 1-100"); //om det man skriver in är > 100 eller < 1 så kastas detta felmeddelande
                }
            }
            catch (ArgumentOutOfRangeException fe)
            {
                Console.WriteLine(fe.Message);
                BackToMenu();
            }
            catch (Exception fe)
            {
                Console.WriteLine(fe.Message);
                BackToMenu();
            }

            if (typeOfVehicleTemp == "car") //om fordonstypen är en bil så körs denna
            {
                if (iVehicle[parkingSlot - 1].RegNr != "0" || iVehicle[parkingSlot - 1].RegNr2 != "0") //om parkeringsplatsen man vill flytta till är upptagen 
                {
                    Console.WriteLine("Parking slot occupied");
                }
                if (iVehicle[parkingSlot - 1].RegNr == "0" & iVehicle[parkingSlot - 1].RegNr2 == "0") //om parkeringsplatsen man vill flytta till är ledig
                {
                    iVehicle[parkingSlot - 1].RegNr = regNrTemp;
                    iVehicle[parkingSlot - 1].TypeOfVehicle = typeOfVehicleTemp;
                    iVehicle[parkingSlot - 1].ParkTime = parkTimeTemp;
                    iVehicle[parkingSlotFound].RegNr = "0";
                    iVehicle[parkingSlotFound].TypeOfVehicle = "car";
                    iVehicle[parkingSlotFound].ParkTime = DateTime.Now.ToString();


                    Console.WriteLine("{0} was moved to {1}", regNrTemp, parkingSlot);
                }
            }
            if (typeOfVehicleTemp == "mc")//om fordonstypen är mc
            {
                if (iVehicle[parkingSlot - 1].RegNr != "0" & iVehicle[parkingSlot - 1].RegNr2 == "0") //om parkeringsrutan del 1 och 2 är upptagen
                {
                    Console.WriteLine("Parking slot occupied");
                }
                if (iVehicle[parkingSlot - 1].RegNr == "0" & iVehicle[parkingSlot - 1].TypeOfVehicle2 == "mc") //om del 1 är ledig och del 2 är mc
                {
                    iVehicle[parkingSlot - 1].RegNr = regNrTemp;
                    iVehicle[parkingSlot - 1].TypeOfVehicle = typeOfVehicleTemp;
                    iVehicle[parkingSlot - 1].ParkTime = parkTimeTemp;
                    if (oneOrTwo == 1)
                    {
                        iVehicle[parkingSlotFound].RegNr = "0";
                        iVehicle[parkingSlotFound].TypeOfVehicle = "car";
                        iVehicle[parkingSlotFound].ParkTime = DateTime.Now.ToString();
                        Console.WriteLine("{0} was moved to {1}", regNrTemp, parkingSlot);
                    }
                    if (oneOrTwo == 2)
                    {
                        iVehicle[parkingSlotFound].RegNr2 = "0";
                        iVehicle[parkingSlotFound].TypeOfVehicle2 = "car";
                        iVehicle[parkingSlotFound].ParkTime2 = DateTime.Now.ToString();
                        Console.WriteLine("{0} was moved to {1}", regNrTemp, parkingSlot);
                    }

                    Console.WriteLine("{0} was moved to {1}", regNrTemp, parkingSlot);
                }
                if (iVehicle[parkingSlot - 1].RegNr2 == "0" & iVehicle[parkingSlot - 1].TypeOfVehicle == "mc") //om del ett är mc och del 2 är ledig
                {
                    iVehicle[parkingSlot - 1].RegNr2 = regNrTemp;
                    iVehicle[parkingSlot - 1].TypeOfVehicle2 = typeOfVehicleTemp;
                    iVehicle[parkingSlot - 1].ParkTime2 = parkTimeTemp;
                    if (oneOrTwo == 1)
                    {
                        iVehicle[parkingSlotFound].RegNr = "0";
                        iVehicle[parkingSlotFound].TypeOfVehicle = "car";
                        iVehicle[parkingSlotFound].ParkTime = DateTime.Now.ToString();
                        Console.WriteLine("{0} was moved to {1}", regNrTemp, parkingSlot);
                    }
                    if (oneOrTwo == 2)
                    {
                        iVehicle[parkingSlotFound].RegNr2 = "0";
                        iVehicle[parkingSlotFound].TypeOfVehicle2 = "car";
                        iVehicle[parkingSlotFound].ParkTime2 = DateTime.Now.ToString();
                        Console.WriteLine("{0} was moved to {1}", regNrTemp, parkingSlot);
                    }

                }
                if (iVehicle[parkingSlot - 1].RegNr2 == "0" & iVehicle[parkingSlot - 1].RegNr2 == "0") 
                {
                    iVehicle[parkingSlot - 1].RegNr = regNrTemp;
                    iVehicle[parkingSlot - 1].TypeOfVehicle = typeOfVehicleTemp;
                    iVehicle[parkingSlot - 1].ParkTime = parkTimeTemp;
                    if (oneOrTwo == 1)
                    {
                        iVehicle[parkingSlotFound].RegNr = "0";
                        iVehicle[parkingSlotFound].TypeOfVehicle = "car";
                        iVehicle[parkingSlotFound].ParkTime = DateTime.Now.ToString();
                        Console.WriteLine("{0} was moved to {1}", regNrTemp, parkingSlot);
                    }
                    if (oneOrTwo == 2)
                    {
                        iVehicle[parkingSlotFound].RegNr2 = "0";
                        iVehicle[parkingSlotFound].TypeOfVehicle2 = "car";
                        iVehicle[parkingSlotFound].ParkTime2 = DateTime.Now.ToString();
                        Console.WriteLine("{0} was moved to {1}", regNrTemp, parkingSlot);
                    }
                }
            }
            UpdateDataBase();
            BackToMenu();
        } //Metod för att flytta fordon
        static int SearchCar()
        {
            Console.Clear();
            Menu();
            Console.Write("Search registration number ");
            string search = Console.ReadLine().ToUpper();
            bool found = false;
            int parkingslot = 0;
            double minPris = 0;
            double timpris = 0;
            string vehicleTime = "";

            for (int i = 0; i < iVehicle.Count; i++)
            {
                if (iVehicle[i].RegNr == search || iVehicle[i].RegNr2 == search) //här kollar den om fordonet är parkerat här
                {
                    if (iVehicle[i].RegNr == search)
                    {
                        vehicleTime = iVehicle[i].ParkTime;
                    }
                    if (iVehicle[i].RegNr2 == search)
                    {
                        vehicleTime = iVehicle[i].ParkTime2;
                    }
                    //här kör den kod som visar hur länge fordonet har vart parkerat och vilket vad det kostar för parkeringen
                    DateTime now = DateTime.Now;
                    DateTime then = Convert.ToDateTime(vehicleTime);
                    Console.WriteLine("Parked at: {0}", then);
                    Console.WriteLine("Current time: {0}", now);
                    double iThen = (now - then).TotalMinutes;
                    double totalTime = Math.Round(iThen, 0);

                    if (totalTime < 5)
                    {
                        Console.WriteLine("Jippie kaj yay, free parking");
                    }
                    else
                    {
                        if (iVehicle[i].TypeOfVehicle == "car")
                        {
                            minPris = 40;
                            timpris = 20;
                        }
                        if (iVehicle[i].TypeOfVehicle == "mc" || iVehicle[i].TypeOfVehicle2 == "mc")
                        {
                            minPris = 20;
                            timpris = 10;
                        }
                        double timmar = Math.Ceiling((double)totalTime / 60);
                        double pris = 0;
                        Console.WriteLine("Hours parked: {0}h", timmar);
                        if (timmar < 2)
                        {
                            Console.WriteLine("Minimun pris: {0}kr", minPris);
                        }
                        else
                        {
                            pris = (timmar) * timpris;
                            Console.WriteLine("Price for {0}h: {1}kr", timmar, pris);
                        }
                    }
                    Console.WriteLine("{0} was found on parking slot {1}", search, i + 1);
                    found = true;
                    parkingslot = i;
                    BackToMenu();
                    return parkingslot;
                }
            }
            if (found == false) //om fordonet inte är parkerat här så körs denna koden
            {
                Console.WriteLine("{0} is not parked here", search);
                BackToMenu();
                return 0;
            }
            BackToMenu();
            return parkingslot;
        } //Metod för att söka efter registreringsnummer
        static int SearchParkingSlot()
        {
            Console.Clear();
            Menu();
            int parkingslot = -1;
            try
            {
                Console.Write("Enter parking slot number: ");
                int search = int.Parse(Console.ReadLine().ToUpper());

                if (search < 1 || search > 100) 
                {
                    throw new ArgumentOutOfRangeException("You can only enter a number between 1-100");//om man letar efter en parkeringsplats som inte finns kastas detta felmeddelande
                }

                if (iVehicle[search - 1].RegNr != "0" & iVehicle[search - 1].TypeOfVehicle == "car") //här kollar if sattserna om det står ett fordon på parkeringsrutan
                {
                    Console.WriteLine("{0} is parked on parking slot {1}", iVehicle[search - 1].RegNr, search);
                }
                if (iVehicle[search - 1].TypeOfVehicle == "mc" & iVehicle[search - 1].TypeOfVehicle2 == "car")
                {
                    Console.WriteLine("{0} is parked on parking slot {1}", iVehicle[search - 1].RegNr, search);
                }
                if (iVehicle[search - 1].TypeOfVehicle == "car" & iVehicle[search - 1].TypeOfVehicle2 == "mc")
                {
                    Console.WriteLine("{0} is parked on parking slot {1}", iVehicle[search - 1].RegNr2, search);
                }
                if (iVehicle[search - 1].TypeOfVehicle == "mc" & iVehicle[search - 1].TypeOfVehicle2 == "mc")
                {
                    Console.WriteLine("{0} & {1} is parked on parking slot {2}", iVehicle[search - 1].RegNr, iVehicle[search - 1].RegNr2, search);
                }
                if (iVehicle[search - 1].RegNr == "0" & iVehicle[search - 1].RegNr2 == "0") //om parkeringsrutan är ledig så körs denna koden
                {
                    Console.WriteLine("{0} is empty", search);
                    parkingslot = search - 1;
                    BackToMenu();
                    return parkingslot;
                }
                BackToMenu();
                return parkingslot;
            }
            catch (ArgumentOutOfRangeException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (Exception fe)
            {
                Console.WriteLine(fe.Message);
            }
            BackToMenu();
            return parkingslot;
        } //Metod för att söka efter parkeringsruta
        static void ShowParkingLot()
        {

            ReadFromDataBase();
            Console.Clear();
            StringBuilder line = new StringBuilder();
            Console.ForegroundColor = ConsoleColor.Yellow;
            line.Append('»', 200);
            Console.WriteLine(line + "\n");
            Console.ForegroundColor = ConsoleColor.White;
            StringBuilder parkingGrid = new StringBuilder();
            int count = 0;
            string vehicle = "";
            string type = "";
            string vehicle2 = "";
            string type2 = "";
            bool mc = false;
            for (int j = 0; j < 10; j++) //en loop i loop som skrivet ut alla parkeringsplatser i ett 10x10 grid med hjälp av en stringbuilder
            {
                for (int i = 0; i < 10; i++)
                {
                    type = "/" + iVehicle[count].TypeOfVehicle;
                    vehicle = iVehicle[count].RegNr;
                    type2 = "/" + iVehicle[count].TypeOfVehicle2;
                    vehicle2 = iVehicle[count].RegNr2;
                    if (vehicle == "0" & vehicle2 == "0") //om parkeringsrutan är tom så läggs empty till
                    {
                        vehicle = "empty";
                        type = "";
                        parkingGrid.Append($" {count + 1}.[{vehicle}{type}]");
                    }
                    else
                    {
                        if (type == "/car" & vehicle2 == "0") //om det står en bil parkerad
                        {
                            parkingGrid.Append($" {count + 1}.[{vehicle}/C]");
                        }
                        if (type == "/mc" & type2 == "/mc") //om det står två st mc parkerade på samma
                        {
                            parkingGrid.Append($" {count + 1}.[{vehicle}/M][{vehicle2}/M]");
                            mc = true;
                        }
                        if (type == "/car" & type2 == "/mc") //om det står en mc på andra delen av parkeringsrutan
                        {
                            parkingGrid.Append($" {count + 1}.[{vehicle2}/M]");
                        }
                        if (type == "/mc" & mc == false) // om det står en mc på första delen på parkeringsrutan
                        {
                            parkingGrid.Append($" {count + 1}.[{vehicle}/M]");
                        }
                        mc = false;
                    }
                    count++;
                }
                parkingGrid.Append("\n\n"); 
                parkingGrid.Append('—', 200); //lägger till en avskilljare var efter 10 parkeringsrutor och ny rad
                parkingGrid.Append("\n\n");
            }
            
            for (int i = 1; i < (parkingGrid.Length -1); i++) //här ändrar den färgen på texten som skrivs ut om det är en mc, car, eller empty
            {
                bool a = false;
                if (parkingGrid[i + 1].Equals('C') & parkingGrid[i].Equals('/'))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(parkingGrid[i]);

                    a = true;
                }
                if (parkingGrid[i].Equals('C') & parkingGrid[i - 1].Equals('/'))
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write(parkingGrid[i]);
                    a = true;
                }

                if (parkingGrid[i + 1].Equals('M') & parkingGrid[i].Equals('/'))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(parkingGrid[i]);

                    a = true;
                }
                if (parkingGrid[i].Equals('M') & parkingGrid[i - 1].Equals('/'))
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(parkingGrid[i]);
                    a = true;
                }
                if (parkingGrid[i] == 'e' || parkingGrid[i] == 'm' || parkingGrid[i] == 'p' || parkingGrid[i] == 't' || parkingGrid[i] == 'y')
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(parkingGrid[i]);
                    a = true;
                }
                if (a == false)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(parkingGrid[i]);
                }
            }
            Console.WriteLine("C = Car, M = Mc");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(line + "\n");
            Console.ForegroundColor = ConsoleColor.White;
            VacantPlaces();
            BackToMenu();
        } //Metod för att visa parkeringsplatser
        static void OptimizeParkingLot()
        {
            Console.Clear();
            Menu();
            int oneOrTwo = 0;
            string tempRegNr = "";
            string tempVehicleType = "";
            string tempParkTime = "";
            for (int i = 0; i < iVehicle.Count; i++)
            {
                if (iVehicle[i].TypeOfVehicle == "mc" & iVehicle[i].TypeOfVehicle2 == "car") //här kollar den om det står en ensam mc parkerad på parkerings platsen
                {                                                                                                                           //gör det det skickas den till Optimize metoden och platsen där den stog sätts med noll väden
                    tempRegNr = iVehicle[i].RegNr;
                    tempVehicleType = iVehicle[i].TypeOfVehicle;
                    tempParkTime = iVehicle[i].ParkTime;
                    iVehicle[i].RegNr = "0";
                    iVehicle[i].TypeOfVehicle = "car";
                    iVehicle[i].ParkTime = "17:19:34";
                    Optimize(tempRegNr, tempVehicleType, tempParkTime);

                }
                if (iVehicle[i].TypeOfVehicle == "car" & iVehicle[i].TypeOfVehicle2 == "mc")//här kollar den om det står en ensam mc parkerad på parkerings platsen
                {                                                                                                                          //gör det det skickas den till Optimize metoden och platsen där den stog sätts med noll väden
                    tempRegNr = iVehicle[i].RegNr2;
                    tempVehicleType = iVehicle[i].TypeOfVehicle2;
                    tempParkTime = iVehicle[i].ParkTime2;
                    iVehicle[i].RegNr2 = "0";
                    iVehicle[i].TypeOfVehicle2 = "car";
                    iVehicle[i].ParkTime2 = "17:19:34";
                    Optimize(tempRegNr, tempVehicleType, tempParkTime);
                }
            }
           
            Console.WriteLine("Parkinglot optimized...");
            UpdateDataBase();
            BackToMenu();
        } //Metod för att opimisera motorcykelparkering
        static void Optimize(string regNr, string typeOfVechile, string parkTime)
        {
            int i = 0;
            if (typeOfVechile == "mc") //här kollar den om det är en mc som kommer in
            {
                for (i = 0; i < iVehicle.Count; i++)
                {
                    if (iVehicle[i].TypeOfVehicle == "mc" & iVehicle[i].RegNr2 == "0") // om det står en mc på första delen av parkeringsrutan kommer den inskickade mcn parkeras här
                    {
                        iVehicle[i].RegNr2 = regNr;
                        iVehicle[i].TypeOfVehicle2 = typeOfVechile;
                        iVehicle[i].ParkTime2 = parkTime;
                        Console.WriteLine("{0} was moved to parking slot {1}", regNr, i + 1);
                        break;
                    }
                    if (iVehicle[i].TypeOfVehicle == "car" & iVehicle[i].RegNr == "0")// omparkeringsrutan är tom kommer den inskickade mcn parkeras här
                    {
                        iVehicle[i].RegNr = regNr;
                        iVehicle[i].TypeOfVehicle = typeOfVechile;
                        iVehicle[i].ParkTime = parkTime;
                        Console.WriteLine("{0} wasmoved to parking slot  {1}", regNr, i + 1);
                        break;
                    }
                    if (iVehicle[i].TypeOfVehicle == "car" & iVehicle[i].TypeOfVehicle2 == "mc")// om det står en mc på andra delen av parkeringsrutan kommer den inskickade mcn parkeras här
                    {
                        iVehicle[i].RegNr = regNr;
                        iVehicle[i].TypeOfVehicle = typeOfVechile;
                        iVehicle[i].ParkTime = parkTime;
                        Console.WriteLine("{0} was moved to parking slot  {1}", regNr, i + 1);
                        break;
                    }
                }
            }
        } //Hjälpmedotd för OptimizeParkingLot
        static void EmptyParkingLot()
        {
            Console.Clear();
            Menu();
            Console.WriteLine("Are you sure you want to empty the parking lot?"); //En extra bekräftelse innan parkeringshuset rensas
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Y/");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("N");
            string yn = Console.ReadLine().ToUpper();

            switch (yn)
            {
                case "Y": //Vid godkännande skapas en list som fylls med nollvärdeb
                    List<string> output = new List<string>();
                    for (int i = 0; i < 100; i++)
                    {
                        output.Add("0,car,17:19:34,0,car,17:19:34");
                    }

                    using (StreamWriter create = new StreamWriter(filePath))
                    {
                        foreach (var o in output) //och listan skrivs in till .csv filen
                        {
                            create.WriteLine(o);
                        }
                    }
                    Console.WriteLine("The parking lot is empty");
                    ReadFromDataBase();
                    BackToMenu();
                    break;
                case "N": //vid nekande så kommer man tillbaka till huvudmenyn
                    BackToMenu();
                    break;
                default:
                    BackToMenu();
                    break;
            }
        } //Metod för att tömma parkeringshuset
        static void ExitProgram() //Metod för att stänga av programmet
        {
            //Programmet stängs av och databasen uppdateras så alla osparade förändringar sparas
            Console.Clear();
            Menu();
            Console.WriteLine("Bye...");
            UpdateDataBase();
            string save = "Saving to database...";
            Random r = new Random();
            for (int i = 0; i < save.Length; i++)
            {
                Console.ForegroundColor = (ConsoleColor)r.Next(0, 16);
                Console.Write(save[i]);
                Thread.Sleep(50);
            }
            System.Threading.Thread.Sleep(2000);
            Console.Beep();
            Environment.Exit(0);
        } //Metod för att stänga av programmet
        static void AddToDataBase(string regNr, string typeOfVechile, string parkTime)
        {

            for (int i = 0; i < iVehicle.Count; i++) //Här kollar den om fordonet redan finns på parkerinen
            {
                if (iVehicle[i].RegNr == regNr || iVehicle[i].RegNr2 == regNr)
                {
                    Console.WriteLine("This vehicle is already parked here");
                    BackToMenu();
                }
            }
            int places = 0;
            if (typeOfVechile == "car")  //Här kollar den om parkeringshuset är fullt.
            {
                for (int i = 0; i < iVehicle.Count; i++)
                {
                    if (iVehicle[i].RegNr != "0")
                    {
                        places++;
                    }
                    if (iVehicle[i].RegNr == "0" & iVehicle[i].RegNr2 != "0")
                    {
                        places++;
                    }
                }
                if (places == 100)
                {
                    Console.WriteLine("Parking lot is full");
                }
                else //är det inte det så parkeras bilen
                {
                    for (int i = 0; i < iVehicle.Count; i++)
                    {
                        if (iVehicle[i].RegNr == "0" & iVehicle[i].TypeOfVehicle2 != "mc")
                        {
                            iVehicle[i].RegNr = regNr;
                            iVehicle[i].TypeOfVehicle = typeOfVechile;
                            iVehicle[i].ParkTime = parkTime;
                            iVehicle[i].RegNr2 = "0";
                            iVehicle[i].TypeOfVehicle2 = "car";
                            iVehicle[i].ParkTime2 = "17:19:34";
                            Console.WriteLine("{0} was parked on parking slot  {1}", regNr, i + 1);
                            break;
                        }
                    }
                }

            }
            if (typeOfVechile == "mc") //om det är en mc som parkeras kommer den parkeras på den första tillgängliga mc parkeringsrutan
            {
                for (int i = 0; i < iVehicle.Count; i++)
                {
                    if (iVehicle[i].TypeOfVehicle == "mc" & iVehicle[i].RegNr2 == "0")
                    {
                        iVehicle[i].RegNr2 = regNr;
                        iVehicle[i].TypeOfVehicle2 = typeOfVechile;
                        iVehicle[i].ParkTime2 = parkTime;
                        Console.WriteLine("{0} was parked on parking slot  {1}", regNr, i + 1);
                        break;
                    }
                    if (iVehicle[i].TypeOfVehicle == "car" & iVehicle[i].RegNr == "0")
                    {
                        iVehicle[i].RegNr = regNr;
                        iVehicle[i].TypeOfVehicle = typeOfVechile;
                        iVehicle[i].ParkTime = parkTime;
                        Console.WriteLine("{0} was parked on parking slot  {1}", regNr, i + 1);
                        break;
                    }
                    if (iVehicle[i].TypeOfVehicle == "car" & iVehicle[i].TypeOfVehicle2 == "mc")
                    {
                        iVehicle[i].RegNr = regNr;
                        iVehicle[i].TypeOfVehicle = typeOfVechile;
                        iVehicle[i].ParkTime = parkTime;
                        Console.WriteLine("{0} was parked on parking slot  {1}", regNr, i + 1);
                        break;
                    }
                }
            }
            UpdateDataBase(); //Databasen uppdateras
        } //Metod för att skriva in parkeringshuset till .csv filen
        static void UpdateDataBase()
        {
            Vehicles.Clear();
            for (int i = 0; i < iVehicle.Count; i++) //här skapar den internadatatypen nya fordon 
            {
                ParkVehicle newParkVehicle = new ParkVehicle(iVehicle[i].RegNr, iVehicle[i].RegNr2);
                newParkVehicle.TypeOfVehicle = iVehicle[i].TypeOfVehicle;
                newParkVehicle.ParkTime = iVehicle[i].ParkTime;
                newParkVehicle.TypeOfVehicle2 = iVehicle[i].TypeOfVehicle2;
                newParkVehicle.ParkTime2 = iVehicle[i].ParkTime2;
                Vehicles.Add(newParkVehicle);
            }
            List<string> output = new List<string>(); //Här skalar den en lista som får värdet av fordonen och skriver in det i .csv filen
            foreach (var vechile in Vehicles)
            {
                output.Add($"{vechile.RegNr},{vechile.TypeOfVehicle},{vechile.ParkTime},{vechile.RegNr2},{vechile.TypeOfVehicle2},{vechile.ParkTime2}");
            }
            File.WriteAllLines(filePath, output); //som sen skrivs in i .csv filen
            ReadFromDataBase();
        } //Metod för att uppdatera .csv filen vid förändringar
        static void RemoveFromDataBase(string regNr)
        {
            bool found = false;
            double minPris = 0;
            double timpris = 0;
            string vehicleTime = "";
            bool pos1 = false;
            bool pos2 = false;
            for (int i = 0; i < iVehicle.Count; i++)
            {
                if (iVehicle[i].RegNr == regNr || iVehicle[i].RegNr2 == regNr) //Här kollar den om den inskickade stringen finns på parkeringsplatsen
                {
                    if (iVehicle[i].RegNr == regNr) //Här kollar den om den står på parkeringsplats i,1 och lägger parktime i en string
                    {
                        vehicleTime = iVehicle[i].ParkTime;
                        pos1 = true;
                    }
                    if (iVehicle[i].RegNr2 == regNr)
                    {
                        vehicleTime = iVehicle[i].ParkTime2; //Här kollar den om den står på parkeringsplats i,2 och lägger parktime i en string
                        pos2 = true;
                    }
                    //Här skriver den ut när fordonet blev parkerad och tiden just nu
                    DateTime now = DateTime.Now;
                    DateTime then = Convert.ToDateTime(vehicleTime);
                    Console.WriteLine("Parked: {0}", then);
                    Console.WriteLine("Current time: {0}", now);
                    double iThen = (now - then).TotalMinutes;
                    double totalTime = Math.Round(iThen, 0);
                    //Här räknar den ut priset för hur länge fordonet har vart parkerat
                    if (totalTime < 5)
                    {
                        Console.WriteLine("Jippie kaj yay, free parking");
                    }
                    else
                    {
                        if (iVehicle[i].TypeOfVehicle == "car")
                        {
                            minPris = 40;
                            timpris = 20;
                        }
                        if (iVehicle[i].TypeOfVehicle == "mc" || iVehicle[i].TypeOfVehicle2 == "mc")
                        {
                            minPris = 20;
                            timpris = 10;
                        }
                        double timmar = Math.Ceiling((double)totalTime / 60);
                        double pris = 0;
                        Console.WriteLine("Hours parked: {0}h", timmar);
                        if (timmar < 2)
                        {
                            Console.WriteLine("Minimun price: {0}kr", minPris);
                        }
                        else
                        {
                            pris = (timmar) * timpris;
                            Console.WriteLine("Price for {0}h: {1}kr", timmar, pris);
                        }
                    }
                    found = true;
                    //Här kör den ut fordonet och sätter in nollvärden
                    if (pos1 == true)
                    {
                        iVehicle[i].RegNr = "0";
                        iVehicle[i].TypeOfVehicle = "car";
                        iVehicle[i].ParkTime = DateTime.Now.ToString();
                        Console.WriteLine("{0} was retrived from parking slot {1}", regNr, i + 1);
                    }
                    //Här kör den ut fordonet och sätter in nollvärden
                    if (pos2 == true)
                    {
                        iVehicle[i].RegNr2 = "0";
                        iVehicle[i].TypeOfVehicle2 = "car";
                        iVehicle[i].ParkTime2 = DateTime.Now.ToString();
                        Console.WriteLine("{0} was retrived from parking slot {1}", regNr, i + 1);
                    }
                    break;
                }
            }//slut på loop  
            //Om fordonet inte är parkerat här körs denna koden
            if (found == false)
            {
                Console.WriteLine("{0} is not parked here", regNr);
            }
            if (found == true) //Databasen uppdateras och läses in på nytt
            {
                UpdateDataBase();
                ReadFromDataBase();
            }

        } //Metod för att plocka ut ett fordon
        static void ReadFromDataBase()
        {
            Vehicles.Clear();
            bool exist = File.Exists(filePath); //Här kollar den om .csv filen finns
            if (exist == false) //Finns den inte så skapas det en ny fil
            {
                string notFound = "\t\tNo database found, creating database...\n\t\t\tPress anykey to continue...";
                for (int i = 0; i < notFound.Length; i++)
                {
                    Console.Write(notFound[i]);
                    Thread.Sleep(50);
                }
                List<string> output = new List<string>();
                for (int i = 0; i < 100; i++)
                {
                    output.Add("0,car,17:19:34,0,car,17:19:34");
                }
                using (StreamWriter create = new StreamWriter(filePath))
                {
                    foreach (var o in output)
                    {
                        create.WriteLine(o);
                    }
                }
                Console.ReadLine();
            }
            List<string> lines = File.ReadAllLines(filePath).ToList(); //Här läses .csv filen in till en stringlista

            foreach (var line in lines) //Här skapas fordonen från .csvfil
            {
                string[] entries = line.Split(',');
                ParkVehicle newParkVehicle = new ParkVehicle(entries[0], entries[3]);
                newParkVehicle.TypeOfVehicle = entries[1];
                newParkVehicle.ParkTime = entries[2];
                newParkVehicle.TypeOfVehicle2 = entries[4];
                newParkVehicle.ParkTime2 = entries[5];
                Vehicles.Add(newParkVehicle);
            }

            iVehicle.Clear();
            for (int i = 0; i < Vehicles.Count; i++) //Här skapas en interntdatatyp för att hantera fordonen i programmet
            {
                IntVehicle newVehicle = new IntVehicle();
                newVehicle.RegNr = Vehicles[i].RegNr;
                newVehicle.TypeOfVehicle = Vehicles[i].TypeOfVehicle;
                newVehicle.ParkTime = Vehicles[i].ParkTime;
                newVehicle.RegNr2 = Vehicles[i].RegNr2;
                newVehicle.TypeOfVehicle2 = Vehicles[i].TypeOfVehicle2;
                newVehicle.ParkTime2 = Vehicles[i].ParkTime2;
                iVehicle.Add(newVehicle);
            }
        } //Motod för att läsa in .csv filen till programmet och skapa fordon
        static int VacantPlaces()
        {
            int places = 0;
            int freeplaces = 0;
            int freeMcSlots = 200;
            int mc = 0;
            int car = 0;

            for (int j = 0; j < iVehicle.Count; j++) //Loop som kollar om det står car eller mc på parkeringsrutan
            {
                if (iVehicle[j].RegNr != "0")
                {
                    if (iVehicle[j].TypeOfVehicle == "car" & iVehicle[j].TypeOfVehicle2 == "car")
                    {
                        car++;
                    }
                    if (iVehicle[j].TypeOfVehicle == "mc")
                    {
                        mc++;
                    }
                    if (iVehicle[j].TypeOfVehicle2 == "mc")
                    {
                        mc++;
                    }
                }
            }
            for (int i = 0; i < iVehicle.Count; i++) //Loop som kollar om det står car eller mc parkerad på parkeringsrutan
            {
                if (iVehicle[i].RegNr != "0")
                {
                    places++;
                }
                if (iVehicle[i].RegNr == "0" & iVehicle[i].RegNr2 != "0")
                {
                    places++;
                }
            }

            freeplaces = 100 - places;
            for (int i = 0; i < iVehicle.Count; i++) //Loop som räknar ut hur många lediga mc parkeringsplatser det finns och tar bort från 200

            {
                if (iVehicle[i].TypeOfVehicle == "mc" & iVehicle[i].TypeOfVehicle2 == "car")
                {
                    freeMcSlots--;
                }
                if (iVehicle[i].TypeOfVehicle == "car" & iVehicle[i].TypeOfVehicle2 == "mc")
                {
                    freeMcSlots--;
                }
                if (iVehicle[i].RegNr == "0" & iVehicle[i].RegNr2 == "0")
                {
                    freeMcSlots--;
                    freeMcSlots--;
                }
            }

            //Här skriver den ut hur många car/mc det står. Hur många lediga platser det finns och hur många upptagna platser det finns
            freeMcSlots = 200 - freeMcSlots;
            int total = car + mc;
            Console.WriteLine("Car/Mc:\t\t\t {0}/{1}", car, mc);
            Console.WriteLine("Free mc slots:\t\t {0}", freeMcSlots);
            Console.WriteLine("Occupied places:\t {0}/100", places);
            if (freeplaces > 31)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Vacant Places:\t\t {0}/100", freeplaces);
                Console.ForegroundColor = ConsoleColor.White;
            }
            if (freeplaces <= 30 & freeplaces > 20)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Vacant Places:\t\t {0}/100", freeplaces);
                Console.ForegroundColor = ConsoleColor.White;
            }
            if (freeplaces <= 20 & freeplaces > 10)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Vacant Places:\t\t {0}/100", freeplaces);
                Console.ForegroundColor = ConsoleColor.White;
            }
            if (freeplaces <= 10)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Vacant Places:\t\t {0}/100", freeplaces);
                Console.ForegroundColor = ConsoleColor.White;
            }
            return freeMcSlots;
        } //Metod för att visa antal lediga platser
        static void BackToMenu() //Metod för att komma tillbaka till menyn
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            MenuChoise();
        } //Metod för att komma tillbaka till huvudmenyn
    }
}
