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
                new TestBinding { TestBindingString = "0"},
                new TestBinding { TestBindingString = "2"},
                new TestBinding { TestBindingString = "3"},
                new TestBinding { TestBindingString = "4"},
                new TestBinding { TestBindingString = "5"},
                new TestBinding { TestBindingString = "6"},
                new TestBinding { TestBindingString = "7"},
                new TestBinding { TestBindingString = "8"},
                new TestBinding { TestBindingString = "9"},
                new TestBinding { TestBindingString = "10"},
                new TestBinding { TestBindingString = "11"}

            };

            InstitutionsList.ItemsSource = Test;

        }
    }
}