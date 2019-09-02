using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public TableSection SelectAccountsTableSelection;
        public int SelectAccountsPosition;
        public SetupPage()
        {
            InitializeComponent();
            PersonalData = new Models.PersonalData();
            //SelectAccountsPosition = SetupPageTable.Root.IndexOf(SelectAccountsTableSection);
            //SelectAccountsTableSelection = SetupPageTable.Root[SetupPageTable.Root.IndexOf(SelectAccountsTableSection)];
            //SelectAccountsFalse();
            //SetupPageTable.Root.Remove(SelectAccountsTableSection);

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

        /*
        private void CheckingAccountCheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {

            if (!CheckingAccountCheckBox.IsChecked)
            {
                SelectAccountsFalse();
                SetupPageTable.Root.Remove(SelectAccountsTableSection);
            }
            else
            {
                SelectAccountsTrue();
                SetupPageTable.Root.Add(SelectAccountsTableSelection);
                //SetupPageTable.Root.Insert(SelectAccountsPosition, SelectAccountsTableSelection);
            }         

        }

        public void SelectAccountsFalse()
        {
            AccountName.IsEnabled = false;
            NumberOfTheAccount.IsEnabled = false;
            OpeningDate.IsEnabled = false;
            OpeningBalance.IsEnabled = false;
            NameOfTheInstitution.IsEnabled = false;
            RoutingNumber.IsEnabled = false;
        }

        public void SelectAccountsTrue()
        {
            AccountName.IsEnabled = true;
            NumberOfTheAccount.IsEnabled = true;
            OpeningDate.IsEnabled = true;
            OpeningBalance.IsEnabled = true;
            NameOfTheInstitution.IsEnabled = true;
            RoutingNumber.IsEnabled = true;
        }
        */

        private async void Button_Clicked_To_SetupPage2(object sender, EventArgs e)
        {
            PersonalData.Name = Entry_Name.Text;
            PersonalData.Street = Entry_Street.Text;
            PersonalData.Town = Entry_Town.Text;
            PersonalData.Country = Entry_Country.Text;
            PersonalData.Postal_code = Entry_Postal_Code.Text;
            PersonalData.Telephone = Entry_Telephone.Text;
            PersonalData.Email = Entry_Email.Text;            
            await DisplayAlert("Alert", ""+ PersonalData, "OK");
            //Debug.WriteLine("=========================Output "+ Entry_Name.Text);
            await Navigation.PushAsync(new SetupPage2(PersonalData));
        }
    }
}