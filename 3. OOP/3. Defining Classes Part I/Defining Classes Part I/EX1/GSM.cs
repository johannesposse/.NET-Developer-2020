using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX1
{
    class GSM
    {
        private static GSM iPhone4S = new GSM("iPhone 4S", "Apple", 6000, "Unknown", "Apple", 15, 7, 2,4.5,15);
        public static GSM IPhone4S
        {
            get { return iPhone4S; }
        }

        private MobilPhone mobile;
        private Battery battery;
        private Display display;
        private List<Call> callHistory = new List<Call>();

        public GSM(string model, string manufacturer, int price, string owner, string batteryModel, int batteryHoursIdle, int batteryHoursTalk, int batteryType, double displaySize, int displayColour)
        {
            mobile = new MobilPhone(model,manufacturer, price, owner);
            battery = new Battery(batteryModel, batteryHoursIdle, batteryHoursTalk,batteryType);
            display = new Display(displaySize, displayColour);
        }
        public GSM(string model, string manufacturer) : this(model, manufacturer, 0, null, null, 0, 0, 0,0,0)
        {
        }
        public GSM() { }

        public void AddCall(DateTime date, string phoneNumber, double duration)
        {
            callHistory.Add(new Call(date, phoneNumber, duration));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n<<<<<<<<<<< Calls made >>>>>>>>>>>");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Called:\t\t {phoneNumber}");
        }
        public void DeleteCall(string phoneNumber)
        {
            double longest = 0;
            for (int i=0; i<callHistory.Count; i++)
            {
                if (phoneNumber == callHistory[i].PhoneNumber) 
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n<<<<<<<<<<< Calls removed >>>>>>>>>>>");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Removed:\t\t {callHistory[i].PhoneNumber}");
                    callHistory.RemoveAt(i);
                } 
            }
            if (phoneNumber == "delete longest call")
            {
                for (int i = 0; i < callHistory.Count-1; i++)
                {
                    if (callHistory[i].Duration > longest)
                        longest = callHistory[i].Duration;
                }
                for (int i = 0; i < callHistory.Count; i++)
                {
                    if (callHistory[i].Duration == longest)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n<<<<<<<<<<< Calls removed >>>>>>>>>>>");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"Removed longest call:\t {callHistory[i].PhoneNumber}, {callHistory[i].Duration} min");
                        callHistory.RemoveAt(i);
                    }   
                }
            }
        }

        public void PrintCall()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n<<<<<<<<<<< Call List >>>>>>>>>>>");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Owner:\t\t {mobile.Owner}\n");
            if (callHistory.Count == 0)
                Console.WriteLine("No calls found");
            else
            {
                foreach (var call in callHistory)
                    Console.WriteLine(call);
            }
        } 
        public void CallPrice()
        {
            double pricePerMinute = 0.37;
            double price = 0;
            double totalPrice = 0;
            double totalDuration = 0;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n<<<<<<<<<<< Call Price >>>>>>>>>>>");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Owner:\t\t {mobile.Owner}\n");
            
            for (int i =0; i<callHistory.Count; i++)
            {
                totalDuration += callHistory[i].Duration;
                price = pricePerMinute * callHistory[i].Duration;
                price = Math.Round(price, 2);
                totalPrice += price;
                Console.WriteLine($"Call {i+1}:\t\t {callHistory[i].Duration} min");
            }
            Console.WriteLine("\nTotal duration:\t " + totalDuration + " min");
            Console.WriteLine("Price per min:\t " + pricePerMinute + " kr");
            totalPrice = Math.Round(totalPrice, 2);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Total price:\t {totalPrice} kr");
        }
        public void ClearCallHistory()
        {
            callHistory.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n<<<<<<<<<<< List cleared >>>>>>>>>>>");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public override string ToString()
        {
            StringBuilder mobileInfo = new StringBuilder();
            mobileInfo.Append($"\n<<<<<<<<<<<<<< Info >>>>>>>>>>>>>>\n");
            mobileInfo.Append($"Model:\t\t {mobile.Model}\nManufacturer:\t {mobile.Manufacturer}\nPrice:\t\t {mobile.Price}\nOwner:\t\t {mobile.Owner}\n\n");
            mobileInfo.Append($"Battery\nModel:\t\t {battery.BatteryModel}\nHours Idle:\t {battery.BatteryHoursIdle}\nHours Talk:\t {battery.BatteryHoursTalk}\nType:\t\t {battery.BatteryTypes}\n\n");
            mobileInfo.Append($"Display\nDisplay Size:\t {display.DisplaySize}\nDisplay Colour:\t {display.DisplayColour}");
            return mobileInfo.ToString();
        }
    }
}
