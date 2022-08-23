using System.Data.Entity;
using RecaptProject1.Entities;

namespace RecaptProject1
{
    public class NorthwindContext:DbContext                 //Tabloya karşılık gelen nesneye ihtiyaç olduğundan Entity klasörü açıyoruz.
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
