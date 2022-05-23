using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    internal class Program
    {
        /* Reflection
         * Reflection ile uygulama çalışırken herhangi bir nesnenin hakkında bilgi toplayabilir ve çalıştırabilirsiniz.
         * Uygulama çalışırken nesnenin örneğini oluşturabiliyoruz. 
         * Çalışma anında kullanıcının girdiği değerlere göre hangi nesnenin hangi metodun çalışacağına karar verebiliriz.
         * Çalışma anında nesneler hakkında bilgi almak, özellikleri ve ettributes'leri hakkında bilgi almak için kullanılır.
         * Çalışma anında sorgu oluşturmak için kullanabiliriz.
         *Reflection tamamen ihtiyaçlar doğrultusunda yapılmalıdır. Pahalı bir şeydir yapılması gerekiyorsa yapılmalıdır.
         *bir nesneye ait özelliklere erişebiliyoruz.
         */
        static void Main(string[] args)
        {
            //DortIslem dortIslem = new DortIslem(2, 3);
            //Console.WriteLine(dortIslem.Sum2());
            //Console.WriteLine(dortIslem.Sum(3,4));

            //Reflection ile yapacağız yukarıdaki işlemleri
            var type = typeof(DortIslem);
            // Benim çalışacağım bir type var oda dortislemdir diyoruz. Dort işlemide parametrede alabiliriz.
            Activator.CreateInstance(type);
            // çalışma anında newlemiş oluyoruz diyebiliriz.
           // DortIslem dortIslem = (DortIslem)Activator.CreateInstance(type,6,7);
            //activator.createInstance obje döndürür.
            //Console.WriteLine(dortIslem.Sum(4, 5));
            //Console.WriteLine(dortIslem.Sum2());

            var instance = Activator.CreateInstance(type,6,5);

            //Console.WriteLine(instance.GetType().GetMethod("Sum2").Invoke(instance,null));
            // get methodla istediğimiz metoda ulaşıyoruz. Invoke ile metodu çalıştırıyoruz.
            
            MethodInfo methodInfo = instance.GetType().GetMethod("Sum2");
            // burada metot bilgisi buluyoruz.
            methodInfo.Invoke(instance,null);
            // Invoke ile hangi çalıştırıyoruz.
            Console.WriteLine("---------------------------");
            ////Metotlara ulaşmak
            var methods = type.GetMethods();
            foreach (var info in methods)
            {
                Console.WriteLine("Method Name: {0}",info.Name);
                foreach (var parameterInfo in info.GetParameters())
                {
                    Console.WriteLine("Parameter: {0}", parameterInfo.Name);
                }
                foreach (var attribute in info.GetCustomAttributes())
                {
                    Console.WriteLine("Attribute Name: {0}",attribute.GetType().Name);
                }
            }


            Console.ReadKey();
        }

    }
    class DortIslem
    {
        private int _number1;
        private int _number2;
        public DortIslem(int number1, int number2)
        {
            _number1 = number1;
            _number2 = number2;

            
        }

        public  DortIslem()
        {

        }

        public int Sum(int number1, int number2)
        {
            return number1 + number2;
        }
        public int Multiply(int number1, int number2)
        {
            return number1 * number2;
        }
        public int Sum2()
        {
            return _number1 + _number2;
        }
        [MethodName("********multiply*************")]
        public int Multiply2()
        {
            return _number1 * _number2;
        }

    }
    public class MethodNameAttribute : Attribute
    {
        public MethodNameAttribute(string name)
        {

        }
    }
}
