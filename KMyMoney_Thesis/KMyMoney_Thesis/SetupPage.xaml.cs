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
    public partial class SetupPage : ContentPage
    {
        public Models.PersonalData PersonalData { get; set; }

        public SetupPage()
        {
            InitializeComponent();
            PersonalData = new Models.PersonalData();
            
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

        private void CheckingAccountCheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (CheckingAccountCheckBox.IsChecked)
            {
                AccountName.IsEnabled = false;
                NumberOfTheAccount.IsEnabled = false;
                OpeningDate.IsEnabled = false;
                OpeningBalance.IsEnabled = false;
                NameOfTheInstitution.IsEnabled = false;
                RoutingNumber.IsEnabled = false;
            }
            else
            {
                AccountName.IsEnabled = true;
                NumberOfTheAccount.IsEnabled = true;
                OpeningDate.IsEnabled = true;
                OpeningBalance.IsEnabled = true;
                NameOfTheInstitution.IsEnabled = true;
                RoutingNumber.IsEnabled = true;
            }

            


        }
    }
}