using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using KMyMoney_Thesis.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KMyMoney_Thesis.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Ledgers : ContentPage
    {
        public ObservableCollection<TestBinding2> Items { get; set; }
        public ObservableCollection<String> ledgersItems { get; set; }
        public Ledgers()
        {
            InitializeComponent();

            Items = new ObservableCollection<TestBinding2>
            {
                new TestBinding2 {Date="01/01/2001", Details="BONUS1", Balance="1000"},
                new TestBinding2 {Date="02/01/2001", Details="BONUS2", Balance="2000"},
                new TestBinding2 {Date="03/01/2001", Details="BONUS3", Balance="3000"},
                new TestBinding2 {Date="04/01/2001", Details="BONUS4", Balance="4000"}
            };

            ledgersItems = new ObservableCollection<String>();
            ledgersItems.Add("Ledger_1");
            ledgersItems.Add("Ledger_2");
            if (ledgersItems != null)
            {
                pickerLedgers.ItemsSource = ledgersItems;
            }

            MyListView.ItemsSource = Items;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            await App.Current.MainPage.DisplayAlert("Item Tapped", "ItemIndex = " + e.ItemIndex, "OK");
            await Navigation.PushAsync(new EditLedgersDetails());


            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        async void OnToolbarItemClickedAddNewLedger(object sender, EventArgs args)
        {
            await DisplayAlert("Add", "Add new Ledger", "OK");
            //await Navigation.PushAsync(new InstitutionEdit());
        }
    }
}
