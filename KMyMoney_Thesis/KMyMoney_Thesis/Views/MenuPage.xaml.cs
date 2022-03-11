using KMyMoney_Thesis.Models;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;



namespace KMyMoney_Thesis.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItem>
            { 
                //new HomeMenuItem {Id = MenuItemType.Browse, Title="Browse" },
                //new HomeMenuItem {Id = MenuItemType.About, Title="About" },
                new HomeMenuItem {Id = MenuItemType.Home, Title="Home" },
                //new HomeMenuItem {Id = MenuItemType.Institutions, Title="Institutions" },
                //new HomeMenuItem {Id = MenuItemType.Accounts, Title="Accounts" },
                //new HomeMenuItem {Id = MenuItemType.Sheduled_transactions, Title="Sheduled_transactions" },
                //new HomeMenuItem {Id = MenuItemType.Categories, Title="Categories" },
                new HomeMenuItem {Id = MenuItemType.Tags, Title="Tags" },
                new HomeMenuItem {Id = MenuItemType.Payees, Title="Payees" },
                new HomeMenuItem {Id = MenuItemType.Ledgers, Title="Ledgers" },
                //new HomeMenuItem {Id = MenuItemType.Investments, Title="Investments" },
                //new HomeMenuItem {Id = MenuItemType.Reports, Title="Reports" },
                //new HomeMenuItem {Id = MenuItemType.Budgets, Title="Budgets" },
                //new HomeMenuItem {Id = MenuItemType.Forecast, Title="Forecast" },
                //new HomeMenuItem {Id = MenuItemType.Outbox, Title="Outbox" }
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                System.Console.WriteLine("====>Selected =" + e.SelectedItem);
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}