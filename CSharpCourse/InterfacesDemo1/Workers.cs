using System;

namespace InterfacesDemo1
{
    class Manager : IWorker, IEat, ISalary
    {
        public void Eat()
        {
            Console.WriteLine("Meal time for Managers.");
        }

        public void Work()
        {
            Console.WriteLine("Work time for Managers.");

        }

        public void GetSalary()
        {
            Console.WriteLine("Salary time for Managers.");
        }
    }

    class NormalWorker : IWorker, IEat, ISalary
    {
        public void Eat()
        {
            Console.WriteLine("Meal time for NormalWorker.");
        }

        public void Work()
        {
            Console.WriteLine("Work time for NormalWorkers.");
        }

        public void GetSalary()
        {
            Console.WriteLine("Salary time for NormalWorkers.");
        }
    }

    class Robot : IWorker
    {
        public void Work()
        {
            Console.WriteLine("Work time for Robots.");
        }
    }

}
