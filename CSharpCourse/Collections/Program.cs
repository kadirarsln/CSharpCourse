using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            //ArrayList();
            //List();

            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("Book","Kitap");
            dictionary.Add("Table","Masa");
            dictionary.Add("Maniac","Kadir");

            //Console.WriteLine(dictionary["Maniac"]);

            foreach (var item in dictionary)
            {
                Console.WriteLine(item);
            }

            dictionary.Count();                 //Aynı şeyler burda da geçerlidir.

            Console.WriteLine(dictionary.ContainsKey("glass"));         //Arama işlemi yapar ve True veya False döndürür.
            Console.WriteLine(dictionary.ContainsKey("Maniac"));

            Console.ReadLine();
        }

        private static void List()
        {
            List<string>
                cities = new List<string>(); //Bu koleksiyonda sadece string ile tek veri tipi ile çalışacağımızı belirtiriz.
            cities.Add("SASONKE");
            cities.Add("Roma");

            Console.WriteLine(cities.Contains("SASONKE")); //Şehirler arasında SASONKE varsa true sonuç verir.

            //List<Customer> customers = new List<Customer>();                //Customer olarak listeleyerek customer içersindeki get setlerden faydalanarak ekleme yapıyoruz.
            //customers.Add(new Customer { Id = 44, Name = "EGOroth" });
            //customers.Add(new Customer { Id = 33, Name = "Felcia" });

            List<Customer> customers = new List<Customer> //Farklı bir gösterim şeklidir
            {
                new Customer { Id = 44, Name = "EGOroth" },
                new Customer { Id = 33, Name = "Felcia" }
            };

            var customers2 = new Customer
            {
                Id = 2, Name = "BOOMKE"
            };
            customers.Add(customers2); //Ekleme yapmak için kullanırız.

            customers.AddRange(
                new Customer[2] //Elimizde bulunan listeye yeni liste geldiği vakit ekleme yapmak için kullanırız.
                {
                    new Customer { Id = 3, Name = "Arslan" },
                    new Customer { Id = 4, Name = "Şehmus" }
                });

            //customers.Clear();

            var index = customers.IndexOf(customers2); //Listedeki elemanın kaçıncı sırada olduğunu verir.
            Console.WriteLine("Index: {0}", index);

            customers.Insert(0,
                customers2); //İstedğin yere kaçıncı sıraya neyi eklemek istiyorsun.Seçersiniz.Araya customer ekledik.

            customers.Remove(customers2); //Bulduğu ilk değeri bulduktan sonra onu çıkarır ve durur.
            customers.RemoveAll(c => c.Name == "BOOMKE"); //İçersinde belirtilen değeri bul ve tamamını çıkar sil.


            foreach (var customer in customers)
            {
                //Console.WriteLine(customer.Id);
                Console.WriteLine(customer.Name);
            }

            var count = customers.Count(); //Eleman sayısını verir.Customers.
            Console.WriteLine("Count: {0}", count);
        }

        private static void ArrayList()
        {
            ArrayList cities = new ArrayList(); //ArrayList şeklinde yazdığımız zaman boyut belirtmiyoruz ve kodun herhangi bir kısmında ekleme yapılabilir.
            cities.Add("İstanbul");
            cities.Add("Mersin");

            cities.Add(72); //Eklenenler string olmak zorunda değil her veri tipi eklenebilir.Bu pek önerilmez. Tip güvenli değildir.
            cities.Add('K');

            foreach (var city in cities)
            {
                Console.WriteLine(city);
            }
        }

        class Customer
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
