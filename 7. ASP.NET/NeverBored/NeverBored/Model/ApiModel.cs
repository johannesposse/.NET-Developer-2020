using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeverBored.Model
{
    public class ApiModel
    {
        public string Activity { get; set; }
        public decimal Accessibility { get; set; }
        public string Type { get; set; }
        public int Participants { get; set; }
        public decimal Price { get; set; }
        public string Link { get; set; }
        public string Key { get; set; }
    }
}
