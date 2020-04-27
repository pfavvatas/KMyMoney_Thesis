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
            PayeeDetailsData tdd = new PayeeDetailsData();
            //  1)
            //tdd.Tag = item; ///eisagwgh tou Tag


            //ObservableCollection<Transaction> Transactions;
            //Transactions = new retrieveDataFromXML().GetTransactions();
            //List<Transaction> TransactionsWithTag = new List<Transaction>();
            //foreach (var trans in Transactions)
            //{
            //    foreach (var splits in trans.Splits)
            //    {
            //        foreach (var tags in splits.Tag)
            //        {
            //            /// Using this if, we get the transactions
            //            /// with the tag, that we're looking for.
            //            if (tags.Id == tdd.Tag.Id)
            //            {
            //                TransactionsWithTag.Add(trans);
            //            }
            //        }
            //    }
            //}
            ////  2)
            //tdd.TagTransactionsList = TransactionsWithTag; ///eisagwgh tou Transaction

            /// Sending the data to a new Page.
            //await Navigation.PushAsync(new TagMore(tdd)); ///apostolh twn pliroforiwn stin selida
        }
    }
}
