using System;

namespace OOP4
{
    class Program
    {
        static void Main(string[] args)
        {
            #region EnCapsulation Kapsülleme
            MyClasss m = new();

            m.Aset(15);
            Console.WriteLine(m.Aget());

            // Property ile 

            #region Property ile 
            m.MyProperty = 2;
            Console.WriteLine(m.MyProperty);
            #endregion



            #endregion

            #region Record 
           
            // Bu özellik sayesinde nesnenin sadece ilk yaratılış anında propertylere deger atanmakta ve böyle
            // iş kuralları gereği runtime da değeri değişmemesi gerkeen nesneşeri için ideal  önlem alınmaktadır
            // Değiştirilemeyen objelerdir


            //          INIT ONLY PROPERTYIES

            Record rcd = new()
            {
                //MyProperty = 3   bu satır hata verir cunku bizim Record clasında ki propertyimiz readonly(sadece get var)

                MyProperty = 3 // Propertye  init yazdığımız için kod hata vermeden set edilebiliyor 
                
            };

            //rcd.Yas = 2;  bu şekşil kullanımda hata verir cunku ınıt only nesnenin ilk yaradılış anında deger alır 
            // sonradan almaz

            #endregion

            #region Record ve  Class Ayrımı 

            MyClasss m1 = new MyClasss()
            {
                MyProperty = 3
            };

            MyRecord m2 = new MyRecord()
            {
                MyProperty = 3
            };

            Console.WriteLine(m1.Equals(m2));   // False değeri dönecektir cunku değerleri aynı olsa da
                                                //  birisi record diğeri record


            MyRecord m3 = new MyRecord()
            {
                MyProperty = 3
            };

            MyRecord m4 = new MyRecord()
            {
                MyProperty = 3
            };
            Console.WriteLine(m3.Equals(m4));  // Eğerm ikisi de Record ve ikisinin de dğeri aynıysa true döndürü

            #endregion
            #region Eğer init olan bir propertyi deeğerini değiştirmek istersek


            MyRecord m5 = new()
            {
                MyProperty = 3,
                MyProperty2 = 10

            };
            MyRecord m6 = m5 with
            {
                MyProperty = 15         // Bu şekilde değiştirilir.
            };




            //m.MyProperty = 10; // hata verir cunku inittir

            // eğerr yukarıda ki degeri değiştirmek istersek





            #endregion

        }
    }

    class MyClasss
    {
        int a;  // default olarak private olur

        #region Eskiden Encapsulation nasıl yapılırdı
        public int Aget()
        {
            if (a > 20)
            {
                return this.a;
            }
            else
            {
                this.a = a / 2;
                return this.a;
            }
        }
        public void Aset(int value)
        {
            value = value / 5;

            this.a = value;
        }


        #endregion

       #region Günümüzde Encapslation nasıl yapılırdı Property ile

        public int MyProperty
        {
            get {
                a = a * 10;
                if (a > 100)
                {
                    return a;

                }
                else
                {
                    return a * 2;
                }
            }
            set {
                a /= 2;
                
                a = value;
            }
        }


        #endregion


        
    }

    //      INIT ONLY PROPERTYIES 

    class Record
    {
        public int MyProperty { get; init; }    // ınıt only için ınıt yazarız


    }

    record MyRecord
    {
        public int MyProperty { get; init; }
        public int MyProperty2 { get; set; }

    } 
    
    class MyClass
    {
        public int MyProperty { get; init; }
        public int MyProperty2 { get; set; }

    }


}
