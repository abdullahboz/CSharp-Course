using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace AdoNetDemo
{
    // Dal Data Access Layer demektir.

    public class ProductDal
    {
        SqlConnection _connection = new SqlConnection(@"server=(localdb)\mssqllocaldb;initial catalog=Etrade;integrated security=true");
        // Uzaktakine bağlanmak için ..security=false;uid=abdullah;password=12345;); şeklinde yazılır.
        public List<Product> GetAll()
        {
            ConnectionControl();
            //sql server iletişim kurmanın yöntemi Structured Query Language'dir ve bu sorguyu connection'a gönderiyoruz.
            SqlCommand command = new SqlCommand("Select * from Products", _connection);
            // bu metot ile oluşturduğumuz sorguyu çalıştırıyoruz. newleyip atamak doğru olmaz zaten referansı sql data reader.
            SqlDataReader reader = command.ExecuteReader(); 
            

            List<Product> products = new List<Product>();

            while (reader.Read()) // reader'i tek tek oku, okuyabildiğin sürece döngünün içinde çalıştır.
            {
                Product product = new Product
                {
                    Id = Convert.ToInt32(reader["Id"]), // gelen data obje olduğu için integer'a çeviriyoruz.
                    Name = reader["Name"].ToString(), // gelen data obje olduğu için string'e çeviriyoruz.
                    StockAmount = Convert.ToInt32(reader["StockAmount"]),
                    UnitPrice = Convert.ToDecimal(reader["UnitPrice"])
                    //StockAmount yerine StochAmount yapmışım column ismini düzeltemedim. düzeltip kaydedince sonsuz döngü hatası alıyorum.

                };
                // ürünü oluşturduk daha kullanmadık.
                // Her okuduğum elemanı product'a aktarıyorum onuda products'a ekliyorum.
                products.Add(product);

            }

            reader.Read();
            _connection.Close();
            return products;
        }

        public DataTable GetAll2()
        {   // @ işareti tamamen string olarak kabul ediliyor yazılanları.  
            // bu kısım ise veritabanına windows authentication ile bağlan demektir.
            SqlConnection connection = new SqlConnection(@"server=(localdb)\mssqllocaldb;initial catalog=Etrade;integrated security=true");
            // Uzaktakine bağlanmak için ..security=false;uid=abdullah;password=12345;); şeklinde yazılır.
            if (_connection.State == ConnectionState.Closed) //burada if komutu ile eğer sqlServer bağlantısı kapalı ise aç diyoruz.
            {
                _connection.Open();
            }
            //sql server iletişim kurmanın yöntemi Structured Query Language'dir ve bu sorguyu connection'a gönderiyoruz.
            SqlCommand command = new SqlCommand("Select * from Products", connection);
            // bu metot ile oluşturduğumuz sorguyu çalıştırıyoruz. newleyip atamak doğru olmaz zaten referansı sql data reader.
            SqlDataReader reader = command.ExecuteReader();  // bu komutu bir listeye çevirmemiz gerekiyor.


            DataTable dataTable = new DataTable(); // pahalı bir nesnedir ve serileştirme özelliği olmadığı için kullanılmaz.
            dataTable.Load(reader); // data table'yi readerla dolduruyoruz.
            reader.Close(); // işlem bitince kapatıyoruz.
            _connection.Close();
            return dataTable;
        }
        public void Add(Product product) // ekleme operasyonu
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Insert into Products values(@name,@unitPrice,@stockAmount) ", _connection);
            command.Parameters.AddWithValue("@name", product.Name); //string birleştirerek yaparsak sql enjekction denilen saldırıya maruz kalırız.
            command.Parameters.AddWithValue("@unitPrice", product.UnitPrice);
            command.Parameters.AddWithValue("@stockAmount", product.StockAmount);
            command.Parameters.AddWithValue("@id", product.Id);
            command.ExecuteNonQuery();

            _connection.Close();
        }
        public void Update(Product product) // ekleme operasyonu
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Update Products set Name=@name,UnitPrice=@unitPrice,StockAmount=@stockAmount where Id=@id", _connection);
            // hangi id'yi güncelleyeceğimize karar vermeliyiz yoksa bütün kayıtlar güncellenir.
            command.Parameters.AddWithValue("@id", product.Id);
            command.Parameters.AddWithValue("@name", product.Name); //string birleştirerek yaparsak sql enjekction denilen saldırıya maruz kalırız.
            command.Parameters.AddWithValue("@unitPrice", product.UnitPrice);
            command.Parameters.AddWithValue("@stockAmount", product.StockAmount);
            command.ExecuteNonQuery();

            _connection.Close();
        }
        public void Delete(int id)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Delete from Products where Id=@id", _connection);
            // hangi id'yi güncelleyeceğimize karar vermeliyiz yoksa bütün kayıtlar güncellenir.
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            _connection.Close();
        }
        private void ConnectionControl()
        {
            if (_connection.State == ConnectionState.Closed) //burada if komutu ile eğer sqlServer bağlantısı kapalı ise aç diyoruz.
            {
                _connection.Open();

            }
        }
    }

}
