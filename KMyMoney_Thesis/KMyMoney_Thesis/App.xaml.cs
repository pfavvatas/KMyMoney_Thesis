using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using KMyMoney_Thesis.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace KMyMoney_Thesis
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();


            //MainPage = new MainPage();
            MainPage = new NavigationPage(new SplashPage());
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
