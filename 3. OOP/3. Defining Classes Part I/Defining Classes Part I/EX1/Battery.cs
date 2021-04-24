using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX1
{
    class Battery
    {
        public enum BatteryType
        {
            LiLion, NiMH, NiCd
        }
        private BatteryType batteryType;
        private string batteryModel;
        private int batteryHoursIdle;
        private int batteryHoursTalk;

        public BatteryType BatteryTypes
        {
            get { return this.batteryType; }
        }

        public string BatteryModel
        {
            get { return this.batteryModel; }
        }

        public int BatteryHoursIdle
        {
            get { return this.batteryHoursIdle; }
        }
        public int BatteryHoursTalk
        {
            get { return this.batteryHoursTalk; }
        }

        public Battery() { }
        public Battery(string batteryModel, int batteryHoursIdle, int batteryHoursTalk, int batteryType)
        {
            this.batteryModel = batteryModel;
            this.batteryHoursIdle = batteryHoursIdle;
            this.batteryHoursTalk = batteryHoursTalk;
            this.batteryType = (BatteryType)batteryType;
        }
    }
}
