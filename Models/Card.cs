using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ATM.Models
{
    internal class Card
    {
        //constructors
        public Card() { }
        public Card (string bankName, string fullname, string pan, string pin, string cvc, string expiredate, decimal balance)
        {
            BankName = bankName;  FullName = fullname;  PAN = pan; PIN = pin;    CVC = cvc;   ExperienceDate = expiredate;  Balance = balance;
        }


        //fields
        private string _bankName = "", _fullName = "";
        private string _pan = "", _pin = "", _cvc = "", _expireDate = "";    private decimal _balance;

        //properties
        
        public string BankName { get { return _bankName; }
            set { if (value.Length < 3) throw new Exception("short smybols for BANKNAME !!!");   _bankName = value; } }

        public string FullName { get { return _fullName; }  
            set { if (value.Length < 7) throw new Exception("Short symbols for fullName !!!"); _fullName = value; }   }
        public string PAN
        {
            get { return _pan; }
            set
            {
                if (value.Length != 16)
                {
                    throw new ArgumentException("PAN rakamlar sayi uygun (16) diyil !!!");
                }
                if (!Regex.IsMatch(value, @"^[0-9]+$"))
                {
                    Console.WriteLine("PAN ancak sayisal karakterler ala biler...");
                }
                _pan = value;
            }
        }
        public string  PIN {
            get { return _pin; }
            set
            {
                if (value.Length != 4) throw new ArgumentException("Pin uzunlugu dogru deyil ...");
                if (!Regex.IsMatch(value, @"^[0-9]+$"))  throw new ArgumentException("Pin ancaq ededler ichere biler ...");
                _pin = value;
            }
        }
        public string CVC { get; set; }   //CVC bura gonderilerken bir random eded olarag gonderilecek ki, bu halda error emele gelmesi mumkunsuz
        
        public string ExperienceDate 
        { get { return _expireDate; }
            set
            {
                int data = int.Parse(value);  
               
                
                if((data / 100)  > 12 || (data / 100) < 1) 
                { throw new ArgumentException("Ay 12 den boyik ve ya 1 - den kichik ola bilmez ..."); }
                if((data % 100) < 23 )
                {
                     throw new ArgumentException("Kardin etibarlilig ili yalnishtir ...");
                }
                 _expireDate = value ;

                    
            }
        } 
        public decimal Balance { get; set; }       //// Balance random musbet eded gonderileceyi uchun Full Property yazmaya ehtiyyac duyulmadi 


        private  Dictionary<DateTime, string> _cardEmeliyyatlari = new() { };
        public ref Dictionary<DateTime, string>  GetCardOperations() { return ref _cardEmeliyyatlari; }
        public void AddCardOperations(  DateTime KeY , string ValuE)
        {
            _cardEmeliyyatlari.Add(KeY , ValuE);
        }
        

       
    }
}
