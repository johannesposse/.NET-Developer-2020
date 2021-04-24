using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX1
{
    class Student : ICloneable, IComparable<Student>
    {
        public string FirstName { get; set; }
        string LastName;
        int SNN;
        string Adress;
        string MobilePhone;
        string Email;
        string Course;
        Speciality speciality;
        University university;
        Facualty facualty;
        
        enum Speciality { ShittyCode, GoodCode }
        enum University { TheGoodOne, TheBadOne}
        enum Facualty { One, TheOther}

        public Student(string firstName, string lastName, int SNN, string adress, string mobilePhone, string email, string course,int speciality, int university, int facualty)
        {
            FirstName = firstName;
            LastName = lastName;
            this.SNN = SNN;
            Adress = adress;
            MobilePhone = mobilePhone;
            Email = email;
            Course = course;
            this.speciality = (Speciality)speciality;
            this.university = (University)university;
            this.facualty = (Facualty)facualty;
        }
        public Student()
        {
             
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastName}\nSNN: {SNN}\nAdress: {Adress}\nPhone: {MobilePhone}\nEmail: {Email}\nCourse: {Course}\nSpeciality: {this.speciality}\nUniversity: {this.university}\nFacualty: {this.facualty}\n";
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public object Clone()
        {
            Student newStudent = new Student(FirstName,LastName,SNN,Adress,MobilePhone,Email,Course,(int)this.speciality, (int)this.university, (int)this.facualty);
            return newStudent;
              
        }

        public int CompareTo(Student b)
        {
            string nameOne = FirstName;
            string nameTwo = b.FirstName;
            for (int i = 0; i < FirstName.Length; i++)
            {
                if (nameOne[i] < nameTwo[i])
                {
                    Console.WriteLine($"{nameOne}\n{nameTwo}");
                    return 1;
                }
                else
                    Console.WriteLine($"{nameTwo}\n{nameOne}");
                return 2;
            }
            return 0;
        }

    }
}
