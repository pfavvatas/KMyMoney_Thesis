using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using KMyMoney_Thesis.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KMyMoney_Thesis.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Payees : ContentPage
    {
        public ObservableCollection<Payee> Payee { get; set; }
        private int _id;
        public Payees()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Payee = new retrieveDataFromXML().GetPayees();
            foreach (var cl in Payee)
            {
                Console.WriteLine(cl.ToString());
                //or print the property of your class
            }
            PayeeList.ItemsSource = Payee;
        }

        async void AddNewPayee(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Add new Payee", "", initialValue: string.Empty);
            if (result != null)
            {
                new retrieveDataFromXML().AddNewTag(result);
                PayeeList.ItemsSource = new retrieveDataFromXML().GetPayees();
            }
        }

        void ClickedMore(object sender, EventArgs e)
        {
            var menu = sender as MenuItem;
            var item = menu.CommandParameter as Payee;
            showMore(item);
        }

        async void ClickedDelete(object sender, EventArgs e)
        {
            var menu = sender as MenuItem;
            var item = menu.CommandParameter as Payee;
            bool answer = await DisplayAlert("Delete " + item.Name + " ?", null, "Yes", "No");
            if (answer)
            {
                new retrieveDataFromXML().DeleteTag(item.Id);
                PayeeList.ItemsSource = new retrieveDataFromXML().GetPayees();
            }
        }

        public class PayeeDetailsData
        {
            //public Tag Tag { get; set; }
            //public List<Transaction> TagTransactionsList { get; set; }
            public Payee Payee { get; set; }
            public List<Transaction> PayeeTransactionsList { get; set; }

            public override string ToString()
            {
                return "Payee=["+ Payee.ToString() + "], PayeeTransactionsList=[" + ToStringListItem(PayeeTransactionsList) + "]";
            }

            public string ToStringListItem(List<Transaction> items)
            {
                var output = "";
                foreach(var item in items)
                {
                    output += item.ToString();
                }
                return output;
            }
        }

        async void OnItemSelected(Object sender, ItemTappedEventArgs e)
        {
            ///Den mas polu endiaferoun oi parakatw 3 grammes kwdika
            if (e.Item == null)
                return;

            showMore(e.Item as Payee);
        }

        async private void showMore(Payee item)
        {
            ///Apo edw ksekiname
            ///Exei ftiaxtei class wste na perasoun oi ksexwristes
            ///plirofoies Tag kai Transaction se ena.
            PayeeDetailsData pdd = new PayeeDetailsData();
            //  1)
            pdd.Payee = item; ///eisagwgh tou Payee


            ObservableCollection<Transaction> Transactions;
            Transactions = new retrieveDataFromXML().GetTransactions();
            List<Transaction> PayeeTransactions = new List<Transaction>();
            Console.WriteLine("Transactions =>" + Transactions.Count);
            foreach (var trans in Transactions)
            {
                Console.WriteLine("trans.Splits =>" + trans.Splits.Count);
                foreach (var splits in trans.Splits)
                {
                    /// Using if, we get the transaction
                    //  with the payee id that we're looking for.
                    //  Once we find it, get the transaction
                    //  and go to the next one (NOT Payee)
                    if (splits.Payee == item.Id)
                    {
                        PayeeTransactions.Add(trans);
                        break;
                    }
                }
            }
            //  2)
            pdd.PayeeTransactionsList = PayeeTransactions; ///eisagwgh tou Transaction

            //Console.WriteLine("pdd =>" + pdd.ToString());
            // Sending the data to a new Page.
            await Navigation.PushAsync(new PayeeMore(pdd)); ///apostolh twn pliroforiwn stin selida
        }
    }
}
