using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // genericleri metot için kulnanacağız
            Utilities utilities = new Utilities();
            List<string> result = utilities.BuildList<string>("Ankara", "İzmir", "Adana");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            List<Customer> result2 = utilities.BuildList<Customer>(new Customer { FirsName="Abdullah"}, new Customer { FirsName="Boz"});
            foreach (var customer in result2)
            {
                Console.WriteLine(customer.FirsName);
            }
            Console.ReadLine();
        }
    }
    class Utilities
    {
        public List<T> BuildList<T>(params T[] items)
            // T olarak bir metot yazdık. Buradaki T artık bir dönüş tipi olarak kullanılabilir, parametrelerde de kullanılabilir. metodun içinde de kullanılabilir.
        {
            return new List<T>(items);
        }
    }

    class Product: IEntity
    {

    }

    interface IProductDal:IRepository<Product>
    {
     
    }
    class Customer: IEntity
    {
        public string FirsName { get; set; }
    }
    interface ICustomerDal:IRepository<Customer>
    {
        
    }
    interface IStudentDal : IRepository<Student>
    {

    }
    class Student: IEntity
    {

    }
    interface IEntity
    {
        //IEntity'den implemente edilen bir sınıf veritabanı nesnesidir diyoruz.
    }

    interface IRepository<T> where T : class,IEntity,new() // Sadece değer tipi koymak isteseydik struct dememiz yeterliydi.
        // yazılan referans tip olmalıdır. class demek değildir. // newlenebilmelidir. new sona gelmelidir.  // Bu nesnemiz IEntityden implemente ediliyor olmalı diyoruz. Kısıt koyuyoruz.
        // yazacağımız list'ler farklı claslarda da benzer ise generic oluşturup 
        // bir class haline getirebiliriz.
        // aşağıda T = Type bu yazdığımız kod bloğu hem customer hem product için geçerlidir.
        // kısıtlama yapabiliriz. 
    {
        List<T> GetAll();
        T Get(int id);
        void Add(T entity);
        void Delet(T entity);
        void Update(T entity);
    }
    class ProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delet(Product entity)
        {
            throw new NotImplementedException();
        }

        public Product Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
    class CustomerDal : ICustomerDal
    {
        public void Add(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void Delet(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
