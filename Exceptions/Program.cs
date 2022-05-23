using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ExceptionIntro();

            try
            {
                Find();
            }
            catch (RecordNotFoundException exception)
            {
                Console.WriteLine(exception.Message);
            }

            HandleException(() =>
            {
                Find();
            }
            );


            Console.ReadKey();
        }

        private static void HandleException(Action action)
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
    }
}
