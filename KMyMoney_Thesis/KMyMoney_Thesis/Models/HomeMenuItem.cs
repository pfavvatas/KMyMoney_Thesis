using System;
using System.Collections.Generic;
using System.Text;

namespace KMyMoney_Thesis.Models
{
    public enum MenuItemType
    {
        //Browse,
        //About,
        Home,
        //Institutions,
        //Accounts,
        //Sheduled_transactions,
        //Categories,
        Tags,
        Payees,
        Ledgers,
        //Investments,
        //Reports,
        //Budgets,
        //Forecast,
        //Outbox
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
