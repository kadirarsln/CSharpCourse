using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    class Arrays
    {
        static void Main(string[] args)
        {
            //KISIT: String olarak tanımlanan dizi içersine farklı türde veri yazamayız.
            string[] students = new string[3];
            students[0] = "Kadir";
            students[1] = "neraY";
            students[2] = "Arslan";

            //KISIT: Dizi kaç elemanlıysa sınırı odur fazla eleman girilirse hata verir.
            string[] students2 = { "Kadir", "neraY", "Arslan" };

            foreach( var student in students2)
            {
                Console.WriteLine(student);
            }
            Console.ReadLine();

            string[,] regions = new string[6,3]
            {
                {"İstanbul","İzmit","Balıkesir"},
                { "Ankara","Konya","Kırıkkale"},
                { "Antalya","Adana","Mersin"},
                { "Trabzon","Rize","Samsun"},
                { "İzmir","Muğla","Manisa"},
                { "Diyarbakır","Batman","Siirt"},
            };

            //GetUpperBound ile dizinin ilk girdisini seçiyoruz yani bölgeleri.Aynı zamanda son elemana kadar ilerletiyoruz.

            for (int i = 0; i <= regions.GetUpperBound(0); i++)
            {
                //Burda ise aynı fonksiyon ile şehirleri seçiyoruz.

                for (int j = 0; j <= regions.GetUpperBound(1); j++)
                {
                    Console.WriteLine(regions[i, j]);
                };
                Console.WriteLine("***************");
            };

            Console.ReadLine();
        }
    }
}
