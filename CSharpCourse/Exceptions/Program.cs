using System;
using System.Collections.Generic;
using System.Threading;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            //ExceptionsIntro();

            //TryCatch();

            //Method

            //ActionDemo();

            Func<int, int, int> add = Topla;    //int ler parametre ve sonuç tur.     
                                                //Delegelerdeki gibi topla direkçağırılır.
            Console.WriteLine(add(3,5));

            Func<int> getRandomNumber = delegate()
            {
                Random random = new Random();
                return random.Next(1, 100);
            };

            Thread.Sleep(5000);
            Func<int> getRandomNumber2 = () => new Random().Next(1, 100);

            Console.WriteLine(getRandomNumber());
            Thread.Sleep(1000);                                 //Farklı iki random üretmesi için süre ekledik.
            Console.WriteLine(getRandomNumber2());
            Console.ReadLine();
        }

        static int Topla(int x, int y)
        {
            return x + y;
        }

        private static void ActionDemo()
        {
            HandleExeption(() => //try blokları ve içersindei catch bloklarının artmasından dolayı kullanılabilen methoddur.
            {
                Find();
            });
        }

        private static void TryCatch()
        {
            try
            {
                Find();
            }
            catch (RecordNotFoundException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (Exception exception)
            {
            }
        }

        private static void HandleExeption(Action action)
        {
            try
            {
                action.Invoke();            //Try içersinde Find(); çalıştırıyoruz.
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private static void Find()
        {
            List<string> students = new List<string> { "Kadir", "Yaren", "Arslan" };       //Öğrenci listesi oluşturduk

            if (!students.Contains("Ahmet"))                                               //İçersinde Ahmet yok ise verilecek hatayı yazdık 
            {
                throw new RecordNotFoundException("Record not found");
            }
            else                                                                           //Var ise yazdırılacak sonuç.Else ile
            {
                Console.WriteLine("Record Found!");                                         
            }
        }

        private static void ExceptionsIntro()
        {
            try
            {
                string[] students =
                    new string[3]       //Eğer kodumuzda hata varsa hatalı olabilecek yeri kodu try içersine yazıyoruz.Bakılması gereken yer.
                    {
                        "Engin", "Kadir", "neraY"
                    };

                students[3] = "Arslan";
            }
            catch (IndexOutOfRangeException exception)   //Aldığın hatanın türü bu ise alt kısmı çalıştır. (catch içerisindeki hata)
            {
                                                        //Eğer hata buna denk  değilse farklı bir hata varsa diğerleri için 2.catch bloğu çalışır.
                Console.WriteLine(exception.Message);
            }
            catch (Exception exception) //Kod çalışmayınca ne yazılacağını buraya aktarırız.
            {
                Console.WriteLine(exception.Message); //Bu kısımda hata mesajını görürüz.Loglama işlemi yapmak daha doğrudur.
                throw;
            }
        }
    }
}
