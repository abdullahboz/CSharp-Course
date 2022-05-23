using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualMethods
{
    /* Virtual Methods
     * Override edebiliyoruz.
     * inheritance yaptığımız bir ortamda ortak kodu değiştirmemiz gerekirse virtualle diğer classta override edip değiştirebiliyoruz.
     * interface inheritance kullanımı arasında kalırsak virtual yardımcı oluyor.
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlServer sqlServer = new SqlServer();

            sqlServer.Add();
            sqlServer.Delete();

            MySql mySql = new MySql();

            mySql.Add();
            mySql.Delete();

            Console.ReadLine();
        }
        class Database
        {
            public virtual void Add()
            {
                Console.WriteLine("Added by defauld");
            }
            public virtual void Delete()
            {
                Console.WriteLine("Deleted by defauld");
            }
        }
        class SqlServer : Database
        {
            public override void Add()
            {
                Console.WriteLine("Added Sql server by Code");
                //base.Add();
            }
            public override void Delete()
            {
                Console.WriteLine("Deleted Sql server by Code");
                //base.Delete();
            }
        }
        class MySql : Database
        {
           
        }
    }
}
