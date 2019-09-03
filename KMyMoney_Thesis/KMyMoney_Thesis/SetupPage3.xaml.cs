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
    public partial class SetupPage3 : ContentPage
    {
        //public Models.PersonalData PersonalData { get; set; }
        //public TableSection SelectAccountsTableSelection;
       // public int SelectAccountsPosition;
        public SetupPage3(Models.PersonalData PersonalData)
        {
            //this.PersonalData = PersonalData;
            InitializeComponent();
            //PersonalData = new Models.PersonalData();
            //SelectAccountsPosition = SetupPageTable.Root.IndexOf(SelectAccountsTableSection);
            //SelectAccountsTableSelection = SetupPageTable.Root[SetupPageTable.Root.IndexOf(SelectAccountsTableSection)];
            //SelectAccountsFalse();
            //SetupPageTable.Root.Remove(SelectAccountsTableSection);
        }

        //void Picker_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    var picker = (Picker)sender;
        //    int selectedIndex = picker.SelectedIndex;

        //    if (selectedIndex != -1)
        //    {
        //        PersonalData.Currency = picker.Items[selectedIndex];
        //    }
        //}

        //private void CheckingAccountCheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        //{

        //    //if (!CheckingAccountCheckBox.IsChecked)
        //    //{
        //    //    SelectAccountsFalse();
        //    //    SetupPageTable.Root.Remove(SelectAccountsTableSection);
        //    //}
        //    //else
        //    //{
        //    //    SelectAccountsTrue();
        //    //    SetupPageTable.Root.Add(SelectAccountsTableSelection);
        //    //    //SetupPageTable.Root.Insert(SelectAccountsPosition, SelectAccountsTableSelection);
        //    //}

        //}

        //public void SelectAccountsFalse()
        //{
        //    AccountName.IsEnabled = false;
        //    NumberOfTheAccount.IsEnabled = false;
        //    OpeningDate.IsEnabled = false;
        //    OpeningBalance.IsEnabled = false;
        //    NameOfTheInstitution.IsEnabled = false;
        //    RoutingNumber.IsEnabled = false;
        //}

        //public void SelectAccountsTrue()
        //{
        //    AccountName.IsEnabled = true;
        //    NumberOfTheAccount.IsEnabled = true;
        //    OpeningDate.IsEnabled = true;
        //    OpeningBalance.IsEnabled = true;
        //    NameOfTheInstitution.IsEnabled = true;
        //    RoutingNumber.IsEnabled = true;
        //}

        //private async void Button_Clicked_To_Finish(object sender, EventArgs e)
        //{
        //    PersonalData.Name_Of_The_Account = AccountName.Text;
        //    PersonalData.Number_Of_The_Account = NumberOfTheAccount.Text;
        //    PersonalData.Opening_Date = OpeningDate.Text;
        //    PersonalData.Opening_Balance = OpeningBalance.Text;
        //    PersonalData.Name_Of_The_Institution = NameOfTheInstitution.Text;
        //    PersonalData.Routing_Number = RoutingNumber.Text;
        //    PersonalData.Account_Type = (String)AccountType.SelectedItem;
        //    //await Navigation.PushAsync(new SetupPage4(PersonalData));
        //}
    }
}