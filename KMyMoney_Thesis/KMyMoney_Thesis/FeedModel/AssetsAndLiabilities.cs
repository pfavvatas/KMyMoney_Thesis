using System;
using System.Collections.Generic;
using Microcharts;
using SkiaSharp;
using Xamarin.Forms;

namespace KMyMoney_Thesis.FeedModel
{
    public partial class AssetsAndLiabilities : ContentView
    {
        List<ChartEntry> entries = new List<ChartEntry>
        {
            new ChartEntry(100)
            {
                Color = SKColor.Parse("#000000"),
                Label = "Label1",
                ValueLabel = "100"
            },
            new ChartEntry(200)
            {
                Color = SKColor.Parse("#111111"),
                Label = "Label2",
                ValueLabel = "200"
            },
            new ChartEntry(300)
            {
                Color = SKColor.Parse("#333333"),
                Label = "Label3",
                ValueLabel = "300"
            },
            new ChartEntry(400)
            {
                Color = SKColor.Parse("#555555"),
                Label = "Label4",
                ValueLabel = "400"
            },
            new ChartEntry(500)
            {
                Color = SKColor.Parse("#888888"),
                Label = "Label5",
                ValueLabel = "500"
            }
        };


        public AssetsAndLiabilities()
        {
            InitializeComponent();


            var chart = new DonutChart()
            {
                //LabelMode = LabelMode.LeftAndRight,
                LabelTextSize = 50f, // here
                Entries = entries
            };

            this.chartView.Chart = chart;
            this.chartView.HeightRequest = Application.Current.MainPage.Height * 0.4;
            this.chartView.WidthRequest = Application.Current.MainPage.Width * 0.9;
        }

        async void ButtonClicked(object sender, EventArgs args)
        {
            //Do something.
        }
    }
}
