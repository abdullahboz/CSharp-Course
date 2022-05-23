using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccessModifiers; // <--- Burada ekledik 

namespace AccesModifiersDemo
{
    /*Başka bir projedeki sınıfı kullanmak istiyorsak using yapmamız lazım ve diğer projedeki class ı public yapmamız gerekir.
     * 
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            Course couse = new Course();
        }
    }
}
