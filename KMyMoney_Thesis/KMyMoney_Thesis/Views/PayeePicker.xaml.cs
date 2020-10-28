using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using KMyMoney_Thesis.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KMyMoney_Thesis.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PayeePicker : ContentPage
    {
        public Payee SelectedPayee { get; set; }
        public ObservableCollection<Payee> GetPayees { get; set; }
        public PayeePicker(Payee item)
        {
            InitializeComponent();
            this.SelectedPayee = item;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            PayeeInfo.Text = "The transactions associated with the selected payees " +
                "need to be re-assigned to a different payee before the selected payees " +
                "can be deleted. Please select a payee from the list below.";

            GetPayees = new retrieveDataFromXML().GetPayees();
            ClearPayees(GetPayees);
            pickerPayee.ItemsSource = GetPayees;






            //var monkeyList = new List<string>();
            //pickerPayee.ItemsSource = monkeyList;
        }


        private void ClearPayees(ObservableCollection<Payee> GetPayees)
        {
            foreach (var p in GetPayees)
            {
                if (p.Id == SelectedPayee.Id)
                {
                    GetPayees.Remove(p);
                    break;
                }
            }
        }

        async void ClickedOK(object sender, EventArgs e)
        {
            
        }

        async void ClickedCANCEL(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }

    
}
