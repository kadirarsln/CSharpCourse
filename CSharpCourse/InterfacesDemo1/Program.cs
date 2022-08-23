using System;

namespace InterfacesDemo1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*************************************************************");
            IWorker[] workers = new IWorker[3]            //Çalışma eylemini Array şeklinde newliyoruz.
            {
                new Manager(),                            // Çalışanları da çalışma eylemi için newliyoruz.
                new NormalWorker(),
                new Robot()
            };
            foreach (var worker in workers)               //Daha sonra çalışma eylemi için çalışanalrı döngüye alıp getiriyouz.
            {
                worker.Work();
            }

            Console.WriteLine("*************************************************************");
            Console.ReadLine();
            Console.WriteLine("*************************************************************");

            //-------------------------------------------------------------------------------------------------------------------
            IEat[] eats = new IEat[2]                     //Aynı şeyler eat eylemi için de geçerlidir.
            {
                new Manager(),
                new NormalWorker()
            };
            foreach (var eat in eats)
            {
                eat.Eat();
            }

            Console.WriteLine("*************************************************************");
            Console.ReadLine();
            Console.WriteLine("*************************************************************");

            //-------------------------------------------------------------------------------------------------------------------
            ISalary[] salarys = new ISalary[2]
            {
                new Manager(),
                new NormalWorker()
            };
            foreach (var salary in salarys)
            {
                salary.GetSalary();
            }
            Console.WriteLine("*************************************************************");
            Console.ReadLine();
        }
    }
}
