using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    class VolvoV70 : Car
    {
        private string name;
        public VolvoV70()
        {
            name = "Volvo V70";
        }
        public string Name
        {
            get { return name; }
        }
        public override string ToString()
        {
            return string.Format("Volvo V70");
        }
    }
}
