using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KMyMoney_Thesis
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KmmFirstTime : ContentPage
    {
        public KmmFirstTime()
        {
            InitializeComponent();
        }

        async void SetupButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new SetupPage());
        }

        async void OpenButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new SetupPage());
        }
    }
}