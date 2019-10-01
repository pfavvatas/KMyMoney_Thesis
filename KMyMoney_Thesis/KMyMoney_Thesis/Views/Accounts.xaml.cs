using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KMyMoney_Thesis.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using KMyMoney_Thesis.ViewModels;

namespace KMyMoney_Thesis.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Accounts : ContentPage
    {
        //ObservableCollection<TestBinding> test = new ObservableCollection<TestBinding>();
        //ObservableCollection<TestBinding> testB = new ObservableCollection<TestBinding>();
        //public ObservableCollection<TestBinding> Employees { get { return testB; } }

        public ObservableCollection<TestBinding> Test { get; set; }
        public Accounts()
        {
            InitializeComponent();

            Test = new ObservableCollection<TestBinding>
            {
                new TestBinding { TestBindingString = "0"},
                new TestBinding { TestBindingString = "1.1"},

            };

            AccountList.ItemsSource = Test;


        }

        async void OnItemSelected(Object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            //var details = e.Item as TestBinding;
            TestBinding detail = e.Item as TestBinding;
            await DisplayAlert("Alert", "=>"+detail.TestBindingString, "OK");
            //await Navigation.PushAsync(new AccountsDetail(detail));
            await Navigation.PushAsync(new Ledgers());
        }

        async void OnToolbarItemClickedAddNewAccount(object sender, EventArgs args)
        {
            await DisplayAlert("Add", "Add new Account", "OK");
            //await Navigation.PushAsync(new InstitutionEdit());
        }
    }
}