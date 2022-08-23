using System;
using System.Linq;


namespace Mtehods
{
    class Methods
    {
        static void Main(string[] args)
        {
            Method();

            // Method içine number tanımladığımız için Number(); eklerken içinin doldurulması gerekir. Ya da tanımlanması.
            Number(44,33) ;
            
            Console.ReadLine();
        }
        static void Method()
        {
            string ad = (Console.ReadLine());
            Console.WriteLine("Adınız: " +ad);

            Console.WriteLine(Carpma(2 , 4));
            Console.WriteLine(Carpma(2, 4, 5));
            Console.WriteLine(Params(1 , 2, 4, 5 , 6 , 7));
        }

        // int olarak number girdiğimiz için static int şeklinde tanımladık.

        static int Number(int number1,int number2)
        {
            var result = number1 + number2;
            return result;
        }

        // İki adet methot ekledik kullanıcı isterse 2 sayı girer isterse de 3 ayrı method ismi yazmadan ve yazdırmadan halledildi.
        static int Carpma(int number1, int number2)
        {
            var result = number1 * number2;
            return result;
        }
        static int Carpma(int number1, int number2,int number3)     //Methods Overloading.
        {
            var result = number1 * number2 * number3;
            return result;
        }

        // Birden fazla sayı için kullanıyoruz params dizi şeklinde.
        static int Params(int number , params int[] numbers)
        {
            return numbers.Sum();
        }
    }
}
