using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkDemo;

namespace EntityFrameworkDemo
{
    class eTradeContext:DbContext                           //DB context yaptık.
    {
        public DbSet<Product> Products { get; set; }        //Benim bir tablom var Entity set olarark yani tablo gibi Products ismi kullanacağız.
    }
}
