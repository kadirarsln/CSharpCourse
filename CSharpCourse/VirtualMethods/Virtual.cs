using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualMethods
{
    class Virtual
    {
        static void Main(string[] args)
        {
            SqlServer sqlServer = new SqlServer();
            sqlServer.Add();
            sqlServer.Delete();

            Console.WriteLine("----------------------------------------------------------");
            
            MySql mySql = new MySql();
            mySql.Add();
            mySql.Delete();

            Console.ReadLine();
        }
    }

    class DataBase
    {
        public virtual void Add()                          //Virtual ekleyerek kodun ezilmesine izin veririz.Default kod ve aşağıdaki DB lerin özelliklerini de eklemek için.
        {
            Console.WriteLine("Added by default");
        }

        public virtual void Delete()
        {
            Console.WriteLine("Deleted by default");
        }
    }

    class SqlServer:DataBase
    {
        public override void Add()                          //Override ile üst kısımdaki kodu ezeriz ve SQLServer a özgü Add fonksiyonunu çalıştırırız.
        {
            Console.WriteLine("Added by SqlServer Code. ");
            //base.Add();                                     //base.Add(); ise default DB kısmını çalıştırmak için kullanılır.Bazı durumalrda ikisi de gerekir.
        }

        public override void Delete()
        {
            Console.WriteLine("Deleted by SqlServer");
            base.Delete();
        }
    }

    class MySql:DataBase
    {
        public override void Add()
        {
            Console.WriteLine("MySQL by added.");
            base.Add();
        }

        public override void Delete()
        {
            Console.WriteLine("MySQL by deleted.");
            //base.Delete();
        }
    }
}
