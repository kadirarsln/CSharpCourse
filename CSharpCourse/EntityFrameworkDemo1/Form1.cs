using System;
using System.Linq;
using System.Windows.Forms;

namespace EntityFrameworkDemo1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private ProductDal _productDal = new ProductDal();         //ProductDaldan ürünleri getirebilmek için new leme yapıyoruz.

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        //Load Yaparız tabloyu getiririz her işlemde güncel halini.
        private void LoadProducts()
        {
            dgwProducts2.DataSource = _productDal.GetAll();
        }

        private void SearchProducts(string key)
        {
            var result = _productDal.GetByName(key);      //Listedeki her bir eleman için name ye bak içeriği aranan kelime.VeriTabanına sorgu yapıyoruz.
            dgwProducts2.DataSource = result;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productDal.Add(new Product          //Ekleme işlemi için fonksiyonumuzu yazdık burda da ve eklenecek bilgileri yazdık.
            {
                Name = tbxName.Text,
                UnitPrice = Convert.ToDecimal(tbxUnitPrice.Text),
                StockAmount = Convert.ToInt32(tbxStockAmount.Text)
            });

            LoadProducts();                     //Ürünleribn yüklemesini yaptık.Güncel halini işlem sonrası.
            MessageBox.Show("Added!");
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _productDal.Update(new Product
            {
                Id = Convert.ToInt32(dgwProducts2.CurrentRow.Cells[0].Value),        //Id tablodan alırız çünkü güncellenecek ürünü seçiyoruz.      
                Name = tbxNameUpdate.Text,                                           //Kalan bilgileri ise kendimiz giriyoruz güncellemek için.
                UnitPrice = Convert.ToDecimal(tbxUnitPriceUpdate.Text),                    //Label içersine girdiğimiz bilgileri alırız.
                StockAmount = Convert.ToInt32(tbxStockAmountUpdate.Text)
            });
            LoadProducts();
            MessageBox.Show("Updated!");
        }

        private void dgwProducts2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxNameUpdate.Text = dgwProducts2.CurrentRow.Cells[1].Value.ToString();             //Name için tıklanan sıranın name hücresini alıyoruz güncellemek için.
            tbxUnitPriceUpdate.Text = dgwProducts2.CurrentRow.Cells[2].Value.ToString();
            tbxStockAmountUpdate.Text = dgwProducts2.CurrentRow.Cells[3].Value.ToString();
            MessageBox.Show("Cell Click!");
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            _productDal.Delete(new Product
            {
                Id = Convert.ToInt32(dgwProducts2.CurrentRow.Cells[0].Value)            //Sadece ID gerekiyor.
            });
            LoadProducts();
            MessageBox.Show("Deleted!");
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            SearchProducts(tbxSearch.Text);
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            _productDal.GetById(1);
        }
    }
}
