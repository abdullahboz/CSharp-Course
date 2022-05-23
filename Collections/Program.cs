using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Collections
{
    internal class Program
    {
        /* Dizilerde karşımıza çıkan diziyi büyütmek için kullanılan new'leme komutu ve bu komut yüzünden eski dizinin kaybolması durumundan yola çıkılarak oluşturulmuştur.
         *Yazılımda görüyoruz ki her bir metot, class gibi kullanımlar gereksinimlere göre ortaya çıkmaktadır. 
         *Günümüz projelerinde neredeyse hiç array kullanılmıyor.
         * Ben bir koleksiyon oluşturmak istiyorum.Dizi temmellidir fakat ben bu koleksiyonda sadece ve sadece stringle çalışmak istiyorum demiş olduk.
         * Projelerde çok az string listelerle çalışılır genelde aşağıdaki oluşturduğumuz metot gibi çalışılı
         *
         */
        static void Main(string[] args)
        {
            //ArrayList();
            //List();


            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            {         //nesneyi tutup anahtar yerine kullanırız.
                      //string yerine Id, ikinci string yerine customer tutabiliriz.

                // Sözlük demektir aynı bir sözlük gibi anahtar bir kelime kullanarak onun değerine ulaşmayı hedefleriz. - kelime computer değeri bilgisayar gibi.
                // dictionary bir koleksiyondur. count gibi komutları kullanabiliriz.
                dictionary.Add("book", "kitap");
                dictionary.Add("table", "tablo");
                dictionary.Add("computer", "bilgisayar");
            };
            //Console.WriteLine(dictionary["table"]);
            foreach (var item in dictionary)
            {
                Console.WriteLine(item.Value);
            }
            Console.WriteLine(dictionary.ContainsKey("glass"));
            Console.WriteLine(dictionary.ContainsKey("table"));
            
             

            Console.ReadLine();
        }
        class Customer
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
        }

        private static void ArrayList()
        {
            // yani sıfırdan bir nesne oluşturmuş oluyoruz.,
            //ArrayList'te tip güvenli değildir aynı arrayList'in içinde int, char , string kullanılabilir. Genelde tip güvenli sistemlerde çalışılır .
            ArrayList cities = new ArrayList();
            cities.Add("Ankara");
            cities.Add("İstanbul");
            cities.Add("Adana");
            cities.Add(1);
            cities.Add('A');
            foreach (var city in cities)
            {
                Console.WriteLine(city);
            }
            //Console.WriteLine(cities[2]);
        }
        private static void List()
        {
            List<string> cities = new List<string>();
            cities.Add("Ankara");
            cities.Add("İstanbul");

            Console.WriteLine(cities.Contains("İstanbul"));

            foreach (var city in cities)
            {
                Console.WriteLine(city);
            }

            // Nesnelerle çalışmamızın sebebi veritabanı ile çalışıyoruz, veritabanı tablolarının karşılığını bir listeye atar kullanıcıya gösteririz.

            //List<Customer> customers = new List<Customer>();
            //customers.Add(new Customer { Id = 1, FirstName = "Abdullah" });
            //customers.Add(new Customer { Id = 2, FirstName = "Boz" });
            // ------ İkinci yazım şekli -------
            List<Customer> customers = new List<Customer>
            {
                new Customer {Id = 1,FirstName= "Abdullah"},
                new Customer {Id = 2,FirstName= "Boz"}
            };

            var customer2 = new Customer() // ikinci sırada aşağıda kontrolünü yaptık.

            {
                Id = 3,
                FirstName = "Nazar"
            };

            customers.Add(customer2); // farklı yolla ekledik.
            customers.AddRange(new Customer[2] // Liste veya array eklemek için kullanılır. // bunuda elimizde bir liste var ve veritabanından bir liste geldi onu eklemek için kullanırız.
            {
                new Customer {Id = 4,FirstName= "Ali" },
                new Customer {Id = 4,FirstName= "Ayşe" }
            });
            Console.WriteLine(customers.Contains(new Customer { Id = 1, FirstName = "Abdullah" })); // False olması lazım reference olayındaki gibi.
            Console.WriteLine(customers.Contains(customer2)); // False olması lazım reference olayındaki gibi.
                                                              //customers.Clear(); // listedeki elemanları siler.
            var index = customers.IndexOf(customer2); //listedeki elemanın kaçıncı sırada olduğunu verir. Aramaya baştan başlar.
            Console.WriteLine("----Index: {0}", index);

            customers.Add(customer2);
            var index2 = customers.LastIndexOf(customer2); // son eklenen elemanı gösterir. Aramaya sondan başlar.
            Console.WriteLine("*** Index: {0}", index2);

            customers.Insert(0, customer2); // Kaçıncı sıraya neyi eklemek istiyoruz. Add en sona ekler insert istediğimiz yere ekleriz.

            customers.Remove(customer2); // Remove bulduğu ilk değeri uçurur ve sona erer.

            customers.RemoveAll(c => c.FirstName == "Nazar"); // predicate denir bu işleme. Belirtilen yüklem tarafından tanımlanan koşullarla eşleşen tüm öğeleri kaldırmak için kullanılır.

            foreach (var customer in customers)
            {
                Console.WriteLine(customer.FirstName);
            }
            var count = customers.Count(); // Listedeki elemanların sayısını buluruz.
            Console.WriteLine("Count : {0} ", count);
        }
    }
}
