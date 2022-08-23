using System;
using System.Collections.Generic;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            Utilities utilities = new Utilities();
            List<string> result = utilities.BuildList("Ankara", "Adana", "İzmir");      //Verdiğimiz data nasılsa o türde liste şeklinde getirecek mesela string.
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            List<Customer> result2=utilities.BuildList<Customer>(new Customer{FirstName = "Kadir"},new Customer{FirstName = "Arslan"});

            foreach (var customer in result2)
            {
                Console.WriteLine(customer.FirstName);
            }

            Console.ReadLine();
        }
    }

    class Utilities
    {
        public List<T> BuildList<T>(params T[] items)
        {
            return new List<T>(items);
        }
    }

    class Product:IEntity
    {
        
    }
    interface IProductDal:IRepository<Product>      //Aynı özellikleri hepsi için kullandığımız için IRepository çağırdık ve Product olarak verdik.
    {
        
    }

    class Customer:IEntity
    {
        public string FirstName { get; set; }
    }
    interface ICustomerDal:IRepository<Customer>
    {

    }

    interface IStudentDal:IRepository<Student>
    {
        
    }

    class Student:IEntity
    {
        
    }

    interface IEntity
    {
        
    }

    //T yani tip olarak atama yaptık. Aynı işlemleri çok kez kullandığımız için tek bir yerde IRep olarak yazdık ve burdan çektik.
    interface IRepository<T> where T:class,IEntity,new()    //Newlenebilir referans tip yazmak için koşul ekleriz class olabilmesi için.
    {                                                       //Aynı zamanda IEntity den implement edilmeli Yani customer, student vb. olmalı.
        List<T> GetAll();                                   //Değer tipler için ise struct ekleriz class yerine.
        T Get(int id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }

    class CustomerDal:ICustomerDal             //İmplement ettik ve otomatik olarak geldi İşlemler.
    {
        public List<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }

    class ProductDal:IProductDal
    {
        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public Product Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
