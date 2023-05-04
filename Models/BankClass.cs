using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Models;

namespace ATM.Models
{
    internal class BankClass
    {
        //constructors
        public BankClass() { }
        public List<Card> Cards = new() { };
        //fields
        List<User> Clients = new List<User>() { };



        //functions
        public void AddClient(User client)
        {
            Clients.Add(client);
            Cards.Add(client.BankAccount);

            //Cards.Concat(client.BankAccount);
        }
        public decimal ShowCardBalance(Card card)
        {
            return card.Balance;
        }

        //Indexer
        public User this[int index] => Clients[index];

       

        //ToString method

       

        public override string ToString()
        {
            return base.ToString();
        }
    }
}