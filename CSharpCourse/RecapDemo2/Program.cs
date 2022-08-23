using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecapDemo2
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Logger = new DataBaseLogger();                //Logger işlemini somutladık ve DB yi newledik.Hangi log alanını istersek seçebiliriz bu şekilde.
            customerManager.Add();                                        //Daha sonra add yaptık.Loglanan herkesin farklı kod kullandığı için ayrı imp gerektiği için.

            Console.ReadLine();
        }
    }

    class CustomerManager
    {
        public ILogger Logger { get; set; }             //Interfacemize atama yapabilmek için property yapıyorız.
        public void Add()                               //Add işlemini yazıyoruz.
        {   
            Logger.Log();
            Console.WriteLine("Customer Added!");
        }
    }

    class DataBaseLogger:ILogger                        //Add işlemi yapılınca Loglama işleminin nereye olacağını seçebilmek için ILogger kullandık .
    {
        public void Log()
        {
            Console.WriteLine("DataBase Logged! ");
        }
    }

    class FileBaseLogger:ILogger
    {
        public void Log()
        {
            Console.WriteLine("FileBase Logged! ");
        }
    }
}
