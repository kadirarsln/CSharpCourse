using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AdoNetDemo
{
    public class ProductDal        //DAL: Data Access Layer Verileri buraya çekiyoruz.
    {
        SqlConnection _connection = new SqlConnection(@"server=(localdb)\mssqllocaldb;initial catalog=eTrade;integrated security=true");  //Hangi veri tabanınaa bağlanacağımızı seçeriz.Bağlantı nesnesi tek oluştu.
        public List<Product> GetAll()
        {
            ConnectionControl();                                     //Heryerde lazım olacağı için method haline getirdik.              
            
            SqlCommand command = new SqlCommand("Select * from Products",_connection);       //Bağlantı ile iletişim kurmak için sorguyu bağlantıya göndeririz.Komut oluşur ancak çalıştırdığımız anlamına gelmez.
            
            SqlDataReader reader = command.ExecuteReader();         //Komutu çalıştırmak içindir.Tablo sonucu döndürünce bunu kullanırız.Diğerleri farklı olabilir.        

            List<Product> products = new List<Product>();

            while (reader.Read())                                   //Liste yaptık ve while içinde okumasını sağladık
            {
                Product product = new Product
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    UnitPrice = Convert.ToDecimal(reader["UnitPrice"]),
                    StockAmount = Convert.ToInt32(reader["StockAmount"])
                };
                products.Add(product);
            }
            reader.Close();                                        //komut ve bağlantı ilemlerimiz bitince kapatıyoruz.
            _connection.Close(); 
            return products;
        }
                
        private void ConnectionControl()                            //Heryerde lazım olacağı için method haline getirdik.    
        {
            if (_connection.State == ConnectionState.Closed)        //Bağlantı durumu kapalı ise açık hale getir.
            {
                _connection.Open();
            }
        }

        public DataTable GetAll2()
        {
            if (_connection.State == ConnectionState.Closed)       //Bağlantı durumu kapalı ise açık hale getir.
            {
                _connection.Open();
            }
            SqlCommand command = new SqlCommand("Select * from Products", _connection);       //Bağlantı ile iletişim kurmak için sorguyu bağlantıya göndeririz.Komut oluşur ancak çalıştırdığımız anlamına gelmez.

            SqlDataReader reader = command.ExecuteReader();         //Komutu çalıştırmak içindir.Tablo sonucu döndürünce bunu kullanırız.Diğerleri farklı olabilir.        

            DataTable dataTable = new DataTable();                 //Komutumuzu listeye cevirmek gerekir.   gÜNÜMÜZDE ÇOK KULLANILMAZ.
            dataTable.Load(reader);                                //IDataReader türünde birşey ister.
            reader.Close();                                        //komut ve bağlantı ilemlerimiz bitince kapatıyoruz.
            _connection.Close();
            return dataTable;
        }

        public void Add(Product product)                           //Yeni ürün ekleme işlemini yapmak için Add ekleriz.
        {
            ConnectionControl();
            SqlCommand command =
                new SqlCommand(
                    "Insert into Products values(@name,@unitPrice,@stockAmount)", _connection);        //Ürün için komut oluşturduk ancak halen çalışır durumda değildir.
            command.Parameters.AddWithValue("@name", product.Name);                                     // Parametreleri oluşturduk.Productın name alıp içeri yazıyor.
            command.Parameters.AddWithValue("@unitPrice", product.UnitPrice);
            command.Parameters.AddWithValue("@stockAmount", product.StockAmount);
            command.ExecuteNonQuery();

            _connection.Close();
        }

        public void Update(Product product)                           //Yeni ürün ekleme işlemini yapmak için Add ekleriz.
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand(
                    "Update Products set Name=@name,UnitPrice=@unitPrice,StockAmount=@stockAmount where Id=@id",
                    _connection);                                               //Ürün için güncelleme komudu oluşturduk ve Id üzerinden yaptık.
                                                                                //Çünkü tamamı değişmesin diye, ancak halen çalışır durumda değildir.
            command.Parameters.AddWithValue("@name", product.Name);                
            command.Parameters.AddWithValue("@unitPrice", product.UnitPrice);
            command.Parameters.AddWithValue("@stockAmount", product.StockAmount);
            command.Parameters.AddWithValue("@id", product.Id);
            command.ExecuteNonQuery();

            _connection.Close();
        }

        public void Delete(int id)                          
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand(
                "Delete from Products where Id=@id", _connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();

            _connection.Close();
        }
    }
}
