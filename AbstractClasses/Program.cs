using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClasses
{
    /* Abstraact Classses
     * Bu senaryomuzda diyelim ki ekleme bütün her yerde aynı ama
     * Silme işlemi farklı (unutmayalımki bu bir senaryo)
     * Abstract ile hem tamamlanmış metotlar hemde tamamlanmamış metotlar yapabiliyoruz.
     * Abstract metot aslında içi dolu olmayan virtual metottur diyebiliriz.
     * İnterfaceler gibi abstract metotları new leyemeyiz.
     * Abstract classlarda birer inheritancedir.  implement özellikleri aynıdır.
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            Database database = new Oracle();
            database.Add();
            database.Delete();

            Database database2 = new SqlServer();
            database2.Add();
            database2.Delete();

            Console.ReadLine();
        }
        abstract class Database
        {
            public void Add()
            {
                Console.WriteLine("Added by defauld");
            }
            public abstract void Delete();
        }
        class SqlServer : Database
        {
            public override void Delete()
            {
                Console.WriteLine("Deleted by Sql");
            }
        }
        class Oracle : Database
        {
            public override void Delete()
            {
                Console.WriteLine("Deleted by Oracle");
            }
        }
    }
}
