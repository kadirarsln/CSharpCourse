using System;

namespace Loops
{
    class Loops
    {
        static void Main(string[] args)
        {
            string[] students2 = { "Kadir", "neraY", "Arslan" };

            //Dizi içersindeki elemanları student olaarak atama yapıyoruz takma isim istediğini verebilirsin.
            //Veri tabanından bir tabloyu çekmek istediğimizde datayı gezmek için kullanırız genellikle.Dolaşılabilir zamanlarda.
            foreach (var student in students2)
            {
                // Bu şekilde içersine farklı eleman ataması yapamayız.
                //student = "ahmet";
                Console.WriteLine(student);
            }
            Console.ReadLine();
        }

        private static void DoWhileLoop()
        {
            //Do çalışır daha sonra şarta bakar. Do en az 1 kere çalışacakır.

            int number = 10;
            do
            {
                Console.WriteLine(number);
                number--;

            } while (number >= 0);
            Console.ReadLine();
        }

        //Belli şart sağlanana kadar döngü devam eder.While içine yazılan koşul.

        private static void WhileLoop()
        {
            int number = 100;
            while (number >= 0)
            {
                Console.WriteLine(number);
                number--;
            }
            Console.ReadLine();
        }

        //ForLoop()
        private static void ForLoop()
        {
            Console.ReadLine();

            for (int i = 100; i >= 0; i = i - 2)
            {
                Console.WriteLine("I Love U");
            }

            Console.WriteLine("Finished!!");
            Console.ReadLine();
        }
    }
}
