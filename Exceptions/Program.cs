using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ExceptionIntro();
            //TryCatch();
            //ActionDemo();

            Func<int, int, int> add = Sum;
            Console.WriteLine(add(3,5));
          
            Func<int> getRandomNumber = delegate ()
            //parametresiz metotlara delegelik yapar ve int döndürür.
            {
                Random random = new Random();
                return random.Next(1,100);
            };
            Console.WriteLine(getRandomNumber());

            
            Func<int> getRandomNumber2 = () => new Random().Next(1,100);
            // getrandomnumber2 = parametresiz metoda delegate yapıyor. 2. yazım şeklidir.
            Thread.Sleep(1000);
            // Random sayıların aynı olmasını engelledik.
            /*Thread.Sleep yöntemi. 
             * yönteminin Thread.Sleep çağrılarak geçerli iş parçacığının milisaniye 
             * veya yönteme geçiş zaman aralığı için hemen engellemesi ve saat diliminin geri kalanını başka bir iş parçacığına verir. 
             * Bu aralık tamam olduktan sonra, uyku iş parçacığı yürütmeyi sürdürür.
             */
            Console.WriteLine(getRandomNumber2());
            // Action gibi bir func'ta gönderebiliriz ama Func'ın bir değeri return etmesi gerekiyor.
            




            Console.ReadKey();
        }
        static int Sum(int x, int y)
        {
            return x + y;
        }

        private static void HandleException(Action action) 
            //Action bir metot bloğuna karşılık gelir.
            // Void olanları çalıştırır ve bir mimaridir.
        {
            // bütün hatalar için kullanırız.
            // merkezi bir class'a koyarız ve kullanırız.
            // classımızı temel bir class yaparız inherit edip her yerde kullanabiliriz.
            try
            {
                action.Invoke();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                
            }
        }

        private static void ExceptionIntro()
        {
            try
            {
                string[] students = new string[3] { "Abdullah", "Boz", "Nazar" };
                students[3] = "Ahmet";
            }
            catch (IndexOutOfRangeException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (DivideByZeroException exception)  // Bu hatayı oluşuyorsa  
            {
                Console.WriteLine(exception.Message); // bu kod bloğu calışır. Bu hata oluşmuyorsa aşağıdaki expception çalışır.
            }
            catch (Exception exception)  // burada bir hata olduğunda exception nesnesine aktarılıyor.
            {
                // genelde bu message'yi kullanıcıya göstermeyiz loglarız.
                Console.WriteLine(exception.Message);
            }
        }
        private static void Find()
        {
            List<string> students = new List<string> { "Abdullah", "Boz", "Nazar" };
            students.Contains("Abdullah");
            if (!students.Contains("Ahmet"))
            {
                throw new RecordNotFoundException("Record not found!");
            }
            else
            {
                Console.WriteLine("Record Found!");
            }
        }
        private static void TryCatch()
        {

            try
            {
                Find();
            }
            catch (RecordNotFoundException exception)
            {
                Console.WriteLine(exception.Message);
            }
            // yukarıdaki metodu aşağıda action ile gönderiyoruz.
            // actionuda invoke ediyoruz.
        }
        private static void ActionDemo()
        {
            HandleException(() =>
            // temiz görüntü için kullanıyoruz.
            {
                Find();
            }
          );
        }
    }
}
