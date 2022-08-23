using System;

namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            //InterfacesIntro();        //Interface ler tek başına newlenemez.Ancak Classları Interface üzerinden new leyeiliriz.

            //Demo();                   //ICustomerDal kullanarak ekleme silme veya çıkarma işlemlerini yapmak için ve verileri farklı veritabanlarında kullanabilmek için işlem yaptık.

            ICustomerDal[] customerDals = new ICustomerDal[2]           //Array oluşturup iki değer atadık içersine ve Veri Tabanlarını new ledik.
            {
                new SqlServerCustomerDal(),
                new OracleCustomerDal()
            };
            foreach (var customerDal in customerDals)                   //Döngü içersinde ikiside döner ve eklenir.Bunun avantajı farklı veri tabanına geçişlerde sadece veritabanı eklerız.
            {
                customerDal.Delete();
            }

            Console.ReadLine();
        }

        private static void Demo()
        {
            CustomManager customManager = new CustomManager();
            customManager.Add(new OracleCustomerDal());
        }

        private static void InterfacesIntro()
        {
            PersonManager manager = new PersonManager();
            Customer customer = new Customer()
            {
                Id = 1,
                FirstName = "Kadir",
                LastName = "Arslan",
                Adress = "Batman"
            };

            Students students = new Students()
            {
                Id = 2,
                FirstName = "Yaren",
                LastName = "Selbi",
                Departmant = "Nurse"
            };
            manager.Add(customer); //manager ile ekleme kısmını cağırarak yazdırma işlemi yaparız.Üst kısımda personManager girdiğimiz için
            manager.Add(students); //Çağırma işleminde bütün personalrı kullanabiliriz.
        }
    }
    interface IPerson                           //Personların ortak proplarını barındırır.Ve classlar içersinde ayrıca tanımlamak gerekiyor.
    {
         int Id { get; set; }                   //İmzasıdır.
         string FirstName { get; set; }
         string LastName { get; set; }
    }

    class Customer:IPerson                             //Personlar oluştururuz. Öğrenci vb. şeklinde ve onları Person a tanımlarız.Bu sayede tek yerde toplanır.
    {
        public int Id { get; set; }         
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
    }

    class Students:IPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Departmant { get; set; }
    }

    class PersonManager
    {
        public void Add(IPerson person)                 //PersonManager oluşturarak ekleme silme veya update işlemlerinde yer alacak kısmı oluştururuz
        {                                               //Daha sonra bu katmanı IPerson ile bağlayarak verilerin gelmesini sağlarız.
            Console.WriteLine(person.Id);
            Console.WriteLine(person.FirstName);
            Console.WriteLine(person.LastName);
        }
    }

    
}
