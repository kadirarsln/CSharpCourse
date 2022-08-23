using System;
using System.Collections.Generic;
using System.Reflection;

namespace Reflections
{
    class Program
    {
        static void Main(string[] args)
        {
            //DortIslem dortIslem = new DortIslem(2, 3);
            //Console.WriteLine(dortIslem.Topla2());               //Bizden değer istemiyor çunkü yukarda verdik
            //Console.WriteLine(dortIslem.Topla(3, 4));            //Burda iste bizden değerimizi ister kendimiz parametre vermek istersek.                

            var type = typeof(DortIslem);                          //Çalışacağım tip dortişlem. Parametre olarak alıyoruz.

            /*DortIslem dortIslem = (DortIslem)Activator.CreateInstance(type,6,7);*/          //Çalışma anında direk karar verdiğimiz için bunu kullandık.Yukarıdaki bew leme ile aynı şeydir.Gelen type e göre yapmış oluyoruz.
            //Console.WriteLine(dortIslem.Topla(4,5));                                      //Parametrede verebiliyoruz yukarda 2. işlemdeki gibi.
            //Console.WriteLine(dortIslem.Topla2());                                        //Çalışma anında dinamik instance üretiyoruz.

            var instance = Activator.CreateInstance(type, 6, 7);

            /*Console.WriteLine(instance.GetType().GetMethod("Topla2").Invoke(instance, null));*/   //instance ekledıik topla2 olduğunu bilip bilmediğimiz belli değil diye.
                                                                                                //GetMethod ile istediğimiz methoda ulaşıyoruz.Invoke ile de onu çalıştırıyoruz.
            MethodInfo methodInfo=instance.GetType().GetMethod("Topla2");
            Console.WriteLine(methodInfo.Invoke(instance,null));

            Console.WriteLine("---------------------------------------");
            var metodlar = type.GetMethods();                                 //Parametrelere ulaşıyoruz.      

            foreach (var info in metodlar)
            {
                Console.WriteLine("Metod Adı: {0}",info.Name);
                foreach (var parameterInfo in info.GetParameters())
                {
                    Console.WriteLine("Parametre: {0}",info.Name);
                }

                foreach (var attribute in info.GetCustomAttributes())
                {
                    Console.WriteLine("Attribute Name: {0}",attribute.GetType().Name);
                }
            }

            Console.ReadLine();
        }
    }

    public class MethodNameAttribute:Attribute
    {
        public MethodNameAttribute(string name)
        {
            
        }
    } 

    public class DortIslem
    {
        private int _sayi1;
        private int _sayi2;

        public DortIslem(int sayi1,int sayi2)
        {
            _sayi1 = sayi1;
            _sayi2 = sayi2;
        }
        public DortIslem()
        {
            
        }

        public int Topla(int sayi1, int sayi2)
        {
            return sayi1 + sayi2;
        }

        public int Carp(int sayi1, int sayi2)
        {
            return sayi1 * sayi2;
        }

        public int Topla2()
        {
            return _sayi1 + _sayi2;
        }

        [MethodName("Carpma")]
        public int Carp2()
        {
            return _sayi1 * _sayi2;
        }
    }
}
