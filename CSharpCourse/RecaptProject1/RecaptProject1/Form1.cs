using System;
using System.Linq;
using System.Windows.Forms;

namespace RecaptProject1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListCategories();
            ListProducts();
        }

        private void ListProducts()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                dgwProduct.DataSource = context.Products.ToList(); //Veritabanına Select* From yapar getirmek için.
            }
        }

        private void ListCategories()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                cbxCategory.DataSource = context.Categories.ToList();       //Veritabanına Select* From yapar getirmek için.
                cbxCategory.DisplayMember = "CategoryName";                 //Burda Kategori İsmini gösteriyoruz ancak aşağıda.
                cbxCategory.ValueMember = "CategoryId";                     //Değerleri Id den alıyoruz.ID GETİRİYORUZ ANCAK NAME GÖSTERİYORUZ.
            }
        }

        private void ListProductsByCategory(int categoryId)               //Ürünleri Kategoriye göre listeleme yapıp filtreleme yapacağız.
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                dgwProduct.DataSource = context.Products.Where(p => p.CategoryId == categoryId).ToList();
            }
        }

        private void ListProductsByProductName(string key)               //Ürünleri isimlerine göre listeleme yapıp filtreleme yapacağız.
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                dgwProduct.DataSource = context.Products.Where(p => p.ProductName.ToLower().Contains(key.ToLower())).ToList();       //Yazdığımız harflere göre getiriyor.
            }
        }

        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ListProductsByCategory(Convert.ToInt32(cbxCategory.SelectedValue));         //değer olmadığı için dolmadığından problem çıktığı için try ekledik.Catch boş bıraktık hata verse bile müdahele etme.
            }
            catch 
            { }
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            string key = tbxSearch.Text;                    //Eğer key değeri yok ise tüm listeyi getir var ise ona göre listele.
            if (string.IsNullOrEmpty(key))
            {
                ListProducts();
            }
            else
            {
                ListProductsByProductName(tbxSearch.Text);
            }
        }
    }
}
