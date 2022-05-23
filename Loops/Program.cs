using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loops
{
    internal class Program
    {
        // Loops
        // Veri kümesini dolaşmak için kullanılan yapılara döngü denir.
        // örneğin 1'den yüze kadar sayıları yazdırın.
        static void Main(string[] args)
        {
            //ForLopp();
            //WhileLoop();
            //DoWhileLoop();
            //ForeachLoop();

            // Girilen bir sayının asal olup olmadığı bulan kod.
            //Benim yaptığım
            //int number;
            //Console.WriteLine("Bir sayı giriniz onun asal olup olmadığını söyleyeceğim: ");
            //number = Convert.ToInt32(Console.ReadLine());

            //if (number %2==0)
            //{
            //    Console.WriteLine("Girdiğiniz sayı asaldır.");
            //}
            //else { Console.WriteLine("Girdiğiniz sayıl asal değildir!"); }

            if (IsPrimeNumber(2))
            {
                Console.WriteLine("This is a prime number");
            }
            else 
            {
                Console.WriteLine("This is not a prime number");
            }


            Console.ReadLine();
        }
        // Hocanın yaptığı
        private static bool IsPrimeNumber(int number)
        {
            bool result = true;
            for (int i = 2; i < number; i++)
            {
                if (number %i == 0)
                {
                    result = false;
                    i = number;
                }

            }
            return result;
        }
        private static void ForLoop()
        {
            // int i = 1 : sadece for bloğunda kullanılır. başlangıçtır, sayactır.
            // 2. kısım şartımızdır. 
            // 3. kısım ise bir dönüş bittiğinde diğer dönüşte ne yapılacağını gösterir.
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine(i);
            }

        }
        private static void WhileLoop()
        {
            int number = 100;
            while (number >= 0)
            {
                Console.WriteLine(number);
                number--;
            }
            Console.WriteLine("Now number is {0}", number);
        }
        private static void DoWhileLoop()
        {
            // Şart sağlanmasa bile bir kere do ile döngüye bir kere girer.
            // kontrol için yapılabilir - yada yapılması gereken bir şey varsa bu teknik kullanılır ama genelde kullanılmaz.
            int number = 10;
            do
            {
                Console.WriteLine(number);
                number--;
            } while (number >= 11);

        }
        private static void ForeachLoop()
        {
            //Foreach tamamen koleksiyonlarda kullanılır.
            //Veritabanından bir tabloyu çektiğimizde tabloyu gezmek için kullanırız.
            string[] students = new[] { "Abdullah", "Boz", "Semra" };
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }

        }
    }
}
