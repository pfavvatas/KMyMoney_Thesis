using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml;
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
        public ObservableCollection<Tag> test666 { get; set; }

        public Tags()
        {
            InitializeComponent();

            //test
            //string data = DependencyService.Get<IFileReadWrite>().ReadData("MyFileXML.txt");
            //XmlDocument doc = new XmlDocument();
            //doc.Load(new StringReader(data));
            //XmlNodeList splitNodes = doc.SelectNodes("//TAG[@id='G000001']");
            //Console.WriteLine("splits => " + splitNodes.Count);
            //foreach(XmlNode s in splitNodes)
            //{
            //    Console.WriteLine("s=> " + s.ParentNode.ParentNode.InnerXml);
            //}

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //your code here;
            Console.WriteLine("Mpike sta tags OnAppearing...");
            TagList.ItemsSource = new retrieveDataFromXML().GetTags();

        }

        async void AddNewTag(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Add new Tag", "", initialValue: string.Empty);
            Console.WriteLine("result = " + result);
            new retrieveDataFromXML().AddNewTag(result);
            TagList.ItemsSource = new retrieveDataFromXML().GetTags();
        }

        void ClickedMore(object sender, EventArgs e)
        {
            var menu = sender as MenuItem;
            var item = menu.CommandParameter as Tag;
            showMore(item);
        }

        void ClickedDelete(object sender, EventArgs e)
        {
            var menu = sender as MenuItem;
            var item = menu.CommandParameter as Tag;
            new retrieveDataFromXML().DeleteTag(item.Id);
            TagList.ItemsSource = new retrieveDataFromXML().GetTags();
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

            showMore(e.Item as Tag);
        }

        async private void showMore(Tag item)
        {
            ///Apo edw ksekiname
            ///Exei ftiaxtei class wste na perasoun oi ksexwristes
            ///plirofoies Tag kai Transaction se ena.
            TagDetailsData tdd = new TagDetailsData();
            //  1)
            tdd.Tag = item; ///eisagwgh tou Tag


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
