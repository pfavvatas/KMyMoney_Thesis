using System;
using System.Collections.Generic;
using System.Text;

namespace KMyMoney_Thesis.Models
{
    public class PersonalData
    {
        public string Name { get; set; }
        public string Street { get; set; }
        public string Town { get; set; }
        public string Country { get; set; }
        public string Postal_code { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Currency { get; set; }

        //Select Accounts
        public string Name_Of_The_Account { get; set; }
        public string Number_Of_The_Account { get; set; }
        public string Opening_Date { get; set; }
        public string Opening_Balance { get; set; }
        public string Name_Of_The_Institution { get; set; }
        public string Routing_Number { get; set; }
        public string Account_Type { get; set; }
        //

        public override string ToString()
        {
            return $"Name= {Name}," +
                $" Street= {Street}," +
                $" Town= {Town}," +
                $" Country= {Country}," +
                $" Postal Code= {Postal_code}," +
                $" Telephone= {Telephone}," +
                $" Email= {Email},";
        }
    }
}
