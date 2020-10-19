using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KMyMoney_Thesis.Model;
using KMyMoney_Thesis.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static KMyMoney_Thesis.Views.Payees;

namespace KMyMoney_Thesis.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PayeeMore : TabbedPage
    {
        public Payee _payee { get; set; }
        public PayeeMore(PayeeDetailsData pdd)
        {
            InitializeComponent();
            Title = pdd.Payee.Name;
            Payee payee = pdd.Payee;
            ObservableCollection<Transaction> Transactions = new ObservableCollection<Transaction>(pdd.PayeeTransactionsList);

            setBalance(Transactions);

            TransactionsList.ItemsSource = Transactions;

            _payee = payee;

            //AccountList2.ItemsSource = Test2;
        }

        async void OnItemTapped(Object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            Transaction item = e.Item as Transaction;
            System.Console.WriteLine(item);
            System.Console.WriteLine(item.Id);

        }

        private void setBalance(ObservableCollection<Transaction> Transactions)
        {
            double balanceD = 0.0;
            foreach (var c in Transactions)
            {

                string[] spl = c.Splits[0].Value.Split(new[] { "/" }, StringSplitOptions.None);
                balanceD += double.Parse(spl[0]);

            }
            if (balanceD > 0)
            {
                Balance.Text = "+ " + balanceD + "$";
                Balance.TextColor = Color.Green;
            }
            else
            {
                Balance.Text = "- " + balanceD + "$";
                Balance.TextColor = Color.Red;
            }
        }

        async void ClickedDelete2(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Delete " + _payee.Name + " ?", null, "Yes", "No");
            if (answer)
            {
                new retrieveDataFromXML().DeletePayee(_payee.Id,"");
                await Navigation.PopAsync();
            }
        }

        async void ClickedEdit(object sender, EventArgs e)
        {
            _payee.Name = PayeeName.Text;
            //_tag.Notes = TagNotes.Text;
            //_tag.Closed = TagCheckBox1.IsChecked ? "1" : "0";
            //new retrieveDataFromXML().UpdateTag(_tag);
            await Navigation.PopAsync();
        }
    }
}
