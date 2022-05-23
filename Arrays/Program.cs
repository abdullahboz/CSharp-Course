using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    internal class Program
    {
        // array ile aynı tipteki değişkenleri tutabiliriz.
        static void Main(string[] args)
        {
            //string[] students = new string[3];
            //students[0] = "Abdullah";
            //students[1] = "Boz";
            //students[2] = "Semra";

            //string[] students2 = new[] {"Abdullah","Boz","Semra"}; // Bu şekilde de tanımlayabiliriz.
            //string[] students3 = {"Abdullah","Boz","Semra"}; // Bu şekilde de tanımlayabiliriz.
            //string[] students4 = new string[3] {"Abdullah","Boz","Semra"}; // Bu şekilde de tanımlayabiliriz.

            //// Arraylari veri tabanından verileri çekmek için kullanırız.
            //// Gümüzde koleksiyonlar kullanılır.
            //foreach (var student in students)
            //{
            //    Console.WriteLine(student);
            //}
            //Çok boyutlu dizi
            string[,] regions = new string[5, 3]
            {
                {"İstanbul","İzmit","Balıkesir"},
                {"Ankara","Konya","Kırıkkale"},
                {"Antalya","Adana","Mersin"},
                {"Rize","Trabzon","Samsun"},
                {"İzmir","Muğla","Manisa"},              
            };
            for (int i = 0; i <= regions.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= regions.GetUpperBound(1); j++)
                {
                    Console.WriteLine(regions[i, j]);
                }
                Console.WriteLine("****************");
            }
            
            

            Console.ReadKey();
        }
    }
}
