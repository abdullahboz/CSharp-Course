using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conditionals
{
    internal class Program
    {
        // crtl + k + j = Yorum satırı
        // ctrl + k + u = Yorum satırını geri al
        // ctrl + k bırak d = syntax düzenleme

        static void Main(string[] args)
        {
            var number = 96;

            if (number<100)
            {
                if (number>=90 && number <95)
                {
                    Console.WriteLine("Number is less than 90 or greater than 95");
                }
             
            }

            //if (number >=0 && number  <=100)
            //{
            //    Console.WriteLine("Number is between 0 -100");
            //}
            //else if (number>100 && number <= 200)
            //{
            //    Console.WriteLine("Number is between 101 -200");
            //}
            //else if (number > 200 || number <0)
            //{
            //    Console.WriteLine("Number is less than 0 or greater than 200");
            //}
            // else blogu yapmadık çünkü girmeme şansı yok. Şart sınırlarına girecek.


            //switch (number)
            //{
            //    case 10:
            //        Console.WriteLine("Swicth Number is 10");
            //        break;
            //    case 20:
            //        Console.WriteLine("Switch Number is 20");
            //        break;
            //    default:
            //        Console.WriteLine("Switch Number is not 10 or 20");
            //        break;

            //}
            //if (number == 10) { Console.WriteLine("Number is 10"); }
            //else if (number == 20) { Console.WriteLine("Number is not 20"); }
            //else { Console.WriteLine("Number isn't 10"); }
            //Else olması lazım çünkü hiçbiri çalışmazsa çalışacak bir şeyin olması lazım.


            //Kullanılan şart bloğu
            //Console.WriteLine(number==10 ? "Number is 10" : "Number is not 10");
            // sayı 10sa ? şart doğruysa bu yanlışsa : bu diye kullanıyoruz. // Single line if yazım tekniği



            Console.ReadLine();
        }
    }
}
