using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    internal class Program
    {
        // eventleri programda bir hareket olduğunda dönüt almak için kullanıyoruz.
        // büyük projelerde onlarca if kullanmak yerine eventleri kullanmak daha mantıklıdır.
        // eventler aslında bir delegedir.

        /*
         * FormApp'te form'a bir button ekledikten sonra
         * çift tıkladığımızda bir button click eventi oluşturuyoruz mutlaka görmüşsünüzdür.
         * designer kısmına gidip baktığımızda eventi kayıt ediyor += ile bakabilirsiniz.
         */
        static void Main(string[] args)
        {
            Product harddisk = new Product(50);
            harddisk.ProductName = "Hard Disk";

            Product gsm = new Product(50);
            gsm.ProductName = "GSM";
            gsm.StockControlEvent += Gsm_StockControlEvent;
            // Bu kısımda += dedikten sonra 2 kere tab tuşuna bastığınızda otomatik event metodu oluşturulur.
            for (int i = 0; i < 10; i++)
            {
                harddisk.Sell(10);
                gsm.Sell(10);
                Console.ReadLine();
            }

            Console.ReadLine();
        }

        private static void Gsm_StockControlEvent()
        {
            Console.WriteLine("Gsm about to finish!");
        }
    }
}
