using System;
using System.Collections.Generic;
using System.Text;

namespace Parking
{
    class ParkingSlot
    {
        int MaxSize { get; } = 4; 
        int Size { get; set; }

        List<Fordon> fordon = new List<Fordon>();



        public void ParkVehicle(Fordon fordon)
        {
            if(Size < MaxSize)
            {
                this.fordon.Add(fordon);
                Size = fordon.Size;
            }
            else
            {
                throw new Exception();
            }
        }

        public void RemoveVehicle(string regNr)
        {
            for(int i = 0; i < this.fordon.Count; i++)
            {
                if(this.fordon[i].RegNr == regNr)
                {
                    this.fordon[i].EndDate = DateTime.Now;
                    this.fordon.RemoveAt(i);
                    break;
                }
            }

            //kod för att fordonet inte hittades
        }
    }
}
