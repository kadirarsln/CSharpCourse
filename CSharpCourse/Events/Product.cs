using System;


namespace Events
{
    public delegate void StockControl();            //Delegemiz stok kontrol olcak.
    public class Product
    {
        private int _stock;                         //Normalde değerleri veri tabanından çekeriz burada ctor ile sağlıyoruz.

        public Product(int stock)
        {
            _stock = stock;
        }

        public event StockControl StockControlEvent;        //Bir event tanımladık.
        public string ProductName { get; set; }
        
        public int Stock
        {
            get { return _stock; }
            set
            {
                _stock = value;
                if (value <=15 && StockControlEvent !=null)
                {
                    StockControlEvent();
                }
            }
        }
                              // get set ile kalan stoğu okur ve yazarız.Kalan stok için uyarı yapmak için get set ayırırı ekleriz.

        public void Sell(int amount)
        {
            Stock -= amount;
            Console.WriteLine("{1} Stock amount: {0}",Stock,ProductName);
        }
    }
}
