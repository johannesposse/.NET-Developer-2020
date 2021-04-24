using System;
using System.Linq;

namespace EntitryFramework_Uppgift1
{
    class Program
    {
        static SchoolContext school = new SchoolContext();
        static void Main(string[] args)
        {

            var courses = school.Courses.Where(x => x.CoursName == "Swedish").First();
            var student = school.students.Where(x => x.Name == "Johannes").First();
            courses.students.Add(student);
            Menu();
        }

        private static void Menu()
        {
            Console.Clear();
            Console.WriteLine($"1. Add student\n2. Add Course\n3.Show students and courses");
            int menu = int.Parse(Console.ReadLine());

            if (menu == 1)
                AddStudent();
            else if (menu == 2)
                AddCourse();
            else if (menu == 3)
                Show();
        }

        private static void Show()
        {
            var students = school.students;
            var courses = school.Courses;

            foreach(var s in students)
            {
                Console.WriteLine($"{s.Name,-10} {s.Age}");
            }
            foreach(var c in courses)
            {
                Console.WriteLine($"{c.CoursName,-10}");
            }

            Console.ReadLine();
            Menu();
        }

        private static void AddCourse()
        {
            Console.Write("Enter name: ");
            var name = Console.ReadLine();
            
            var course = school.Courses;
            course.Add(new Course() { CoursName = name});
            school.SaveChanges();

            Menu();
        }

        private static void AddStudent()
        {
            Console.Write("Enter Name: ");
            var name = Console.ReadLine();
            Console.Write("Enter Age: ");
            var age = int.Parse(Console.ReadLine());
            var student = school.students;
            student.Add(new Student(){Name = name, Age=age});
            school.SaveChanges();

            Menu();
        }
    }
}
