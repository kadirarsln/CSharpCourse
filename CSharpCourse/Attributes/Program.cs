using System;

namespace Attributes
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer { Id = 1, LastName = "Arslan", Age = 22 };
            CustomerDal customerDal = new CustomerDal();
            customerDal.Add(customer);          //BİLGİ MESAJI YER ALIR

            Console.ReadLine();
;        }
    }
    [ToTable("Customer")]
    class Customer
    {
        public int Id { get; set; }
        [RequiredProperty]                      //Yazmak zorunlu boş bırakılamaz. 
        public string FirstName { get; set; }
        [RequiredProperty]
        public string LastName { get; set; }
        [RequiredProperty]
        public int Age { get; set; }
    }

    class CustomerDal               //Ekleme yaptık.
    {
        [Obsolete("Don't use Add,instead use AddNew Method")]      //Eski method kullanılır.Hazır method.
        public void Add(Customer customer)
        {
            Console.WriteLine("{0},{1},{2},{3} added!",
                customer.Id, customer.FirstName, customer.LastName, customer.Age);
        }

        public void AddNew(Customer customer)           //Yeni Method varsa eğer.İkisininde işlevleri var ise
        {
            Console.WriteLine("{0},{1},{2},{3} added!",
                customer.Id, customer.FirstName, customer.LastName, customer.Age);
        }
    }

    //[AttributeUsage(AttributeTargets.All)]             //Bu Attribute herkese kullanılabilir demektir.
    [AttributeUsage(AttributeTargets.Property|AttributeTargets.Field)]          //iki adet yerde kullanmak için.
    class RequiredPropertyAttribute:Attribute
    {
        
    }

    [AttributeUsage(AttributeTargets.Class,AllowMultiple = true)]           //Sadece classlara kullanılır.
    class ToTableAttribute : Attribute                                      //Birden fazla kullanabilmek multiple.
    {
        private string _tableName;

        public ToTableAttribute(string tabelName)
        {
            _tableName = tabelName;
        }
    }
}
