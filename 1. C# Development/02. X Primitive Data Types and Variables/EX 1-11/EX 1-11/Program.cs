using System;

namespace EX_1_11
{
    class Program
    {
        static void Main(string[] args)
        {
            /*EX1
            ushort num1 = 52130;
            sbyte num2 = -115;
            int num3 = 4825932;
            sbyte num4 = 97;
            short num5 = -10000;
            */

            /*EX2
            
            float num1 = 12.345f;
            double num2 = 8923.1234857d;
            float num3 = 3456.091f;
            double num4 = 32.567839023d;
            Console.WriteLine(num1);
            Console.WriteLine(num2);
            Console.WriteLine(num3);
            Console.WriteLine(num4);
            */
            
            //Man ska ta talen minus varandra och jämföra skillnaden? Behöver googla detta

            /*EX3 (5.3 ; 6.01) 🡪 false;  (5.00000001 ; 5.00000003) 🡪 true
            float num1, num2;
            float num3, num4;
            num1 = 5.3f;
            num2 = 6.01f;
            num3 = 5.00000001f;
            num4 = 5.00000003f;
            bool seq1, seq2;
            Console.WriteLine(num1);
            Console.WriteLine(num2);
            Console.WriteLine(num3);
            Console.WriteLine(num4);
            

            if (num1 == num2)
            {
                seq1 = true;
                Console.WriteLine(num1 + " är samma som " + num2 + ": " + seq1);
            }
            else
            {
                seq1 = false;
                Console.WriteLine(num1 + " är inte samma som " + num2 + ": " + seq1);
            }
                
            if (num3 == num4)
            {
                seq2 = true;
                Console.WriteLine(num3 + " är samma som " + num4 + ": " + seq2);
            }
            else
            {
                seq2 = false;
                Console.WriteLine(num3 + " är inte samma som " + num4 + ": " + seq1);
            }
            */
                

            /*EX4
            int num1Hex = 0XFE;
            Console.WriteLine(num1Hex);
            */

            /*EX5
            char charOne;
            charOne = '\u0048';
            int num1Hex = 0x48;
            Console.WriteLine(num1Hex);
            Console.WriteLine(charOne);
            */

            /*EX6
            bool isFemale;
            isFemale = false;
            Console.WriteLine("Är du kvinna: " + isFemale);
            */

            /*EX7
            string Hello, World;
            Hello = "Hello";
            World = "World";
            object HelloWorld = Hello + " " + World;
            string result = (string)HelloWorld;
            Console.WriteLine(result);
            */

            /*EX8
            string lineOne, lineTwo;
            lineOne = "The \u0022use\u0022 of quotations causes difficulties.";
            lineTwo =@"The ""use"" of quotations causes difficulties.";
            Console.WriteLine(lineOne);
            Console.WriteLine(lineTwo);
            */

            /*EX9
            char at = '\u00A9';
            Console.WriteLine("    " + at);
            Console.WriteLine("   " + at + "  " + at);
            Console.WriteLine("  " + at + "    " + at);
            Console.WriteLine(" " + at + "      "  + at);
            Console.WriteLine(at + "  " + at + "  " + at + "  " + at);
            */

            /*EX10
            string firstName, familyName;
            byte age;
            bool isFemale;
            int idNumber, uniqueEmpNumb;
            */

            /*EX11 Declare  two integer variables and assign them with 5 and 10 and after that exchange their values.
            int num1, num2, placeHolder1, placeHolder2;
            num1 = 5;
            num2 = 10;
            Console.WriteLine("Första värdet är: " + num1);
            Console.WriteLine("Andra värdet är: " + num2);
            placeHolder1 = num1;
            placeHolder2 = num2;
            Console.WriteLine("Byter plats på värdena");
            num1 = placeHolder2;
            num2 = placeHolder1;
            Console.WriteLine("Första värdet är: " + num1);
            Console.WriteLine("Andra värdet är: " + num2);
            */

            Console.Read();





        }
    }
}
