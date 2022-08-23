using System;
using System.Windows.Forms;

namespace AdoNetDemo
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        ProductDal _productDal = new ProductDal();               //ProductDal burdan çağırıyoruz

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        // PRODUCT LARI GETİRİR.
        private void LoadProducts()
        {
            dgwProducts2.DataSource = _productDal.GetAll(); //Burda ise GetAll(); çağırarak bilgileri productdaldan getirdik.Tablomuza yansıdı. 
        }

        //Add(); YAPILACAK YER

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productDal.Add(new Product
            {
                Name = tbxName.Text,
                UnitPrice = Convert.ToDecimal(tbxUnitPrice.Text),
                StockAmount = Convert.ToInt32(tbxStockAmount.Text)
            });
            LoadProducts();
            MessageBox.Show("Product Added!");
        }

        //UPDATE(); YAPILACAK YER:

        private void dgwProducts2_CellClick(object sender, DataGridViewCellEventArgs e)         //Hücreye tıkladığımız zaman değerler gidip aktarıldı.
        {
            tbxNameUpdate.Text = dgwProducts2.CurrentRow.Cells[1].Value.ToString();             //Name için tıklanan sıranın name hücresini alıyoruz güncellemek için.
            tbxUnitPriceUpdate.Text = dgwProducts2.CurrentRow.Cells[2].Value.ToString();
            tbxStockAmountUpdate.Text = dgwProducts2.CurrentRow.Cells[3].Value.ToString();
            MessageBox.Show("Cell Click!");
        }

        private void btnUpdate_Click(object sender, EventArgs e)                    //Güncelle yaptığımız zaman tekrar okuyrouz.
        {
             Product product = new Product
            {
                Id = Convert.ToInt32(dgwProducts2.CurrentRow.Cells[0].Value),        //Id tablodan alırız çünkü güncellenecek ürünü seçiyoruz.      
                Name = tbxNameUpdate.Text,                                           //Kalan bilgileri ise kendimiz giriyoruz güncellemek için.
                UnitPrice = Convert.ToDecimal(tbxUnitPriceUpdate.Text),                    //Label içersine girdiğimiz bilgileri alırız.
                StockAmount = Convert.ToInt32(tbxStockAmountUpdate.Text)
            };
            _productDal.Update(product);
            LoadProducts();
            MessageBox.Show("Updated!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgwProducts2.CurrentRow.Cells[0].Value);
            _productDal.Delete(id);
            LoadProducts();
            MessageBox.Show("Deleted!");
        }
    }
}
