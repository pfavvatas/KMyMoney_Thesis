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

            //TestPayee = new ObservableCollection<String>();
            //TestPayee.Add("ena");
            //TestPayee.Add("duo");


            //lstMonkeys.ItemsSource = TestPayee;



            SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);
            var TagsLIST = conn.Table<Tag>().ToList();
            conn.Close();

            TagsObs = new ObservableCollection<Tag>();
            foreach (var _tag in TagsLIST)
            {
                TagsObs.Add(new Tag {
                    name = _tag.name,
                    id = _tag.id,
                    notes = _tag.notes
                });
            }
            TagList.ItemsSource = TagsObs;
        }

        private void New_Clicked(object sender, EventArgs e)
        {
            //TestPayee.Add("new_" + TestPayee.Count);
        }

        async void OnItemSelected(Object sender, ItemTappedEventArgs e)
        {
            ////LayoutUpdate.IsVisible = false;
            if (e.Item == null)
                return;

            //var details = e.Item as String;
            //String detail = e.Item as String;
            
            Console.WriteLine("==========>sender: " + e.ItemIndex);
            await Navigation.PushAsync(new TagMore(e.Item as Tag));


            //I chose that code because on iOS "delete" has red colour.
            //On the other hand, android does not have colour, so it's looks better with that code.
            //string action;
            //switch (Device.RuntimePlatform)
            //{
            //    case Device.iOS:
            //        Console.WriteLine("==========>Device: iOS");
            //        action = await DisplayActionSheet("" + e.Item, "Cancel", "Delete", "Rename", "More");
            //        Console.WriteLine("==========>Action: " + action);
            //        _Action(action, e);
            //        break;
            //    case Device.Android:
            //        Console.WriteLine("==========>Device: Android");
            //        action = await DisplayActionSheet("" + e.Item, "Cancel", null, "Rename", "More", "Delete");
            //        Console.WriteLine("==========>Action: " + action);
            //        _Action(action, e);
            //        break;
            //    case Device.UWP:
            //    default:
            //        action = await DisplayActionSheet("", "Cancel", null, "More", "Delete");
            //        _Action(action, e);
            //        break;
            //}

        }

        //private async void _Action(string action, ItemTappedEventArgs e)
        //{
        //    if (action.Equals("Delete"))
        //    {
        //        TestPayee.RemoveAt(e.ItemIndex);
        //    }
        //    else if (action.Equals("Rename"))
        //    {
        //        LayoutUpdate.IsVisible = true;
        //        UpdateNameEntry.Text = e.Item as String;
        //        _id = e.ItemIndex;
        //    }
        //    else if (action.Equals("More"))
        //    {
        //        await Navigation.PushAsync(new TagMore());
        //    }
        //}

        //async void UpdateNameButton(object sender, EventArgs e)
        //{
        //    //TestPayee.Insert(_id, UpdateNameEntry.Text);
        //    TestPayee[_id] = UpdateNameEntry.Text;
        //    LayoutUpdate.IsVisible = false;
        //}

        //async void OnButtonTappedListView(object sender, EventArgs e)
        //{
        //    //LayoutUpdate.IsVisible = false;
        //}
    }
}
