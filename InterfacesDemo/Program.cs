using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesDemo
{
    internal class Program
    {
        /* Bu örneğimiz de diyelim ki bir şirket var
         * çeşitli çalışanlar var bunlar;
         * işçiler, yöneticiler ve robotlar
         * bu bakımdan baktığımızda bunların hepsi Interface Olarak IWorkerdir.
         * IWorker class'ına eat, work, salary olarak üçünü koyarsak yönetici ve işçi için uyumlu olur ama
         * Robot yemek yemez ve maaş almaz ama çalışır.
         * Bunu robot class'ında eat ve salary boş bırakabiliriz ya ad
         * Birden fazla interface oluştururuz; IWork, IEat, ISalary gibi.
         * bu yaptığımız kodlama ile yapılması gerekeni yapması gerekenler yapmış oldu.
         
         */
        static void Main(string[] args)
        {
            // IWorker classımız dan 3 elemanlı dizi oluşturup içlerine şirketteki elemanları atadık.
            IWorker[] workers = new IWorker[3] {new Manager(), new Worker(), new Robot(),};
            // foreach ile o elemanları çalıştırdık.
            foreach (var worker in workers)
            {
                worker.Work();
            }
            // şirkette robot yemek yemediği için 2 elemanlı bir nesne oluşturduk.
            // işçi ve yöneticiye yemek yedirdik.
            IEat[] eats = new IEat[2] {new Manager(), new Worker(),};
            foreach (var worker in eats)
            {
                worker.Eat();
            }
            // maaş alan iki kişi vardı iki elemanlı nesnemizi oluşturduk.
            ISalary[] GetSalary = new ISalary[2] {new Manager(), new Worker(),};
            //elemanlara maaş verdik.
            foreach (var worker in GetSalary)
            {
                worker.GetSalary();
            }
            Console.ReadKey();
        }
        interface IWorker
        {
            void Work();        
        }
        interface IEat
        {
            void Eat();
        }
        interface ISalary
        {
            void GetSalary();
        }
        class Manager : IWorker, IEat, ISalary
        {
            public void Eat()
            {
                Console.WriteLine("Eat Manager");
            }

            public void GetSalary()
            {
                Console.WriteLine("Get Salary Manager");
            }

            public void Work()
            {
                Console.WriteLine("Work Manager");
            }
        }
        class Worker : IWorker, IEat, ISalary
        {
            public void Eat()
            {
                Console.WriteLine("Eat Worker");
            }

            public void GetSalary()
            {
                Console.WriteLine("Get Salary Worker");
            }

            public void Work()
            {
                Console.WriteLine("Work");
            }
        }
        class Robot : IWorker
        {
            public void Work()
            {
                Console.WriteLine("Work Robot");
            }
        }

    }
}
