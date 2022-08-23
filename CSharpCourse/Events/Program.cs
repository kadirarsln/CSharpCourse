using System;

namespace Events
{
    class Program
    {
        static void Main(string[] args)
        {
            Product harddisk = new Product(50);
            harddisk.ProductName = "Hard Disk";

            Product gsm = new Product(50);
            gsm.ProductName = "GSM";
            gsm.StockControlEvent += Gsm_StockControlEvent;         //GSM i eventledik burda. += kullandık delegate gibi. 
            
            for (int i = 0; i < 10; i++)
            {
                harddisk.Sell(10);
                gsm.Sell(10);
                Console.ReadLine();
            }

            Console.ReadLine();
        }

        private static void Gsm_StockControlEvent()             //GSM BİTTİĞİNDE NE YAPALIM DİYE BURAYA EKLERİZ.
        {
            Console.WriteLine("GSM about to finish!");
        }
    }
}
