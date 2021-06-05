using KMyMoney_Thesis.Views;
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

            

            //PersonalData = new Models.PersonalData();

            //SelectAccountsPosition = SetupPageTable.Root.IndexOf(SelectAccountsTableSection);
            //SelectAccountsTableSelection = SetupPageTable.Root[SetupPageTable.Root.IndexOf(SelectAccountsTableSection)];
            //SelectAccountsFalse();
            //SetupPageTable.Root.Remove(SelectAccountsTableSection);

        }

        void Picker_Currency2(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                PersonalData.Currency = picker.Items[selectedIndex];
            }
        }

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
            //await Navigation.PushAsync(new SetupPage2(PersonalData));
        }

        
        //Account Switch
        private void CheckingAccountSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            //Toggle StackLayout_CheckingAccountDataMoreInfo
            if (StackLayout_CheckingAccountDataMoreInfo.IsVisible)
            {
                StackLayout_CheckingAccountDataMoreInfo.IsVisible = false;
            }
            else
            {
                StackLayout_CheckingAccountDataMoreInfo.IsVisible = true;
            }
        }

        //Currency Picker
        private void Picker_Currency_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                //PersonalData.Currency = picker.Items[selectedIndex];
            }
        }

        //Account type Picker
        private void Picker_Select_Account_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                //PersonalData.Currency = picker.Items[selectedIndex];
                Debug.WriteLine("->Picker_Select_Account_Type_SelectedIndexChanged: " + picker.Items[selectedIndex]);
            }
        }

        //Submit Button
        private  void Button_Submit_Clicked(object sender, EventArgs e)
        {
            bool isEntryValid = true;
            //Check required Entry data
            //
            //Entry_Name
            if (string.IsNullOrEmpty(Entry_Name.Text) || string.IsNullOrWhiteSpace(Entry_Name.Text))
            {
                isEntryValid = false;
                Entry_Name.PlaceholderColor = Color.Red;
            }
            else
            {
                PersonalData.Name = Entry_Name.Text;
            }

            //Entry_Street
            if (string.IsNullOrEmpty(Entry_Street.Text) || string.IsNullOrWhiteSpace(Entry_Street.Text))
            {
                isEntryValid = false;
                Entry_Street.PlaceholderColor = Color.Red;
            }
            else
            {
                PersonalData.Street = Entry_Street.Text;
            }

            //ToDo
            //Continue above and chech is isEntryValid or not to contintue.


            //Application.Current.MainPage = new MainPage();
        }
    }
}