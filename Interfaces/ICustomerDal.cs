using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    /* Gerçek uygulamalarda SQL MYSQL ORACLE destekli bir yazılım yazıyorsanız.
     * Interfaceleri her biri için implement etmeniz gerekir.
     * Bu şekilde projemiz sadece sql'e yada başka bir veritabanına bağlı kalmıyor.
     * ****************************************************************************
     * Polimorpism ÇOK BİÇİMLİLİK ANLAMINA GELİR
     * bir nesneyi farklı amaçlarla implement edip  bu implementasyonların tamamına veya belli bir kısmına ulaşmaktır.
     * burada polimorphism yaptık IcustomerDal 'ı sql ve oracle biçiminde implement ettik.
    */
     interface ICustomerDal
    {
        void Add();
        void Update();
        void Delete();
    }
    class SqlServerCustomerDal : ICustomerDal //implement ediyoruz.
    {
        public void Add()
        {
            Console.WriteLine("Sql added");
        }

        public void Delete()
        {
            Console.WriteLine("Sql delete");
        }

        public void Update()
        {
            Console.WriteLine("Sql Update");
        }
    }
    class OracleCustomerDal : ICustomerDal //implemen ediyoruz.
    {
        public void Add()
        {
            Console.WriteLine("Oracle added");
        }

        public void Delete()
        {
            Console.WriteLine("Oracle delete");
        }

        public void Update()
        {
            Console.WriteLine("Oracle update");
        }
    }
    class MySqlCustomerDal : ICustomerDal //implemen ediyoruz.
    {
        public void Add()
        {
            Console.WriteLine("MySql added");
        }

        public void Delete()
        {
            Console.WriteLine("MySql delete");
        }

        public void Update()
        {
            Console.WriteLine("MySql update");
        }
    }

    class CustomerManager
    {
        public void Add(ICustomerDal customerDal) // Parametre olarak veriyoruz.
        {
            customerDal.Add();
        }
    }
}
