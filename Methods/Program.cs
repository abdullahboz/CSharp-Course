using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    internal class Program
    {
        // Value type'lerde atamalar tamamen değerin kendisi ile ilgilidir. 
        // Ref keyword'ü değişken için bir adres oluşturur.
        // Out keyword'ü ref keywordünde bir değer vermek zorundasınız ama out keyword'ünde değer atamanıza gerek yoktur.
        // Out keyword'ü kullanıldığı metodun içinde set edilmek zorundadır.

        static void Main(string[] args)
        {
            //var result = Add2(2,4);
            //Console.WriteLine(result);

            //int number1 = 20; 
            //int number2 = 100;
            //var result2 = Add3(number1, number2);
            //Console.WriteLine(result2);
            //Console.WriteLine(number1);

            Console.WriteLine(Multiply(2, 4));
            Console.WriteLine(Multiply(2, 4,5));

            Console.WriteLine(Add4(1,2,3,4,5,6));

            Console.ReadKey();
        }
        static void Add()
        {
            Console.WriteLine("Added");
        }
        static int Add2(int number1, int number2) // parametreler number2=10 gibi default değer verebiliriz. metodun en sonunda olması gerekiyor.
        {
            var result = number1 + number2;
            return result;
            
        }
        // 
        static int Add3(int number1, int number2)
        {
            number1 = 30;
            return number1 + number2;
        }
        static int Multiply(int number1, int number2) // int'ten sonrası metodun imzasıdır. Aynı isimle bir meton oluşturulamaz ama overload edilebilir.
        {
            return number1* number2;
        }
        static int Multiply(int number1, int number2, int number3) // aynı isimli metodu overload edip, yani fazla yükleme yaparak kullanabildik. İmzayı değiştirmiş olduk.
        {
            return number1 * number2 * number3;
        }
        static int Add4(params int[] numbers)  // Paramsla metodumuza aynı tipte istediğimiz kadar parametre gönderebiliriz. // params metodun son parametresi olmak zorunda. 
        {
            return numbers.Sum();
        }
    }
}
