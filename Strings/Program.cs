using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    internal class Program
    {
        // Metinsel tanımlar için kullanılır.
        // Stringler aslında char arraydir.
        // stringler toplanır ve yanyana yazılır.
        static void Main(string[] args)
        {
            //Intro();
            string sentence = "My name is Abdullah Boz";
            var result = sentence.Length;
            var result2 = sentence.Clone();
            var result3 = sentence.EndsWith("z");
            var result4 = sentence.StartsWith("M");
            var result5 = sentence.IndexOf("name");  // bulamazsa -1 döndürür. // bir metnin içinde bir ifade aramak için kullanılır.
            var result6 = sentence.IndexOf(" "); //Bulduğu ilk boşluğu kabul eder.
            var result7 = sentence.LastIndexOf(" "); //Aramaya sondan başlar
            var result8 = sentence.Insert(0, "Hello, "); // Cümlenin başına ekler.
            var result9 = sentence.Substring(3); // metni parçalarına ayırır ve orada alır. (3,4) = dersek 3.den sonra 4 tane al der.
            var result10 = sentence.ToLower(); //bütütn harfler küçük harfle yazılır.
            var result11 = sentence.ToUpper(); //bütün harfler büyük harfle yazılır.
            var result12 = sentence.Replace(" ","-"); // yani boşluk yerine çizgi koyar. değiştirir.
            var result13 = sentence.Remove(2); //den itibaren siler. (2,4) = 2 den sonra 4 tane kaldırır.


            Console.WriteLine(result14);
            Console.ReadLine();
        }
        private static void Intro()
        {
            string city = "İstanbul";
            //Console.WriteLine(city[0]);
            foreach (var item in city)
            {
                Console.WriteLine(item);
            }

            string city2 = "Ankara";
            Console.WriteLine(string.Format("{0} {1}", city, city2));
        }
    }
}
