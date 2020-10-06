using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
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

            setBalance(TransactionsWithTag);
            
            TransactionsList.ItemsSource = TransactionsWithTag;

            _tag = tag;
            TagName.Text = tag.Name;
            TagNotes.Text = tag.Notes;
            if(tag.Closed == "1")
            {
                TagCheckBox1.IsChecked = true;
            }
            else
            {
                TagCheckBox1.IsChecked = false;
            }


            colors = new ObservableCollection<String>();
            colors.Add("red");
            colors.Add("blue");
            if (colors != null)
            {
                pickerColor.ItemsSource = colors;
            }


            
        }


        async void ClickedDelete2(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Delete " + _tag.Name + " ?", null, "Yes", "No");
            if (answer)
            {
                new retrieveDataFromXML().DeleteTag(_tag.Id);
                await Navigation.PopAsync();
            }
        }

        async void ClickedEdit(object sender, EventArgs e)
        {
            _tag.Name = TagName.Text;
            _tag.Notes = TagNotes.Text;
            _tag.Closed = TagCheckBox1.IsChecked ? "1" : "0";
            new retrieveDataFromXML().UpdateTag(_tag);
            await Navigation.PopAsync();
        }

        async void OnItemTapped(Object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            Transaction item = e.Item as Transaction;
            System.Console.WriteLine(item);
            System.Console.WriteLine(item.Id);

        }

        private void setBalance(ObservableCollection<Transaction> TransactionsWithTag)
        {
            double balanceD = 0.0;
            foreach (var c in TransactionsWithTag)
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
    }
}
