using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Models
{
    internal class User
    {
       
        //Constructors 
        public User () { }
        public User (Guid id, string name, string surname,short age, decimal salary, Card bankCard  )
        {
            Id = id;  Name = name; Surname = surname;    Age = age;   Salary = salary;   BankAccount = bankCard;
        }

        //Fields
        private string _name = "", _surname = "";  public short _age; public decimal _salary; private Card _bankAccount;

        //Properties
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get { return _surname; } set { if (value.Length < 3) throw new ArgumentException("Bu qeder qisa Surname not existed .."); _surname = value; } }
        public short Age { get { return this._age; } set { if (value < 18) throw new Exception("Yashiniz azdir ..."); _age = value; } }

        public decimal  Salary { get { return _salary; } set { if (value < 0) throw new ArgumentException("salary menfi ola bilez )))");  _salary = value; } }
        public Card BankAccount { get;set; }
        
        //public   List<Card> BankAccount = new() {  };   // buraya kankret olaraq Card verilecey ve yoxlanmalara ehtiyyac duymadim 
        
        //public void AddAccountToUser(Card newCard)
        //{
        //    BankAccount.Add(newCard);
        //}
    
    }
}

