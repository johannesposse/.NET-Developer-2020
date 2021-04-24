using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitryFramework_Uppgift1
{
    public class Course
    {
        public int Id { get; set; }
        public string CoursName { get; set; }
        public virtual ICollection<Student> students { get; set; }
    }
}
