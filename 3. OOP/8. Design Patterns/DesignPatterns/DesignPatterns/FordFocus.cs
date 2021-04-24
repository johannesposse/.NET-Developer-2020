using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    class FordFocus : Car
    {
        private string name;
        public FordFocus()
        {
            name = "Ford Focus";
        }
        public string Name
        {
            get { return name; }
        }
        public override string ToString()
        {
            return string.Format("Ford Focus");
        }
    }
}
