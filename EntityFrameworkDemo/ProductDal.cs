using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EntityFrameworkDemo
{
    public class ProductDal
    {
        public List<Product> GetAll()
        {
            using (ETradeContext context = new ETradeContext())
            // using ile metot bittiği zaman .Net'in memory yöneticisi garbage collector'u beklemeden nesneyi zorla bellekten atıyoruz.

            {
                return context.Products.ToList();
                // entity frameworkte tabloya erişme kodu bu kadardır.

            }
        }
        public List<Product> GetByName(string key)
        {
            using (ETradeContext context = new ETradeContext())
           

            {
                return context.Products.Where(p=>p.Name.Contains(key)).ToList();
                //direk veri tabanına where koşulu atıyoruz. tbxSearch'a GetAll'dan istemek yerine.
                // veritabanımızdan sadece ihtiyacımız olan datayı alırız.
                // tbxSearch click classına incelerseniz ne demek istediğimi anlayacaksınız.
                

            }
        }
        public List<Product> GetByUnitPrice(decimal price)
            // bu sorgumuzda fiyada göre arama yapacağız
        {
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.Where(p => p.UnitPrice >= price).ToList();
                
            }
        }
        public List<Product> GetByUnitPrice(decimal min, decimal max)
        // bu sorgumuzda fiyat aralığına göre sorgu
        {
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.Where(p => p.UnitPrice >= min && p.UnitPrice<=max).ToList();

            }
        }
        public Product GetById(int id)
            // burada tek bir ürün için arama yapacağız
        {
            using (ETradeContext context = new ETradeContext())

            {
               // var result = context.Products.FirstOrDefault(p => p.Id == id);
               // ilk bulduğu datayı getirir.
                // bu id'e uygun olan veriyi getir data bulamazsan null getir.
                var result = context.Products.SingleOrDefault(p => p.Id == id);
                // aynı işi yapıyor fakat kayda uyan fazla data bulursa hata verir.
                return result;
            }
        }
        public void Add(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                //context.Products.Add(product);
                // contexte'ki products'a ekle gönderilen ürünü.
                var entity = context.Entry(product);
                entity.State = EntityState.Added;
                // yeni ürün ekledim diyoruz.
                context.SaveChanges();
                //yapılan işlemleri veritabanına yaz diyoruz.
            }
        }
        public void Update(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var entity = context.Entry(product);
                // context'e abone ol kim için bu product için yani gönderdiğimiz product'ı veri tabanındaki product'a eşitliyor.
                entity.State = EntityState.Modified;
                // durumununa güncellemiş oluyoruz.
                context.SaveChanges();
            }
        }
        public void Delete(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var entity = context.Entry(product);
                entity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
