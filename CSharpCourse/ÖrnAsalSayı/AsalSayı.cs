using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ÖrnAsalSayı
{
    class AsalSayı
    {
        static void Main(string[] args)
        {
            if (IsPrimeNumber(6))
            {
                Console.WriteLine("This is a PrimeNumber");
            }
            else
                Console.WriteLine("This is a not PrimeNumber.");

            Console.ReadLine();
        }
            private static bool IsPrimeNumber(int number)
            {
                bool result = true;
                for (int i = 2; i < number-2; i++)
                {
                    if (number%i==0)
                    {
                        result = false;
                        i=number;
                    }                  
                }
            return result;
        }
        
    }
}
