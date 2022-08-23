
namespace EntityFrameworkDemo1
{
    public class Product            //Data yı karşılayacak nesnemiz.
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int StockAmount { get; set; }
    }
}
