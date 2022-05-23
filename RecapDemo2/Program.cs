using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecapDemo2
{
    internal class Program
    {/* Diyelim ki bir classımız var ve müşteri ile ilgili işlemleri gerçekleştiriyor.
      * Eğer ki bir class' interfacei ve ya base'i yoksa ondan korkun yoksa onu newleyip kullanabilirz.
      * Yeni bir loglama yapma ihtiyacımız olursa logları metin dosyasında loglamak istiyorum derse. 
      * gelip loggerları değiştirmemiz gerekir. sürdürebilir bir kod için classları çıplak bırakmamalıyız loglama işleminde mutlaka bir base'i olmalı.
      * yeni loglama stratejileri interface ile gerçekleştiriyoruz. kodlara baktığınızda // commend classların yerine anlatmak istediğim classları koyduğumuz fark edeceksiniz.
      * yani aşağıda sürdürebilir değiştirmeye gerek duyulmayan bir kod bloğu yazdık. 
      *
      */
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Logger = new DatabaseLogger();
            customerManager.Logger = new FileLogger();
            customerManager.Logger = new SmsLogger();
            customerManager.Add();

            Console.ReadLine();
        }
        class CustomerManager
        {
            public ILogger Logger { get; set; }
            public void Add()
            {
                //DatabaseLogger logger = new DatabaseLogger();
                //Logger logger = new Logger();
                Logger.Log();
                Console.WriteLine("Customer Added!");
            }
        }
        class DatabaseLogger : ILogger
        {
            public void Log()
            {
                Console.WriteLine("Logged to database!");
            }
        }
        class FileLogger : ILogger
        {
            public void Log()
            {
                Console.WriteLine("Logged to File!");
            }
        }
        class SmsLogger : ILogger
        {
            public void Log()
            {
                Console.WriteLine("Logged to Sms");
            }
        }

        /* class Logger
         {
             public void Log()
             {
                 Console.WriteLine("Logged!");
             }
         }*/
        interface ILogger
        {
            void Log();
        }
    }
}
