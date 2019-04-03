using System;
using System.Collections.Generic;
using System.Text;

namespace KMyMoney_Thesis.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        Ledgers
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
