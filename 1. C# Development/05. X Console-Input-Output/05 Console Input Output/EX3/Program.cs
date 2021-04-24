using System;

namespace EX3
{
    class Program
    {
        static void Main(string[] args)
        {
            //A company has name, address, phone number, fax number, web site and manager. 
            //The manager has first name, last name, age and a phone number. 
            //Write a program that reads the information about a company and its manager and prints them on the console.

            string[] info = { "Förnamn", "Efternamn", "Ålder", "Telefonnummer" };
            string[] info2 = { "Namn", "Adress", "Telefon", "Fax", "Hemsida", "Chef"};
            string[] employeInfo =  {"Johannes", "Posse", "27", "0725659465"};
            string[] companyInfo = { "Campus", "Varberg", "0340-12345", "555-12345", "campusvarberg.se", "Johannes Posse" };

            
     
           for (int i = 0; i <= 3; i++)
            {
                Console.WriteLine(info[i] + ": " +employeInfo[i]);
            }
            
            for (int j = 0; j <=5; j++)
            {
                Console.WriteLine(info2[j] + ": " + companyInfo[j]);
            }
           
            Console.ReadLine();

        }
    }
}
