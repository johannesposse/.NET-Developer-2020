using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX2
{
    class Student : Human
    {
        public int grade { get; private set; }

        public Student (string firstName, string lastName, int grade) : base (firstName, lastName)
        {
            this.grade = grade;
        }


        public override string ToString()
        {
            return $"Name:\t {this.firstName} {this.lastName}\nGrade:\t {this.grade}\n";
        }
    }
}
