using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml;
using System.Linq;
using KMyMoney_Thesis.Model;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using log4net;

namespace KMyMoney_Thesis.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Tags : ContentPage
    {
        ILog log = log4net.LogManager.GetLogger(typeof(Tags));        

        public ObservableCollection<String> TestPayee { get; set; }
        private int _id;

        public ObservableCollection<Tag> TagsObs { get; set; }
        public ObservableCollection<Tag> test666 { get; set; }
        public ObservableCollection<Tag> tempdata;
        public IEnumerable<Tag> tempdataSearch;

        public Tags()
        {
            Console.WriteLine("*******InitializeComponent()*******");
            InitializeComponent();
            InitializePickertags();
        }

        protected override void OnAppearing()
        {
            Console.WriteLine("*******OnAppearing()*******");
            base.OnAppearing();
            //TagList.ItemsSource = new retrieveDataFromXML().GetTags();
            tempdata = new retrieveDataFromXML().GetTags();
            //TagList.ItemsSource = tempdata;
            OnTextChanged(null, null);            
        }

        void InitializePickertags()
        {
            Console.WriteLine("*******InitializePickertags()*******");
            var tagPickerList = new List<string>();
            tagPickerList.Add("All");
            tagPickerList.Add("Used");
            tagPickerList.Add("Unused");
            tagPickerList.Add("Opened");
            tagPickerList.Add("Closed");

            TagPicker.ItemsSource = tagPickerList;
            TagPicker.SelectedIndex = 0;
        }

        void OnTextChanged(object sender, EventArgs e)
        {
            Console.WriteLine("*******OnTextChanged()*******");
            log.Info("*******OnTextChanged*******");
            try
            {
                TagList.ItemsSource = !string.IsNullOrEmpty(TagSearchBar.Text)
                ? tempdata.Where(item => item.Name.ToLower().Contains(TagSearchBar.Text.ToLower()))
                : tempdata;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message.ToString(), ex);
                log.Error("Error Message: " + ex.Message.ToString(), ex);
            }            
        }

        void TagPickerSelected(object sender, EventArgs e)
        {
            Console.WriteLine("*******TagPickerSelected()*******");
            //ToDo: prepei na dw sto object an prepei na mpei extra
            //    pliroforia gia na mpei sto .Where, wste na gurnaei
            //    swsta thn anazhthsh.
            
        }

        async void AddNewTag(object sender, EventArgs e)
        {
            Console.WriteLine("*******AddNewTag()*******");
            string result = await DisplayPromptAsync("Add new Tag", "", initialValue: string.Empty);
            if (result != null)
            {
                new retrieveDataFromXML().AddNewTag(result);
                TagList.ItemsSource = new retrieveDataFromXML().GetTags();
            }            
        }

        void ClickedMore(object sender, EventArgs e)
        {
            Console.WriteLine("*******ClickedMore()*******");
            var menu = sender as MenuItem;
            var item = menu.CommandParameter as Tag;
            showMore(item);
        }

        async void ClickedDelete(object sender, EventArgs e)
        {
            Console.WriteLine("*******ClickedDelete()*******");
            var menu = sender as MenuItem;
            var item = menu.CommandParameter as Tag;
            bool answer = await DisplayAlert("Delete " + item.Name + " ?", null, "Yes", "No");
            if (answer)
            {               
                new retrieveDataFromXML().DeleteTag(item.Id);
                TagList.ItemsSource = new retrieveDataFromXML().GetTags();
            }
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
        void OnItemTapped(Object sender, ItemTappedEventArgs e)
        {
            Console.WriteLine("*******OnItemTapped()*******");
            ///Den mas polu endiaferoun oi parakatw 3 grammes kwdika
            if (e.Item == null)
                return;

            showMore(e.Item as Tag);
        }

        async private void showMore(Tag item)
        {
            Console.WriteLine("*******showMore()*******");
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
