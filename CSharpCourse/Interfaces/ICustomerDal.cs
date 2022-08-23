using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    interface ICustomerDal
    {
        void Add();
        void Update();
        void Delete();
    }

    class SqlServerCustomerDal:ICustomerDal             //İmplement ediyoruz.Farklı VeriTabanları kullanabilmek için kodumuzun hepsindde çalışması için.
    {
        public void Add()
        {
            Console.WriteLine("SQL Server Added.");
        }

        public void Update()
        {
            Console.WriteLine("SQL Server Updated.");
        }

        public void Delete()
        {
            Console.WriteLine("SQL Server Deleted.");
        }
    }

    class OracleCustomerDal:ICustomerDal
    {
        public void Add()
        {
            Console.WriteLine("Oracle Added.");
        }

        public void Update()
        {
            Console.WriteLine("Oracle Updated.");
        }

        public void Delete()
        {
            Console.WriteLine("Oracle Deleted.");
        }
    }

    class CustomManager
    {
        public void Add(ICustomerDal customerDal)
        {
            customerDal.Add();
            customerDal.Delete();
            customerDal.Update();
        }
    }
}
