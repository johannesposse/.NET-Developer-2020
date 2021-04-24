using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_Klocka
{
    class Visare
    {
        int counter = 0;

        public void KlockLyssnare(object sender, TickEventArgs e)
        {
            counter++;
            
            Console.CursorVisible = false;

            if(counter % 10 == 0 & counter != 0)
            {
                Console.SetCursorPosition(10, 6);
                Console.WriteLine("Vill du avbryta? Tryck 'Y' för ja.");
                string input = Console.ReadLine();

                if (input == "y")
                    e.Cancel = true;

                Console.Clear();
            }
            else
            {
                if (sender != null)
                {
                    Console.SetCursorPosition(10, 5);
                    Console.WriteLine("Klockan är: " + e.ToString());
                }
            }

            
        }

    }
}
