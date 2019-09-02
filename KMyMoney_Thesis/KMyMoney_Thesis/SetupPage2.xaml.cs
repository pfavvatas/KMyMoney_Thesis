using KMyMoney_Thesis.Models;
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
    public partial class SetupPage2 : ContentPage
    {
        public Models.PersonalData PersonalData { set; get; }
        public SetupPage2(Models.PersonalData PersonalData) 
        {
            this.PersonalData = PersonalData;
            InitializeComponent();
        }

        void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                PersonalData.Currency = picker.Items[selectedIndex];
            }
        }

        private async void Button_Clicked_To_SetupPage3(object sender, EventArgs e)
        {
            await DisplayAlert("Alert", "" + PersonalData, "OK");
            await Navigation.PushAsync(new SetupPage3(PersonalData));
        }
    }
}