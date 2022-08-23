using System;


namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Person[] persons = new Person[3]         //Person baba olarak görülebilir. Customer ve Students çocuk gibidir.Farklı özellikleri de olabilir.
            {
                new Customer { FirstName = "Arslan" },
                new Student { FirstName = "Kadir" },
                new Person { FirstName = "Keltoş" }
            };
            foreach (var person in persons)
            {
                Console.WriteLine(person.FirstName);
            }

            Console.ReadLine();
        }
                                    //Person baba olarak görülebilir. Customer ve Students çocuk gibidir.Farklı özellikleri de olabilir.
        class Person                //Interface lerde Interface tek başına anlam ifade etmez ancak claslarda öyle değil eklenebilir.İşlem olbailir.
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        class Customer:Person       //Farklı Personlar(Baba) yazabiliriz ancak aynı Customer(Çocuklar) farklı babaya atayamayız.
        {
            public string City { get; set; }
        }

        class Student : Person
        {
            public string Department { get; set; }
        }
    }
}
