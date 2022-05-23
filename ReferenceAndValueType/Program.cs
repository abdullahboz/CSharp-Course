using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceAndValueType
{
    internal class Program
    {
        /* 
         * 
         */
        static void Main(string[] args)
        {
            int number1 = 10;
            int number2 = 20;
            number2 = number1; // number2 10 olarak kalacaktır.
            number1 = 30; // bunum number1'in number2'ye atanamasıyla alakası yoktur.
            Console.WriteLine(number2);

            string[] cities1 = new string[] { "Ankara", "İstanbul", "Bursa" }; //101 
            string[] cities2 = new string[] { "Samsun", "Bolu", "Şanlıurfa" }; //102
            cities2 = cities1; // bellekteki reference üzerinden gidiyor.  yani 102  101 oluyor.
            cities1[0] = "Değişti";
            Console.WriteLine(cities2[0]); //ekranda değişti yazar. 
            // newlemen bellekteki en pahalı işlemlerden biridir. 


            Console.ReadLine();
        }
    }
}
