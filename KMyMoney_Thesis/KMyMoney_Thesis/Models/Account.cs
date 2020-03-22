using System;


namespace KMyMoney_Thesis.Models
{
    public class Account
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string Type { get; set; }
        public string Opened { get; set; }
        public string Currency { get; set; }

        public override string ToString()
        {
            return "ID: " + Id + "   Name: " + Name + "   Type: " + Type + "   Opened: " + Opened + "   Currency: " + Currency;
        }
    }

    
}

