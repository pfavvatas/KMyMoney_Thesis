using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KMyMoney_Thesis.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KMyMoney_Thesis.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Institutions : ContentPage
    {
        public ObservableCollection<TestBinding> Test { get; set; }

        public Institutions()
        {
            InitializeComponent();

            Test = new ObservableCollection<TestBinding>
            {
                new TestBinding { TestBindingString = "Institution_1"},
                new TestBinding { TestBindingString = "Institution_2"},
                new TestBinding { TestBindingString = "Institution_3"},
                new TestBinding { TestBindingString = "Institution_4"},
                new TestBinding { TestBindingString = "Institution_5"},
                new TestBinding { TestBindingString = "Institution_6"},
                new TestBinding { TestBindingString = "Institution_7"},
                new TestBinding { TestBindingString = "Institution_8"},
                new TestBinding { TestBindingString = "Institution_9"},
                new TestBinding { TestBindingString = "Institution_10"},
                new TestBinding { TestBindingString = "Institution_11"}

            };

            InstitutionsList.ItemsSource = Test;
            

        }

        async void OnToolbarItemClickedAddNewInstitution(object sender, EventArgs args)
        {
            await DisplayAlert("Add", "Add new Institution", "OK");
            await Navigation.PushAsync(new InstitutionEdit());
        }

        async void OnButtonClickedEdit(object sender, EventArgs args)
        {
            ImageButton b = (ImageButton)sender;

            await DisplayAlert("Edit", "=>" + b.CommandParameter, "OK");
            await Navigation.PushAsync(new InstitutionEdit());
        }

        async void OnButtonClickedDelete(object sender, EventArgs args)
        {
            ImageButton b = (ImageButton)sender;

            await DisplayAlert("Delete", "=>" + b.CommandParameter, "OK");

        }

        async void OnSelectedItem(Object sender, ItemTappedEventArgs e)
        {            
            if (e.Item == null)
                return;

            TestBinding detail = e.Item as TestBinding;
            await DisplayAlert("Alert", "=>" + detail.TestBindingString, "OK");
            //await Navigation.PushAsync(new Ledgers());
        }


    }
}