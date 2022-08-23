using System;

namespace Delegates
{
    public delegate void MyDelegate();         //Void döndüren ve parametre almayan operasyonlara delegelik yapar.

    public delegate void Mydelegate2(string text);

    public delegate int MyDelegate3(int number1, int number2);

    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.SendMessage();
            customerManager.ShowAlert();

            MyDelegate myDelegate = customerManager.SendMessage;
            myDelegate += customerManager.ShowAlert;

            myDelegate -= customerManager.SendMessage;              //Gönderdiğimiz mesajları yoldayken de çıkarabiliriz.Elçiler gibi hareket ederler.

            Mydelegate2 mydelegate2 = customerManager.SendMessage2;     //string girdiğimiz için bizden string parametreler istiyor.
            mydelegate2 += customerManager.ShowAlert2;

            Matematik matematik = new Matematik();
            MyDelegate3 myDelegate3 = matematik.Topla;
            myDelegate3 += matematik.Carp;                        //Bu işlem ile var sonuç aynı şeydir ancak ilkini gerçekleştirir.
                                                                  //Return type olduğu için ilki yazılır.  
            var sonuc = myDelegate3(2, 3);
            Console.WriteLine(sonuc);

            mydelegate2("Selamkee");
            myDelegate();                                           //Çağırıyoruz üst kısımda delgeye mesajı atıyoruz aynı zamanda toplama yapar gibi ikinci operasyonuda ekleyebiliriz.
        }
    }

    class CustomerManager
    {
        public void SendMessage()              //void olan ve parametre almayan method oluşturduk
        {
            Console.WriteLine("Hello!");
        }

        public void ShowAlert()
        {
            Console.WriteLine("Be Careful!");
        }

        public void SendMessage2(string message)              //void olan ve parametre almayan method oluşturduk
        {
            Console.WriteLine(message);
        }

        public void ShowAlert2(string alert)
        {
            Console.WriteLine(alert);
        }
    }

    public class Matematik
    {
        public int Topla(int sayi1,int sayi2)
        {
            return sayi1 + sayi2;
        }
        public int Carp(int sayi1, int sayi2)
        {
            return sayi1 + sayi2;
        }
    }
}
