using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Oluşturulan classı cağırmak ve kullanmak için bir örneğini oluştururuz. 

            CustomerManager customerManager = new CustomerManager();
            customerManager.Add();
            customerManager.Update();

            Console.ReadLine();

            ProductManager productManager = new ProductManager();
            productManager.Add();
            productManager.Update();

            Console.ReadLine();

            Customer customer = new Customer();
            customer.Id = 1;
            customer.FirstName = "Kadir";       // Eşitleyince property den (set) bloğu çalışır.
            customer.LastName = "Arslan";  
            customer.City = "Batman";

            //---------------------------------
            //Bu şekilde de kullanılabilir.

            Customer customer1 = new Customer
            {
                Id = 2, FirstName = "Yaren", LastName = "Selbi", City = "Mersin"
            };

            Console.WriteLine(customer1.FirstName);     //Eşitlik yok (get) kullanırız.Customer2 den firstnameyi al oku.
            Console.ReadLine();
        }
    }

}
