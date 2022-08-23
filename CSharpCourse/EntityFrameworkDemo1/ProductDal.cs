using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EntityFrameworkDemo1
{
    public class ProductDal
    {
        public List<Product> GetAll()                                     //Tabloya erişim için yazılacak kod.GetAll() kısmı geçen projedeki.
        {
            using (eTradeContext context = new eTradeContext())           //Burda bellekten atıyoruz çok yer kapladığı için using kullanımı yapıyoruz.Dispose yapıyoruz.
            {
                return  context.Products.ToList();                        //Liste şeklinde return ettik.      
            }
        }

        //İisime göre arama yaptık.
        public List<Product> GetByName(string key)                                      //Listedeki her bir eleman için Name ye bak içeriği aranan kelime
        {
            using (eTradeContext context = new eTradeContext())          
            {
                return context.Products.Where(p => p.Name.Contains(key)).ToList();      //VeriTabanına sorgu yapıyoruz.Bu daha doğrudur verileri koleksiyon değilde DB den sorguluyoruz.
            }
        }

        //Fiyatına göre arama yaptık
        public List<Product> GetByUnitePrice(decimal min,decimal max)                                      //Listedeki her bir eleman için UnitPrice bak fiyatı aranan ürün.
        {
            using (eTradeContext context = new eTradeContext())
            {
                return context.Products.Where(p => p.UnitPrice>=min && p.UnitPrice<=max).ToList();                 //VeriTabanına sorgu yapıyoruz.Bu daha doğrudur verileri koleksiyon değilde DB den sorguluyoruz.
            }                                                                                                      //Ürün değerine bakar iki fiyat arasındaki ürünleri getirir. kontrol edilir.
        }

        //ID göre tek bir ürün getirmek istiyoruz.
        public Product GetById(int id)                                      //Liste değil tek ürün getiireceğimiz için ID bakılarak.
        {
            using (eTradeContext context = new eTradeContext())
            {
                var result = context.Products.FirstOrDefault(p => p.Id == id);     //VeriTabanına sorgu yapıyoruz.Bu daha doğrudur verileri koleksiyon değilde DB den sorguluyoruz.ID girilen ile eşitse getirir.
                return result;
            }
        }

        public void Add(Product product)
        {
            using (eTradeContext context = new eTradeContext())           //Burda bellekten atıyoruz çok yer kapladığı için using kullanımı yapıyoruz.Dispose yapıyoruz.
            {
                //context.Products.Add(product);                            //Ürünlerin ekleme işlemini yapıyoruz burda da.

                var entity = context.Entry(product);                      //Güncellemede kullandığımızı burda da kullanabiliriz.
                entity.State = EntityState.Added;
                
                context.SaveChanges();                                    //Veri Tabanına save ediyoruz.Yaz diyoruz.
            }
        }

        public void Update(Product product)
        {
            using (eTradeContext context = new eTradeContext())
            {
                var entity = context.Entry(product);                //contex üzerinden bu product için abone ol demek.
                                                                    //Gönderdiğimiz prdouctı veri tabanındaki ürün ile ilişkilendiriyor.Güncelliyoruz.
                
                entity.State = EntityState.Modified;                //Veri tabanındaki producta eşitliyorum bunu da ID üzerinden yapıyorum primary key olduğu için.
                                                                    //Durumunu da güncellendi diye gösteririz. 
                context.SaveChanges();
            }
        }

        public void Delete(Product product)
        {
            using (eTradeContext context = new eTradeContext())
            {
                var entity = context.Entry(product);
                entity.State = EntityState.Deleted;

                context.SaveChanges();
            }
        }
    }
}
