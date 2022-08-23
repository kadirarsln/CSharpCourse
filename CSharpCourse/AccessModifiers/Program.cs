using System;

namespace AccessModifiers
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Customer
    {
        public int Id;                      //Public olması diğer sınıflar tarafından da kullanılabilmesi 
                                            //Private değişkenler ise sadece tanımlandığı bloklarda kullanılabilir.
    }

    class Student:Customer                          //Protected ise tanımlandığı blokta ve inherit edildiği yerde kullanılır.
    {                                                    
        public void Save()
        {
            Console.WriteLine();
        }
    }
                                                //Public class lar ise farklı projeler tarafından bile çağrılabilir.
    internal class Course                       //Proje içersinde istediğin yerde kullanabillirsin.
    {                                           //Bir  class internal ve public olabilir.Private classlar sadece iç içe yazılınca kullanılabilir.
        public string name { get; set; }
    }
}
