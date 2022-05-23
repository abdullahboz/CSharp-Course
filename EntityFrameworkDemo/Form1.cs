using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworkDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ProductDal _productDal = new ProductDal();
        // publicte tanımlanan değişkenler ve nesneler _işareti ile başlar.
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }
        private void LoadProducts()
        {
            dgwProducts.DataSource = _productDal.GetAll();
        }
        private void SearchProducts(string key)
        {
            // Code-->//var result = _productDal.GetAll().Where(p=>p.Name.Contains(key)).ToList(); 
            //Bu kısmı productDal'ın içindeki getbyname metodunun altında anlattım. 
            //farkı koleksiyona yaptığımız aramalarda küçük büyük harf duyarlı olur.
            // bunu yapmamak için şu yukarıdaki kodu şu şekilde düzenleyebiliriz.
            //var result = _productDal.GetAll().Where(p => p.Name.ToLower().Contains(key.ToLower())).ToList();
            // bu çok sık yapılan birşeydir koleksiyondaki herşeyi küçük harf'e çevirerek aramalarda da küçük büyük harf duyarlılığını ortadan kaldırırız.
            var result = _productDal.GetByName(key);
            // veritabanından getireceği için küçük büyük harf duyarlı olmayacaktır.
            dgwProducts.DataSource = result;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productDal.Add(new Product 
            {
                Name = tbxName.Text,
                UnitPrice = Convert.ToDecimal(tbxUnitPrice.Text),
                StockAmount = Convert.ToInt32(tbxStockAmount.Text)
            });
            LoadProducts();
            MessageBox.Show("Added!");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _productDal.Update(new Product
            {
                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
                Name = tbxUpdateName.Text,
                UnitPrice = Convert.ToDecimal(tbxUpdateUnitPrice.Text),
                StockAmount = Convert.ToInt32(tbxStockAmountUpdate.Text)
            });
            LoadProducts();
            MessageBox.Show("Uptaded!");
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            _productDal.Delete(new Product
            {
                Id=Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value)
            });
            LoadProducts();
            MessageBox.Show("Deleted!");
        }

        private void dgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            tbxUpdateName.Text = dgwProducts.CurrentRow.Cells[1].Value.ToString();
            tbxUpdateUnitPrice.Text = dgwProducts.CurrentRow.Cells[2].Value.ToString();
            tbxStockAmountUpdate.Text = dgwProducts.CurrentRow.Cells[3].Value.ToString();//seçili olan satırın 1. hücresini değiştiricez 1. hücrede Id var.
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            // Form'a eklediğimiz textbox'ımız ile arama yaptığımızda aradığımız ürünü bulmaya çalışacağız
            SearchProducts(tbxSearch.Text);
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            _productDal.GetById(1);
           
        }
    }
}
