using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeEgitim
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /*   //int sayi1 = 10;
               //int sayi2 = 20;
               //sayi1 = sayi2;
               //sayi2 = 100;

               //Console.WriteLine(sayi1);


               //int[] sayilar1 = new [] {1,2,3,4 };
               //int[] sayilar2 = new[] { 10, 20, 30, 40 };
               //sayilar1 = sayilar2;

               //sayilar2[0] = 100;

               //Console.WriteLine(sayilar1[0]); */




            // CreditManager creditManager = new CreditManager();
            // creditManager.Calculate();
            // creditManager.Calculate();
            // creditManager.Calculate();



            // Customer customer = new Customer();   // örneği oluşturmak, instance oluşturmak, instance creation
            // customer.Id = 1;
            // customer.City = "Istanbul";



            // CustomerManager customerManager = new CustomerManager(customer);
            // customerManager.save( );
            // customerManager.Delete( );

            // Company company = new Company(); // inherite
            // company.TaxNumber= "10000";
            // company.CompanyName = "Arçelik";
            // company.Id = 100;


            //CustomerManager companyManager2 = new CustomerManager( new Person());




            // Person person = new Person();
            // person.FirstName = "Ege";
            // person.LastName = "Çayan";
            // person.NationalIdentity = "00000000000";

            // Customer c1 = new Customer();
            // Customer c2 = new Person();
            // Customer c3 = new Company();


            // Ioc Container 
            CustomerManager customerManager = new CustomerManager(new Customer(), new TeacherCreditManager());
            customerManager.GiveCredit();
            Console.ReadLine();


        }

        class CreditManager  // CreditYonetici         //  1. Classın içinde operation tutuldu
        {
            public void Calculate(int creditType)    //Hesapla Metodu 
            {
                if (creditType == 1) // esnaf
                {

                }
                if (creditType == 2) //ogretmen
                {

                }

                Console.WriteLine("Hesaplandı");
            }

            public void Save() // Kredi Hesaplandı onaylandı verildi Metodu
            {

                Console.WriteLine("Kredi verildi");
            }
        }
        interface ICreditManager
        {
            void Calculate();                   // CreditManager classındakı metodun imzası
            void Save();                        // CreditManager classındakı metodun imzası
        }

        abstract class BaseCreditManager : ICreditManager
        {
            public abstract void Calculate();

            public virtual void Save()
            {
                Console.WriteLine("Kaydedildi");
            }
        }

        class TeacherCreditManager : BaseCreditManager, ICreditManager
        {
            public override void Calculate()    // override ustune yaz demek 
            {
                // hesaplamalar
                Console.WriteLine("Öğretmen kredisi Hesaplandı");
            }

            public override void Save()
            {
                //Kod yazabilrisin
                base.Save();
                // başka bir kod yazılabilir
            }


        }

        class MilitaryCreditManager : BaseCreditManager, ICreditManager
        {
            public override void Calculate()
            {
                Console.WriteLine("Asker kredisi Hesaplandı");
            }



            //Property 
            class Customer // Müşteri               // 2. Classın içie özellikler tutuldu 
            {
                public Customer()                      // Constract
                {
                    Console.WriteLine("müşteri nesnesi başlatıldı");
                }
                public int Id { get; set; }

                public string NationalIdentity { get; set; }
                public string City { get; set; }

            }


            class Person : Customer
            {
                public string FirstName { get; set; }
                public string LastName { get; set; }
                public string NationalIdentity { get; set; }
            }

            class Company : Customer   //inheritance    ( Şirket  Muşterişi nesnesinden inherit olur  )
            {

                public string CompanyName { get; set; }
                public string TaxNumber { get; set; }

            }


            // Katmanlı Mimariler             // görevleri birbirinden ayırıyoruz
            class CustomerManager
            {
                private Customer _customer;
                private ICreditManager _creditManager;
                public CustomerManager(Customer customer, ICreditManager creditManager)
                {
                    _customer = customer;
                    _creditManager = creditManager;
                }
                public void save()
                {
                    Console.WriteLine("Müşteri Kaydedildi :");
                }


                public void Delete()
                {
                    Console.WriteLine("Müşteri silme :");
                }

                public void GiveCredit() // Müşteriye credit vereceğiz
                {
                    _creditManager.Calculate();
                    Console.WriteLine("Kredi verildi");
                }
            }

        }
    }
}
