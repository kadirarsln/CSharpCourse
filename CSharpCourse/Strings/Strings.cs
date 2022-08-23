using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    class Strings
    {
        static void Main(string[] args)
        {
            //1- Cumledeki karakter sayısı boşluklar dahildir.

            string sentence = "My name is Kadir";
            var result = sentence.Length;
            Console.WriteLine(result);
            Console.ReadLine();

            //-------------------------------------------------
            //2- Cümle hangi harf , karakter ile Biter(end) ve Başlar(start).

            bool result2 = sentence.EndsWith("r");
            bool result3 = sentence.StartsWith("My name");
            Console.WriteLine(result2);
            Console.WriteLine(result3);
            Console.ReadLine();

            //-------------------------------------------------
            //3- Cümle içersinde aranacak kelime.(Index). 2. adımda da boşluğu arar ve bulunca durur.

            var result4 = sentence.IndexOf("Kadir");
            var result5 = sentence.IndexOf(" ");
            Console.WriteLine(result4);
            Console.WriteLine(result5);
            Console.ReadLine();

            //-------------------------------------------------
            //4- Cümle içine kelime veya harf eklemek.

            var result6 = sentence.Insert(0, "Hello ");
            Console.WriteLine(result6);
            Console.ReadLine();

            //-------------------------------------------------
            //5- Hangi karakterden başlayacağını seçer. 2. işlemde ise 4 ekleyerek 3. karakterden sonra kaç adet alacağını seçeriz.

            var result7 = sentence.Substring(3);
            var result8 = sentence.Substring(3,4);

            Console.WriteLine(result7);
            Console.WriteLine(result8);
            Console.ReadLine();

            //-------------------------------------------------
            //6- Bütün Karakterleri küçük(lower) karaktere çevirir. Aynı şekilde büyük(upper) karakterlere çevirebiliriz.

            var result9 = sentence.ToLower();                   //Bütün Karakterleri küçük(Lower) karaktere çevirir.
            var result10 = sentence.ToUpper();                  //Bütün Karakterleri Büyük(Upper) karaktere çevirir.
            Console.WriteLine(result9);
            Console.WriteLine(result10);
            Console.ReadLine();

            //-------------------------------------------------
            //7-Bir metinde değiştirmek istediğin karakteri seçer(1.) ve yerine ne geleceğini(2.) belirlersin.(Replace)
            //Alt 2.kısımda ise belli bir yerden sonrasını çıkarmak atmak için kullanırız.(Remove). 

            var result11 = sentence.Replace(" ", "-");         //Boşluk yerıne tire(-) işareti gelir.
            var result12 = sentence.Remove(2);                 //My den sonrası atılır.
            var result13 = sentence.Remove(2,5);               //Kaçıncıdan sonra kaç karakter atılacağını seçer. 2.index
            Console.WriteLine(result11);
            Console.WriteLine(result12);
            Console.WriteLine(result13);
            Console.ReadLine();
        }


        private static void Intro()
        {
            //Stringler birer char dizisidir.

            string city = "Ankara";

            //Ekrana A harfi dizinin ilk elemanı yazılır.
            Console.WriteLine(city[0]);
            Console.ReadLine();

            //Butun elemanlar tek tek döngüde yazılır.
            foreach (var item in city)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();

            string city2 = "İstanbul";
            string result = city + city2;
            Console.WriteLine(result);
            Console.ReadLine();

            // yukarıdakı işlem de dahil stringlerde toplama yapar.
            Console.WriteLine(String.Format("{0} {1}", city, city2));

            Console.ReadLine();
        }
    }
}
