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

namespace KMyMoney_Thesis.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TagMore : TabbedPage
    {
        //public ObservableCollection<Transaction> Transactions;
        public ObservableCollection<String> colors { get; set; }

        public ObservableCollection<Transaction> tt { get; set; }


        public Tag _tag { get; set; }
        //public ObservableCollection<String> colors;
        public TagMore(Tags.TagDetailsData tdd)
        {
            Tag tag = tdd.Tag;
            InitializeComponent();
            ObservableCollection<Transaction> Transactions;
            Transactions = new retrieveDataFromXML().GetTransactions();
            //TransactionsList.ItemsSource = Transactions;
            ObservableCollection<Transaction> TransactionsWithTag = new ObservableCollection<Transaction>(tdd.TagTransactionsList);
            //foreach (var trans in Transactions)
            //{
            //    foreach(var splits in trans.Splits)
            //    {
            //        Console.WriteLine("Split ID => " + splits.Id);
            //        foreach(var tags in splits.Tag)
            //        {
            //            if(tags.Id == tag.Id)
            //            {
            //                TransactionsWithTag.Add(trans);
            //                Console.WriteLine("prepei na emfanisi to transaction me id " + trans.Id);
            //            }
            //            //Console.WriteLine("Tag ID => " + tags.Id);
            //        }
            //    }
            //}
            TransactionsList.ItemsSource = TransactionsWithTag;

            Console.WriteLine("~/TagMore => "+tag.Name+","+tag.Id);
            _tag = tag;
            TagName.Text = tag.Name;
            TagId.Text = tag.Id;
            //TagNotes.Text = tag.notes;

            //Test2 = new ObservableCollection<TestBinding>
            //{
            //    new TestBinding { TestBindingString = "0"},
            //    new TestBinding { TestBindingString = "1.1"},
            //    new TestBinding { TestBindingString = "1.2"},
            //    new TestBinding { TestBindingString = "1.3"},
            //    new TestBinding { TestBindingString = "1.4"},
            //    new TestBinding { TestBindingString = "1.5"},
            //    new TestBinding { TestBindingString = "1.6"},
            //    new TestBinding { TestBindingString = "1.7"},
            //    new TestBinding { TestBindingString = "1.8"}

            //};

            colors = new ObservableCollection<String>();
            colors.Add("red");
            colors.Add("blue");
            if (colors != null)
            {
                pickerColor.ItemsSource = colors;
            }
            //AccountList2.ItemsSource = Test2;


            ////Read Loal File dat using DependencyService  
            //string data = DependencyService.Get<IFileReadWrite>().ReadData("MyFileXML.txt");
            //TagNotes.Text = data;
            ////Print data
            //System.Diagnostics.Debug.WriteLine(data);
        }
    }
}
