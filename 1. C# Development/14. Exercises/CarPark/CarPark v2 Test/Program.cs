using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace CarPark_v2_Test
{
    class Program
    {
        static string filePath = "database.csv";
        static List<ParkVehicle> Vehicles = new List<ParkVehicle>();

        static void FillParkingLot()
        {

            Console.WriteLine(Vehicles.Count());
            Random rnd = new Random();
            string letters ="";
            string numbers = "";
            string reg = "";

            for (int i = 0; i < 10; i++)
            {
                letters = "";
                for (int j = 0; j < 3; j++)
                {
                    
                    char randomChar = (char)rnd.Next('a', 'z');
                    letters = letters + randomChar;
                    Console.WriteLine(letters);
                }

                numbers = rnd.Next(1, 9).ToString() + rnd.Next(1, 9).ToString() + rnd.Next(1, 9).ToString();

                string regNr = letters.ToUpper() + numbers;
                Console.WriteLine("Regnr " + regNr);

                Vehicles.Insert(rnd.Next(0,99), (new ParkVehicle { RegNr = regNr, TypeOfVehicle = "car", ParkingSlot = rnd.Next(1,100), ParkTime = DateTime.Now.ToString() }));
            }
            List<string> output = new List<string>();
            foreach (var vechile in Vehicles)
            {
                output.Add($"{vechile.RegNr},{vechile.TypeOfVehicle},{vechile.ParkingSlot},{vechile.ParkTime}");
            }

            File.WriteAllLines(filePath, output);


            //for (int i = 0; i < 100; i++)
            //{
            //    Vehicles.Add(new ParkVehicle { RegNr = "0", TypeOfVehicle = "car", ParkingSlot = -1, ParkTime = DateTime.Now.ToString() });

            //    List<string> output = new List<string>();
            //    foreach (var vechile in Vehicles)
            //    {
            //        output.Add($"{vechile.RegNr},{vechile.TypeOfVehicle},{vechile.ParkingSlot},{vechile.ParkTime}");
            //    }

            //    File.WriteAllLines(filePath, output);
            //}
        }

        static void Main(string[] args)
        {

            Console.Title = "Pauls Pro Parking 2.0";
            LoadingScreen();
            ReadFromDataBase();
            //FillParkingLot();
            MenuChoise();
            Console.ReadLine();

        }

        static void LoadingScreen()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n\n\n\n\n");
            Console.WriteLine("\tPauls Pro Parking v2.0");
            Console.WriteLine("\t    [          ]");
            Console.WriteLine("\t    Loading 0%");
            System.Threading.Thread.Sleep(200);
            Console.Clear();
            Console.WriteLine("\n\n\n\n\n");
            Console.WriteLine("\tPauls Pro Parking v2.0");
            Console.WriteLine("\t    [-         ]");
            Console.WriteLine("\t    Loading 10%");
            System.Threading.Thread.Sleep(200);
            Console.Clear();
            Console.WriteLine("\n\n\n\n\n");
            Console.WriteLine("\tPauls Pro Parking v2.0");
            Console.WriteLine("\t    [--        ]");
            Console.WriteLine("\t    Loading 20%");
            System.Threading.Thread.Sleep(200);
            Console.Clear();
            Console.WriteLine("\n\n\n\n\n");
            Console.WriteLine("\tPauls Pro Parking v2.0");
            Console.WriteLine("\t    [---       ]");
            Console.WriteLine("\t    Loading 30%");
            System.Threading.Thread.Sleep(200);
            Console.Clear();
            Console.WriteLine("\n\n\n\n\n");
            Console.WriteLine("\tPauls Pro Parking v2.0");
            Console.WriteLine("\t    [----      ]");
            Console.WriteLine("\t    Loading 40%");
            System.Threading.Thread.Sleep(200);
            Console.Clear();
            Console.WriteLine("\n\n\n\n\n");
            Console.WriteLine("\tPauls Pro Parking v2.0");
            Console.WriteLine("\t    [-----     ]");
            Console.WriteLine("\t    Loading 50%");
            System.Threading.Thread.Sleep(200);
            Console.Clear();
            Console.WriteLine("\n\n\n\n\n");
            Console.WriteLine("\tPauls Pro Parking v2.0");
            Console.WriteLine("\t    [------    ]");
            Console.WriteLine("\t    Loading 60%");
            System.Threading.Thread.Sleep(200);
            Console.Clear();
            Console.WriteLine("\n\n\n\n\n");
            Console.WriteLine("\tPauls Pro Parking v2.0");
            Console.WriteLine("\t    [-------   ]");
            Console.WriteLine("\t    Loading 70%");
            System.Threading.Thread.Sleep(200);
            Console.Clear();
            Console.WriteLine("\n\n\n\n\n");
            Console.WriteLine("\tPauls Pro Parking v2.0");
            Console.WriteLine("\t    [--------  ]");
            Console.WriteLine("\t    Loading 70%");
            System.Threading.Thread.Sleep(200);
            Console.Clear();
            Console.WriteLine("\n\n\n\n\n");
            Console.WriteLine("\tPauls Pro Parking v2.0");
            Console.WriteLine("\t    [--------- ]");
            Console.WriteLine("\t    Loading 90%");
            System.Threading.Thread.Sleep(200);
            Console.Clear();
            Console.WriteLine("\n\n\n\n\n");
            Console.WriteLine("\tPauls Pro Parking v2.0");
            Console.WriteLine("\t    [----------]");
            Console.WriteLine("\t    Loading 100%");
            Console.ForegroundColor = ConsoleColor.White;
            System.Threading.Thread.Sleep(400);

            Console.Clear();
            Console.WriteLine("\n\n\n\n\n");
            Console.WriteLine("\t    Välkommen");
            Console.WriteLine("\tTryck för att starta");
            Console.ReadLine();
            Console.Beep(500,100);
            Console.Beep(600, 100);
            Console.Beep(800, 100);
            Console.Beep(1000, 200);
            Console.Beep(800, 400);


        }

        static void Menu()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\nPauls Pro Parking v2.0\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---------------------------------\n");
            Console.WriteLine("1. Park Vehicle");
            Console.WriteLine("2. Retrive Vehicle");
            Console.WriteLine("3. Search Vehicle");
            Console.WriteLine("4. Move Vehicle");
            Console.WriteLine("5. Show Parking lot");
            Console.WriteLine("6. Exit program");
            Console.WriteLine("\n----------------------------------\n");
            VacantPlaces();
            Console.WriteLine("\n");
        }

        static void MenuChoise()
        {
            Console.Clear();
            Menu();

            int menuChoise = 1;
            bool menuBool = false;

            while (menuBool == false)
            {
                try
                {
                    menuChoise = int.Parse(Console.ReadLine());

                    if (menuChoise < 1 || menuChoise > 6)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    else
                    {
                        menuBool = true;
                    }
                }
                catch (ArgumentOutOfRangeException fe)
                {
                    Console.WriteLine(fe.Message);
                    Console.Beep(800, 100);
                    Console.Beep(750, 100);
                    Console.Beep(700, 100);
                }
                catch (Exception fe)
                {
                    Console.WriteLine(fe.Message);
                    Console.Beep(800, 100);
                    Console.Beep(750, 100);
                    Console.Beep(700, 100);
                }
            }

            int places = 0;
            for (int i = 0; i < Vehicles.Count; i++)
            {
                if (Vehicles[i].RegNr != "0")
                {
                    places++;
                }
            }

            if(places == 100)
            {
                switch (menuChoise)
                {
                    case 1:
                        Console.WriteLine("Parkeringsplatsen är full");
                        break;
                    case 2:
                        RetriveCar();
                        break;
                    case 3:
                        SearchCar();
                        break;
                    case 4:
                        MoveCar();
                        break;
                    case 5:
                        ShowParkingLot();
                        break;
                    case 6:
                        ExitProgram();
                        break;
                }
            }
            else
            {
                switch (menuChoise)
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
                        MoveCar();
                        break;
                    case 5:
                        ShowParkingLot();
                        break;
                    case 6:
                        ExitProgram();
                        break;
                }
            }


            
        }

        static void ParkCar()
        {
            Console.Clear();
            Menu();

            ParkVehicle Vehicle = new ParkVehicle();

            bool a = false;

            while (a == false)
            {
                try
                {
                    Console.Write("Skriv in registreringsnummer: ");
                    Vehicle.RegNr = Console.ReadLine().ToUpper();
                    Console.WriteLine("Skriv in typ av fordon: ");
                    Console.WriteLine("Skriv in 1 för bil och 2 för mc");
                    int carOrMc = int.Parse(Console.ReadLine());
                    if (carOrMc < 1 || carOrMc > 2)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    else
                    {
                        switch (carOrMc)
                        {
                            case 1:
                                Vehicle.TypeOfVehicle = "car";
                                break;
                            case 2:
                                Vehicle.TypeOfVehicle = "mc";
                                break;
                        }
                    }
                    Console.Write("Välj parkeringsplats: ");
                    Vehicle.ParkingSlot = int.Parse(Console.ReadLine());
                    Vehicle.ParkTime = DateTime.Now.ToString("HH:mm:ss");
                    a = true;
                }
                catch (ArgumentOutOfRangeException fe)
                {
                    Console.WriteLine(fe.Message);
                    Console.Beep(800, 100);
                    Console.Beep(750, 100);
                    Console.Beep(700, 100);
                }
                catch (Exception fe)
                {
                    Console.WriteLine(fe.Message);
                    Console.Beep(800, 100);
                    Console.Beep(750, 100);
                    Console.Beep(700, 100);
                }
            }

            AddToDataBase(Vehicle.RegNr, Vehicle.TypeOfVehicle, Vehicle.ParkingSlot, Vehicle.ParkTime);

            BackToMenu();
        }
        static void RetriveCar()
        {
            Console.Clear();
            Menu();

            Console.Write("Skriv in registreringsnummret på bilen som ska köras ut: ");
            RemoveFromDataBase(Console.ReadLine().ToUpper());
            BackToMenu();
        }

        static void MoveCar()
        {
            Console.WriteLine("3");
            BackToMenu();
        }

        static void SearchCar()
        {
            Console.Write("Search vehicle regnr: ");
            string search = Console.ReadLine().ToUpper();
            bool found = false;

            for(int i = 0; i < Vehicles.Count; i++)
            {
                if (Vehicles[i].RegNr == search)
                {
                    Console.WriteLine("{0} was found on parking slot {1}", search, i+1); 
                    found = true;
                }
            }
            if (found == false)
            {
                Console.WriteLine("{0} is not parked here", search);
                Console.Beep(800,100);
                Console.Beep(750, 100);
                Console.Beep(700, 100);
            }
            BackToMenu();
        }

        static void ShowParkingLot()
        {

            ReadFromDataBase();

            int i = 1;
            foreach (var vehicle in Vehicles)
                {
                string vehicleTime = vehicle.ParkTime;
                DateTime now = DateTime.Now;
                DateTime then = Convert.ToDateTime(vehicleTime);

                if (vehicle.RegNr != "0")
                {
                    Console.WriteLine($"{i}: [{vehicle.RegNr} |  {now-then}] "); //{vehicle.TypeOfVehicle} | {vehicle.ParkingSlot} |vehicle.ParkTime
                }
                else
                {
                    //Console.WriteLine("{0}: [Empty] ", i);
                }
                i++;
            }

            BackToMenu();
        }

        static void ExitProgram()
        {
            Console.WriteLine("Hej då...");
            System.Threading.Thread.Sleep(2000);
            Console.Beep();
            Environment.Exit(0);

        }

        static void AddToDataBase(string regNr, string typeOfVechile, int parkingSlot, string parkTime)
        {

            //Vehicles.Add(new ParkVehicle { RegNr=regNr, TypeOfVehicle = typeOfVechile, ParkingSlot = parkingSlot, ParkTime = parkTime});
            for (int i = 0; i < Vehicles.Count; i++)
            {
                if (Vehicles[i].RegNr == "0")
                {
                    Vehicles[i].RegNr = regNr;
                    Vehicles[i].TypeOfVehicle = typeOfVechile;
                    Vehicles[i].ParkingSlot = parkingSlot;
                    Vehicles[i].ParkTime = parkTime;
                    Console.WriteLine("{0} blev parkerad på parkeringsplats {1}", regNr, i+1);
                    break;
                }
            }

            List<string> output = new List<string>();
            foreach (var vechile in Vehicles)
            {
                output.Add($"{vechile.RegNr},{vechile.TypeOfVehicle},{vechile.ParkingSlot},{vechile.ParkTime}");
                
            }

            
            File.WriteAllLines(filePath, output);
            ReadFromDataBase();
        }

        static void RemoveFromDataBase(string regNr)
        {
            bool found = false;
            for (int i = 0; i < Vehicles.Count; i++)
            {
                if (Vehicles[i].RegNr == regNr)
                {

                    string vehicleTime = Vehicles[i].ParkTime;
                    DateTime now = DateTime.Now;
                    DateTime then = Convert.ToDateTime(vehicleTime);
                    Console.WriteLine("Inkörd: {0}",then);
                    Console.WriteLine("Utkörd: {0}", now);
                    Console.WriteLine("Total tid: {0}", now-then);

                    double iThen = (now - then).TotalMinutes;
                    double totalTime = Math.Round(iThen, 0);
                    
                    if (totalTime < 5)
                    {
                        Console.WriteLine("Hipp hurra, gratis parkerign");
                    }
                    else
                    {
                        double minPris = 40;
                        double timpris = 20;
                        double timmar = Math.Ceiling((double)totalTime / 60);
                        double pris = 0;
                        if(timmar < 2) 
                        {
                            Console.WriteLine("Minimun pris: {0}kr", minPris);
                        }
                        else
                        {
                            pris = (timmar+1) * timpris;
                            Console.WriteLine("Pris för {0}h: {1}kr",timmar, pris);
                        }
                    }

                    Vehicles[i].RegNr = "0";
                    Vehicles[i].TypeOfVehicle = "car";
                    Vehicles[i].ParkingSlot = 0;
                    Vehicles[i].ParkTime = DateTime.Now.ToString();
                    Console.WriteLine("{0} blev utkörd från parkeringsplats {1}", regNr, i + 1);
                    found = true;



                    List<string> output = new List<string>();
                    foreach (var vechile in Vehicles)
                    {
                        output.Add($"{vechile.RegNr},{vechile.TypeOfVehicle},{vechile.ParkingSlot},{vechile.ParkTime}");
                    }
                    File.WriteAllLines(filePath, output);
                    ReadFromDataBase();
                    break;
                }
            }
            if (found == false)
            {
                Console.WriteLine("{0} är inte parkerad här", regNr);
                Console.Beep(800, 100);
                Console.Beep(750, 100);
                Console.Beep(700, 100);
            }
        }

        static void ReadFromDataBase()
        {
            Vehicles.Clear();
            List<string> lines = File.ReadAllLines(filePath).ToList();
            foreach(var line in lines)
            {
                string[] entries = line.Split(',');
                ParkVehicle newParkVehicle = new ParkVehicle();
                newParkVehicle.RegNr = entries[0];
                newParkVehicle.TypeOfVehicle = entries[1];
                newParkVehicle.ParkingSlot = int.Parse(entries[2]);
                newParkVehicle.ParkTime = entries[3];
                Vehicles.Add(newParkVehicle);
            } 
        }

        static void VacantPlaces()
        {
            //int places = Vehicles.Count();
            //int freeplaces = 100 - places;

            int places = 0;
            int freeplaces = 0;

            

            for (int i = 0; i <Vehicles.Count; i++)
            {
                if (Vehicles[i].RegNr != "0")
                {
                    places++;
                }
                else
                {
                    freeplaces++;
                }
            }

           
            Console.WriteLine("Occupied places: {0}/100", places);

            if (freeplaces > 31)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Vacant Places: {0}/100", freeplaces);
                Console.ForegroundColor = ConsoleColor.White;
            }
            if (freeplaces <= 30 & freeplaces > 20)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Vacant Places: {0}/100", freeplaces);
                Console.ForegroundColor = ConsoleColor.White;
            }
            if (freeplaces <= 20 & freeplaces > 10)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Vacant Places: {0}/100", freeplaces);
                Console.ForegroundColor = ConsoleColor.White;
            }
            if (freeplaces <= 10)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Vacant Places: {0}/100", freeplaces);
                Console.ForegroundColor = ConsoleColor.White;
            }


        }

        static void BackToMenu()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            MenuChoise();
        }

    }
}
