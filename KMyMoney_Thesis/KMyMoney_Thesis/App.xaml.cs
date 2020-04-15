 using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using KMyMoney_Thesis.Views;
using KMyMoney_Thesis.DataStorage;
using System.Collections.Generic;
using SQLite;
using KMyMoney_Thesis.Model;
[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace KMyMoney_Thesis
{
    public partial class App : Application
    {
        public static string DatabaseLocation = string.Empty;

        
        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new Accounts());
            Application.Current.MainPage = new WelcomePage();

        }

        public App(string databaseLocation)
        {
            InitializeComponent();
            Application.Current.MainPage = new WelcomePage();
            //Application.Current.MainPage = new Accounts();

            //MainPage = new NavigationPage(new WelcomePage());

            DatabaseLocation = databaseLocation;
            new SQLiteDb(DatabaseLocation);

            
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
