using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public delegate void StockControl();
    public class Product
    {
        private int _stock;
        public Product(int stock)
            // Veritabanından çektiğimizi varsayalım
            // bir stock gönderiyorum onuda _stock'u stock diye tanımlıyorum 
            // injection yapmış oluyoruz.
            // _stock'u kullanıyoruz.
        {
            _stock = stock;
        }

        public event StockControl StockControlEvent;
        // event tanımlıyoruz. Sonuna event yazıyoruz.
        public string ProductName { get; set; }

       
        public int Stock {
            get
            {
                return _stock;
            }
            set
            {
                _stock=value;
                if (value <= 15 && StockControlEvent!=null)
                    // stock 15'ten az kaldıysa ve
                    // stock nesnesine abone olunmuşsa (değer null olmamalı)
                {
                    StockControlEvent();
                    // Eventi tetikliyoruz.

                    /* Ürünü hem okuyabiliyoruz.
                     * Hem set edebiliyoruz.
                     * Aynı zaman koşul ekleyerek
                     * Stock 15'ten eşit veya küçük ise 
                     * ve StockControlEvent'imiz null değil yani ürüne abone olunmuşsa koşulumuzu çalıştırıyoruz.
                    */
                }

            } 
        }
        // Stock'u get ve set ediyoruz. Bu çerçevede bir event varsa bu seti genişletmemiz gerekiyor.

        public void Sell(int amount)
        {
            Stock -= amount;
            // stocktan kaçtane satış yaptıysak yani 50 ise 50=50-10 yani 40 kalacak.
            Console.WriteLine("{1} Stock amount : {0}", Stock,ProductName);
        }
    }
}
