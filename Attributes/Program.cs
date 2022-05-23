using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    internal class Program
    {
        // Attributes - Özenitelik C# Yapılarına uygulayabileceğimiz ayrıca yapılardır. Bu yapılar vasıtasıyla yapıya anlam katıyoruz. 
        static void Main(string[] args)
        {
            Customer customer = new Customer {Id = 1, LastName="Boz",Age=27 };
            CustomerDal customerDal = new CustomerDal();
            customerDal.Add(customer);


            Console.ReadLine();

        }
        [ToTable("Customers")] // bu yapı veri tabanında customers tablosuna denk gelir.  Dinamik yapılarda sorgular için kullanılır. // class'a attribute eklemiş olduk.
        class Customer
        {
            // Diyelim ki bu nesnelerin kullanıldığı ortamlarda first name'i girmek zorunlu olsun.
            // ilgili nesne için kural oluşturuyoruz.
            public int Id { get; set; }
            [RequiredProperty]
            public string FirtName { get; set; }
            [RequiredProperty]
            public string LastName { get; set; }
            [RequiredProperty]
            public int Age { get; set; }
        }
        [AttributeUsage(AttributeTargets.Property,AllowMultiple =true)] // bu aynı yerde fazlaca kullanabilir miyim diyoruz.
        // .Class deseydik sadece classlarda kullanılırdı. 
        // .Property dersek nesneler üstünde kullanılır.
        // .All ile heryer kullanabiliriz.
        class RequiredPropertyAttribute : Attribute
            // Attribute classların attribute olduklarını belli etmeliyiz ve Attribute'ten inherit etmeliyiz.
        {

        }
        [AttributeUsage(AttributeTargets.Class)]
        class ToTableAttribute : Attribute 
            // Attributelere parametre gönderebiliriz.
        {
            private string _tableName;
            public ToTableAttribute(string tableName)
            {
                _tableName = tableName;
            }
        }

        class CustomerDal
        {
            [Obsolete("Don't use Add, instead use AddNew Mothod!")] // Hazır Attribute         
            public void Add(Customer customer)
            {
                Console.WriteLine("{0}, {1}, {2}, {3} added!", customer.Id,customer.FirtName,customer.LastName,customer.Age);
            }
            public void AddNew(Customer customer)
            {
                Console.WriteLine("{0}, {1}, {2}, {3} added!", customer.Id, customer.FirtName, customer.LastName, customer.Age);
            }
        }
    }
}
