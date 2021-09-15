using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesDemo.Model
{
    public class DogModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Cuteness { get; set; }
    }
}
