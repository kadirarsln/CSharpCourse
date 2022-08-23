using System;

namespace RecaptProject1.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }                 //Foregin Key olduğundan primary den sonra yazılır.
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public Int16 UnitsInStock { get; set; }
        public string QuantityPerUnit { get; set; }
    }
}
