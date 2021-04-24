using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX2
{
    class Program
    {
        static List<Student> student = new List<Student>();
        static List<Worker> worker = new List<Worker>();
        static void Main(string[] args)
        {
            AddStudent();
            OrderByGrade();
            AddWorker();
            OrderByMoneyPerHour();
            MergeLists();

            Console.ReadLine();
        }

        static void MergeLists()
        {
            List<Human> human = new List<Human>();

            for (int i = 0; i < student.Count; i++)
            {
                human.Add(student[i]);
            }

            for (int i = 0; i < worker.Count; i++)
            {
                human.Add(worker[i]);
            }

            var sortByName = human.OrderBy(x => x.firstName);
            foreach(var a in sortByName)
            {
                Console.WriteLine(a.ToString());
            }
            
        }
        static void AddWorker()
        {
            worker.Add(new Worker("Lars", "Larsson", 1000, 8));
            worker.Add(new Worker("Sven", "Larsson", 8000, 6));
            worker.Add(new Worker("Eva", "Larsson", 1500, 8));
        }
        static void OrderByMoneyPerHour()
        {
            var sortByMoneyPerHour = worker.OrderBy(x => x.MoneyPerHour());
            {
                //foreach (var a in sortByMoneyPerHour)
                //{
                //    Console.WriteLine(a.ToString()); ;
                //}
            }
        }
        static void AddStudent()
        {
            student.Add(new Student("Sven", "Svensson", 1));
            student.Add(new Student("Glen", "Glensson", 4));
            student.Add(new Student("Lena", "Lensson", 3));
            student.Add(new Student("Ivar", "Ivarssin", 5));
            student.Add(new Student("Malin", "Malinsson", 1));
            student.Add(new Student("Eva", "Evasson", 5));
            student.Add(new Student("Gert", "Gertsson", 3));
            student.Add(new Student("Patrik", "Patriksson", 1));
            student.Add(new Student("Rolf", "Rolfsson", 2));
            student.Add(new Student("Bert", "Bertsson", 4));
        }
        static void OrderByGrade()
        {
            var sortByGradeList = student.OrderBy(x => x.grade).ToList();
            //for (int i = 0; i < sortByGradeList.Count; i++)
            //{
            //    Console.WriteLine(sortByGradeList[i].ToString());
            //}
        }
    }
}
