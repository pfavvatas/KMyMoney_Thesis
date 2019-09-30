using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System.Diagnostics;
using KMyMoney_Thesis.Views;

using Plugin.FilePicker;

namespace KMyMoney_Thesis
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : ContentPage
    {

        public WelcomePage()
        {
            InitializeComponent();

            
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //Application.Current.MainPage = new NavigationPage(new SetupPage());

            //Application.Current.MainPage = new SetupPage();
            Application.Current.MainPage = new MainPage();
            
        }

        private async void Button_ClickedFile(object sender, EventArgs e)
        {
            
            var file = await CrossFilePicker.Current.PickFile();
            if(file != null)
            {
                Console.WriteLine("============>file= " + file.FilePath);
                //lbl = file.FileName;
            }

            
        }



        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}