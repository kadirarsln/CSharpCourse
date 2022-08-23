using System;

namespace Constructors
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(15);
            customerManager.List();

            Product product = new Product { Id = 1, Name = "Laptop" };
            Product product2 = new Product(2,"Computer");               //Parametresiz veya bu şekilde de kullanabilir artık.

            EmployeeManager employeeManager = new EmployeeManager(new DataBaseLogger());
            employeeManager.Add();                                                           //Loglama yapılacak yeri seçtik.

            PersonManager personManager = new PersonManager("Product");
            personManager.Add();
            Console.ReadLine();
        }
    } 

    class CustomerManager
    {
        private int _count;                     //_ isimlendirme standarı.
        public CustomerManager(int count)                 //Bir sınıf genel anlamda new lenince çalışan kod bloğudur.
        {                                                 //Bu sınıfın ihtiyaç duyduğu parametreler varsa ve bunlar kullanıma göre değişiklik gösteriyorsa.
            _count = count;
        }

        public CustomerManager()                    //Boş şeklinide kullanabilmek için overloading yapıyoruz.
        {
                                        
        }

        public void List()
        {
            Console.WriteLine("Customer Listed {0} items!" ,_count);
        }

        public void Add()
        {
            Console.WriteLine("Customer Added!");
        }

    }

    class Product
    {
        public Product()
        {
            
        }

        private int _id;
        private string _name;

        public Product(int id,string name)
        {
            _id = id;
            _name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class DataBaseLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged to DataBase.");
        }
    }

    class FileLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged to File.");
        }
    }

    class EmployeeManager
    {
        private ILogger _logger;

        public EmployeeManager(ILogger logger)
        {
            _logger = logger;
        }
        public void Add()
        {
            _logger.Log();
            Console.WriteLine("Added.");
        }
    }

    class BaseClass
    {
        private string _entity;

        public BaseClass(string entity)
        {
            _entity = entity;
        }
        public void Message()
        {
            Console.WriteLine("{0} message",_entity);
        }
    }

    class PersonManager:BaseClass
    {
        public PersonManager(string entity) : base(entity)
        {

        }

        public void Add()
        {
            Console.WriteLine("Added! ");
            Message();
        }
    }
}
