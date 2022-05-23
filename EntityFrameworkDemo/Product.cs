using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// namespace classları gruplamak için kullanılır.
namespace EntityFrameworkDemo
{
    // Manage nuGet Packages kısmından entityframwork'ü references'e ekliyoruz.
    // entity framwork'te en önemli kural veritabanındaki tabloya karşılık gelen bir class'ımızın olmasıdır.
    // Unit of work tasarım deseni kavramını araştır.
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public decimal UnitPrice { get; set; }
        public int StockAmount { get; set; }

    }
}
