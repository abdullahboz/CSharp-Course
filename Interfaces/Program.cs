using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal class Program
    {
        // I ile başlar
        // En büyük kullanım amacı bir temel nes oluşturup bütün nesneleri ondan implement etmektir.
        // İnterface soyut nesnedir. Tek başına anlam ifade etmez.
        // interfaceler yazılırken metodun imzası ile yazılır.
        /* Interfaceyi neden kullanıırız.
         * Bir interface newlenemez çünkü tek başına anlamı yoktur. -> Iperson person = new Iperson(); Soyut nesneler newlenemez.
         * 
        */
        static void Main(string[] args)
        {
            //InterfacesIntro();
            //Demo();

            // Senaryomuz şu sizin bir veriniz var ve bunu hem oracle veritabanına hem sql veritabanına yazmak istiyorsunuz.
            // iki elemanlı bir customerDals tanımladık 1. SqlServerCustomerDdal 2. OracleCostumerDal
            // Array olduğu için foreach ile gezeceğiz.
            ICustomerDal[] customerDals = new ICustomerDal[3] { new SqlServerCustomerDal(),new OracleCustomerDal(),new MySqlCustomerDal() };
            // burada hem oracle hem sql servere ekleme yaptık.
            // burada ki güzellik şudur diyelim Mysql'e ekleme yapıcaz.
            // Artık MYSQL'i de desteklemiş oluyoruz.
            foreach (var customerDal in customerDals)
            {
                customerDal.Add();
            }
           
            
            Console.ReadLine(); 
        }
        private static void Demo()
        {
            // Burada amac uygulamanın bağımlılıklarını minimize etmektir.
            CustomerManager customerManager = new CustomerManager();
            customerManager.Add(new SqlServerCustomerDal());
            customerManager.Add(new OracleCustomerDal());

        }
        private static void InterfacesIntro()
        {
            PersonManager manager = new PersonManager();
            //manager.Add(new Customer { Id = 1, FirtName = "Abdullah", LastName = "Boz", Address = "İstanbul" }); // ekleme çeşidi.
            //manager.Add(new Student(){Id=1,FirtName="Abdullah",LastName="Boz",Departmant="Android Developer" }); //ekleme çeşidi.


            Customer customer = new Customer
            {
                Id = 1,
                FirtName = "Abdullah2",
                LastName = "Boz",
                Address = "İstanbul"
            };


            Student student = new Student()
            {
                Id = 1,
                FirtName = "Abdullah",
                LastName = "Boz",
                Departmant = "Mobile Application Developer/Android developer"

            };
            manager.Add(student);  // bu kısımda interface kullanıldı 
            manager.Add(customer); // bu kısımda interface kullanıldı
            manager.Add(new Worker { Id = 1, FirtName = "Abdullah3", LastName = "Boz", Departmant = "Project Asistant" }); ;

        }
        interface IPerson
        {
            // Her biri implement edilmelidir.
            int Id { get; set; }
            string FirtName { get; set; }
            string LastName { get; set; }
        }
        class Customer : IPerson
        {
            public int Id { get; set; }
            public string FirtName { get; set; }
            public string LastName { get; set; }
            // müşteriye ait ayrıca özellik
            public string Address { get; set; }
        }
        class Student : IPerson
        {
            public int Id { get; set; }
            public string FirtName { get; set; }
            public string LastName { get; set; }
            // öğrenciye ait ayrıca özellik.
            public string Departmant { get; set; }

        }
        class Worker : IPerson
        {
            public int Id { get; set; }
            public string FirtName { get; set; }
            public string LastName { get; set; }
            // öğrenciye ait ayrıca özellik.
            public string Departmant { get; set; }

        }
        class PersonManager
        {
            //nesne de parametre olabilir.
            public void Add(IPerson person) // Parametre olarak bir ekleme yapacağım bana parametre olarak bir müşteri nesnesi ver.
            {
                Console.WriteLine(person.FirtName); 
                // Burada person olarak inter face kullandığımız için yukarıda manager.Add(student yada customer ekleyebiliyoruz.)
            }
            // Katmanlar arası geçiş yaparken ve servis implementinde kullanılır.
        }
    }
}
