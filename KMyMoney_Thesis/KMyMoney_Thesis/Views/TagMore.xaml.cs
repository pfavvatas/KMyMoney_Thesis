﻿using System;
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
        public ObservableCollection<TestBinding> Test2 { get; set; }
        public ObservableCollection<String> colors { get; set; }

        public Tag _tag { get; set; }
        //public ObservableCollection<String> colors;
        public TagMore(Tag tag)
        {
            InitializeComponent();


            Console.WriteLine("~/TagMore => "+tag.name+","+tag.id);
            _tag = tag;
            TagName.Text = tag.name;
            TagId.Text = tag.id;
            TagNotes.Text = tag.notes;

            Test2 = new ObservableCollection<TestBinding>
            {
                new TestBinding { TestBindingString = "0"},
                new TestBinding { TestBindingString = "1.1"},
                new TestBinding { TestBindingString = "1.2"},
                new TestBinding { TestBindingString = "1.3"},
                new TestBinding { TestBindingString = "1.4"},
                new TestBinding { TestBindingString = "1.5"},
                new TestBinding { TestBindingString = "1.6"},
                new TestBinding { TestBindingString = "1.7"},
                new TestBinding { TestBindingString = "1.8"}

            };

            colors = new ObservableCollection<String>();
            colors.Add("red");
            colors.Add("blue");
            if (colors != null)
            {
                pickerColor.ItemsSource = colors;
            }
            AccountList2.ItemsSource = Test2;
        }
    }
}
