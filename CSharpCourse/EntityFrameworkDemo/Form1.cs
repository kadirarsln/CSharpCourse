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

        private void Form1_Load(object sender, EventArgs e)
        {
            using (eTradeContext context=new eTradeContext())           //Burda bellekten atıyoruz çok yer kapladığı için using kullanımı yapıyoruz.Dispose yapıyoruz.
            {
                dgwProducts2.DataSource = context.Products.ToList();    //Tabloya erişim için yazılacak kod.GetAll() kısmı geçen projedeki.
            }
        }
    }
}
