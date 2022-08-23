using System.Data.Entity;

namespace EntityFrameworkDemo1
{
    class eTradeContext: DbContext                           //DB context yaptık.
    {
        public DbSet<Product>Products{ get; set; }           //Benim bir tablom var Entity set olarark yani tablo gibi Products ismi kullanacağız.
    }
}
