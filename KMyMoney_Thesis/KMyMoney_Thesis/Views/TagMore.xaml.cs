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
        public ObservableCollection<String> colors { get; set; }

        public Tag _tag { get; set; }
        public TagMore(Tags.TagDetailsData tdd)
        {
            InitializeComponent();
            Title = tdd.Tag.Name;
            Tag tag = tdd.Tag;
            ObservableCollection<Transaction> TransactionsWithTag = new ObservableCollection<Transaction>(tdd.TagTransactionsList);

            double balanceD = 0.0;
            foreach(var c in TransactionsWithTag)
            {
                
                    string[] spl = c.Splits[0].Value.Split(new[] { "/" }, StringSplitOptions.None);
                    balanceD += double.Parse(spl[0]);
                
            }
            if(balanceD > 0)
            {
                Balance.Text = "+ " + balanceD + "$";
                Balance.TextColor = Color.Green;
            }
            else
            {
                Balance.Text = "- " + balanceD + "$";
                Balance.TextColor = Color.Red;
            }
            
            TransactionsList.ItemsSource = TransactionsWithTag;

            _tag = tag;
            TagName.Text = tag.Name;
            //TagId.Text = tag.Id;
            TagNotes.Text = tag.Notes;



            colors = new ObservableCollection<String>();
            colors.Add("red");
            colors.Add("blue");
            if (colors != null)
            {
                pickerColor.ItemsSource = colors;
            }
        }

    }
}
