using System;

namespace Abstract_Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            Database database = new Oracle();
            database.Add();
            database.Delete();

            Database database2 = new SqlServer();
            database2.Add();
            database2.Delete();

            Console.ReadLine();
        }
    }

    abstract class Database                             //Class olarak kullanılır ancak Mainde newlenemez. Interface gibidir ancak class özelliği taşır.
    {
        public void Add()                               //Add ise default olarak hepsinde aynı gelir.
        {
            Console.WriteLine("Added by default");
        }

        public abstract void Delete();                 //Delete kısmı DB lere özel olarak yazılacağı için abstract olarak yazıldı.   
    }

    class SqlServer:Database
    {
        public override void Delete()                 //Override ile burda da Delete işlemini DB lere özel yazarız.
        {
            Console.WriteLine("Deleted by SqlServer");
        }
    }

    class Oracle:Database

    {
        public override void Delete()
        {
            Console.WriteLine("Deleted by Oracle");
        }
    }
}
