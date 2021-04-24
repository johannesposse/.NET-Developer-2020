using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_Klocka
{
    class Klocka
    {
        public event EventHandler<TickEventArgs> clock;
        public TickEventArgs tickEventArgs = new TickEventArgs(DateTime.Now);

        public void TheClock()
        {
            while (!tickEventArgs.Cancel)
            {
                tickEventArgs.Time = DateTime.Now;

                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter)
                    break;

                clock?.Invoke(this, tickEventArgs);
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
