using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessModifiers
{/* Erişim bildirgeçleri
  * Private sadece tanımlandığı blok içerisinde kullanılır. İnherit edildiğinde kullanılmaz. İç içe classlarda private olabilir yoksa classlar private olamaz.
  * Protected inherit edildiği sınıflarda kullanılabilir. Private'ın aynı özelliğinde sadece inheritte kullanılabilir.
  * Internal bir class'ın defaulttudur. Bağlı olduğu asssembly içerisinde kullanabilirsiniz. Yani aynı projede kullanabilirsiniz.
  */
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
    class Customer
    {
        int id;
    }
    class Student
    {
        public void Save() // <--- Diğer projede kullanmak için public yaptık.
         {
            Customer customer = new Customer();
            
        }
    }
    public class Course
    {
        public string Name { get; set; }
    }
}
