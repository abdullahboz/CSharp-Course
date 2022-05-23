using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo
{
    public class ETradeContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        // benim bir product'ım var onu tablo gibi products ismiyle kullanacağım, mapping yapıyoruz. 
        // tablolarda products'ı arar.
        // Connection string'imizi App.Config'in içine atıyoruz.
        /*
         * <connectionStrings>
		<add name="ETradeContext" connectionString="server=(localdb)\mssqllocaldb;initial catalog=Etrade;integrated security=true" providerName="System.Data.SqlClient"/>
	</connectionStrings>
         *  yukarıdaki gibi bir görünüm olması gerekiyor.
         */
    }
}
