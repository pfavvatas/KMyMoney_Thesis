using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using KMyMoney_Thesis.Model;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KMyMoney_Thesis.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Tags : ContentPage
    {
        public ObservableCollection<String> TestPayee { get; set; }
        private int _id;

        public ObservableCollection<Tag> TagsObs { get; set; }

        public Tags()
        {
            InitializeComponent();
            TagList.ItemsSource = new retrieveDataFromXML().GetTags();
        }

        private void New_Clicked(object sender, EventArgs e)
        {
            ///akoma tpt....
        }

        public class TagDetailsData
        {
            public Tag Tag { get; set; }
            public List<Transaction> TagTransactionsList { get; set; }
        }

        ///Otan epileksei o xristis to tag pou thelei na dei
        ///tote, se auti ti fasi, prin tou anoiksei h kartela me tis plirofories,
        ///psaxnei sto xml arxeio se poio transaction uparxei to tag
        ///kai to pernaei sti lista pou tha ta emfanizei.        
        async void OnItemSelected(Object sender, ItemTappedEventArgs e)
        {
            ///Den mas polu endiaferoun oi parakatw 3 grammes kwdika
            if (e.Item == null)
                return;
            //Console.WriteLine("==========>sender: " + e.ItemIndex);

            ///Apo edw ksekiname
            ///Exei ftiaxtei class wste na perasoun oi ksexwristes
            ///plirofoies Tag kai Transaction se ena.
            TagDetailsData tdd = new TagDetailsData();
            //  1)
            tdd.Tag = e.Item as Tag; ///eisagwgh tou Tag

            
            ObservableCollection<Transaction> Transactions;
            Transactions = new retrieveDataFromXML().GetTransactions();
            List<Transaction> TransactionsWithTag = new List<Transaction>();
            foreach (var trans in Transactions)
            {
                foreach (var splits in trans.Splits)
                {
                    foreach (var tags in splits.Tag)
                    {
                        /// Using this if, we get the transactions
                        /// with the tag, that we're looking for.
                        if (tags.Id == tdd.Tag.Id)
                        {
                            TransactionsWithTag.Add(trans);
                        }
                    }
                }
            }
            //  2)
            tdd.TagTransactionsList = TransactionsWithTag; ///eisagwgh tou Transaction
            
            /// Sending the data to a new Page.
            await Navigation.PushAsync(new TagMore(tdd)); ///apostolh twn pliroforiwn stin selida
        }

    }
}
