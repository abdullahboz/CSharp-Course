using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    internal class Program
    {
        // yapmak istediğim işlemleri gruplara ayırmak için kullanılır.
        // Gruplama en temel unsurlardan biridir.
        // classlar property denen özellikler tutar.
        static void Main(string[] args)
        {
            // class oluşturulurken PascalCase ama onun örneği oluşturulurken camelCase kullanılır.
            CustomerManager customerManager = new CustomerManager();
            customerManager.Add();
            customerManager.Update();

            ProductManager productManager = new ProductManager();
            productManager.Add();
            productManager.Update();

            Customer customer = new Customer();
            customer.City = ("Abdullah"); // Değer vermek Set'tir.
            customer.Id = 1;
            customer.FirstName = ("Abdullah");
            customer.LastName = ("Boz");

            // ikinci kullanım
            Customer customer2 = new Customer
            {
                Id = 2, City = "İstabul", FirstName = "Abdullah", LastName = "Boz"
            };

            Console.WriteLine(customer2.FirstName); // Getirmek, okutmak Get'tir.

            Console.ReadKey();

        }
    }
}
