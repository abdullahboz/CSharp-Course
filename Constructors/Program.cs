using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructors
{/*Constructors
  * Bir sınıf newlendiğinde çalışacak çalışacak kod bloğudur.
  */
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.List();

            Product product =new Product { Id=1,Name="Laptop"};
            Product product2 = new Product(2, "phone");
            // set etmemiz gerekiyor set etmemek için constructorla enjekte ediyoruz.
            EmployeeManager employeeManager = new EmployeeManager(new Database()); // aşağıda oluşturduğumuz interface class sayesinde new database 'i tanımlayabiliyoruz.
            employeeManager.Add();

            PersonManager personManager = new PersonManager("Product");
            personManager.Add();

            Teacher.Number = 10;
            Utilities.Validate();
            Manager.DoSomething();
            Manager manager = new Manager();
            manager.Dosomething2();
            Console.ReadKey();
        }
        class CustomerManager
        {
            private int _count=15; // hiçbirşey verilmezse 15 verilirse verilen değer.
            public CustomerManager(int count)
            {
                _count = count;
            }
            public CustomerManager()
            {

            }
            public void List()
            {
                Console.WriteLine("Listed {0} items",_count);
            }
            public void Add()
            {
                Console.WriteLine("Added!");
            }
        }
        class Product
        {
            public Product()
            {

            }
            private int _id;
            private string _name;
            public Product(int id, string name)
            {
                _id = id;
                _name = name;
            }
            public int Id { get; set; }
            public string Name { get; set; }
        }
        interface ILogger
        {
            void Log(); // Burada bir kaydedici constructors yazıyoruz. // Kaydedici interfacemizi aşağıdaki classlara implement ediyoruz.
        }
        class Database : ILogger
        {
            public void Log()
            {
                Console.WriteLine("Logged to database"); 
            }
        }
        class DatabaseLogger : ILogger
        {
            public void Log()
            {
                Console.WriteLine("Logged to database");
            }
        }
        class FileLogger : ILogger
        {
            public void Log()
            {
                Console.WriteLine("Logged to file");
            }
        }
        class EmployeeManager
        {
            private ILogger _logger;
            public EmployeeManager(ILogger logger) // burada _logger tanımlayıp onu logger'a atıyoruz.
            {
                _logger = logger;
            }
            public void Add()
            {
                _logger.Log();
                Console.WriteLine("Added!");
            }
        }
        class BaseClass
        {
            private string _entity;

            public BaseClass(string entity)
            {
                _entity = entity;
            }
            public void Message()
            {
                Console.WriteLine("{0} message",_entity);
            }
        }
        class PersonManager : BaseClass
        {
            public PersonManager(string entity):base(entity)
            {

            }
            public void Add()
            {
                Console.WriteLine("Added!");
                Message();
            }
        }

 
        static class Teacher
        {       // static nesnelerde new leyemezsiniz. Arkaplanda tekbir nesne oluşturulur.
                // static nesneler ortak nesnelerdir herkes kullanabilir. Genelde yazılımcılar uzak durmaya calısır.
            public static int Number { get; set; }
        }
        static class Utilities
        {
            static Utilities()
            {
                //static bir nesnede mutlaka calısmasını istediğiniz bir kod bloğunu bu şekilde yazabiliriz.
            }
            public static void Validate()
            {
                Console.WriteLine("Validation is done");
            }
        }
        
        
        class Manager
        {
            // Class'ı normal tanımlayıp bazı özellikleri static tanımlayabiliriz.
            // Singleton Design Pattern Araştırılması önerilir.
            // 1 sınıftan 1 nesne oluşturma mantığıyla oluşturulmuş bir dizayndır.
            // bir objenin tek olduğunu garanti eder.
            // sadece sınıfın istediği yerden ulaşabilelim.


            public static void DoSomething()
            {
                Console.WriteLine("Done");
            }
            public void Dosomething2()
            {
                Console.WriteLine("Done2");
            }
        }

    }
}
