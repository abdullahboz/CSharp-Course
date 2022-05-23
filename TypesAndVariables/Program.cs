using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypesAndVariables
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Value Types

            int number1 = 2147483647;
            long number2=9223372036854775807;
            short number3=32767;
            double number4=10.4;
            decimal number5=10.4m;
            byte number6=255;
            char character = 'A';
            bool condition = true;
            var number7=10;
            number7 = 'A'; // Burada char karakteri dönüşümü yapıyoruz.

            Console.WriteLine("Number 1 is {0} ", number1);
            Console.WriteLine("Number 2 is {0} ", number2);
            Console.WriteLine("Number 3 is {0} ", number3);
            Console.WriteLine("Number 4 is {0} ", number4);
            Console.WriteLine("Number 5 is {0} ", number5);
            Console.WriteLine("Number 6 is {0} ", number6);
            Console.WriteLine("Number 7 is {0} ", number7);
            Console.WriteLine("Character is {0} ",character);
            Console.WriteLine(Days.Friday);



            Console.ReadKey();
        }
        enum Days
        {
            Monday = 1, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
        }
    }
}
