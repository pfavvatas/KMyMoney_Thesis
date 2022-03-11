using System;
using System.Collections.Generic;
using Microcharts;
using SkiaSharp;
using Xamarin.Forms;

namespace KMyMoney_Thesis.FeedModel
{
    public partial class AssetsAndLiabilities : ContentView
    {
        public class DonutChardLabel
        {
            public string label { get; set; }
            public string color { get; set; }
            public string value { get; set; }
        }
        List<DonutChardLabel> donutChardLabels = new List<DonutChardLabel>();

        List<ChartEntry> entries = new List<ChartEntry>();
        //{
        //    new ChartEntry(100)
        //    {
        //        Color = SKColor.Parse("#000000"),
        //        Label = "Label1",
        //        ValueLabel = "100"
        //    },
        //    new ChartEntry(200)
        //    {
        //        Color = SKColor.Parse("#111111"),
        //        Label = "Label2",
        //        ValueLabel = "200"
        //    },
        //    new ChartEntry(300)
        //    {
        //        Color = SKColor.Parse("#333333"),
        //        Label = "Label3",
        //        ValueLabel = "300"
        //    },
        //    new ChartEntry(400)
        //    {
        //        Color = SKColor.Parse("#555555"),
        //        Label = "Label4",
        //        ValueLabel = "400"
        //    },
        //    new ChartEntry(500)
        //    {
        //        Color = SKColor.Parse("#888888"),
        //        Label = "Label5",
        //        ValueLabel = "500"
        //    }
        //};


        public AssetsAndLiabilities()
        {
            InitializeComponent();

            getDataForChart();

            addDataToFrames();

            addDateToEntries();

            var chart = new DonutChart()
            {
                LabelMode = LabelMode.None,
                LabelTextSize = 50f, // here
                Entries = entries
            };

            this.chartView.Chart = chart;
            this.chartView.HeightRequest = Application.Current.MainPage.Height * 0.4;
            this.chartView.WidthRequest = Application.Current.MainPage.Width * 0.9;
            

            //Frame frame1 = new Frame
            //{
            //    HasShadow = false,                
            //    Padding = new Thickness(5),
            //    Content = new StackLayout
            //    {
            //        Orientation = StackOrientation.Horizontal,
            //        Spacing = 15,
            //        Children =
            //            {
            //                new BoxView { Color = Color.Yellow },
            //                new Label { Text = "Yellow",
            //                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
            //                    VerticalOptions = LayoutOptions.Center }
            //            }
            //    }
            //};

            //StackLayoutData1.Children.Add(frame1);


        }

        private void getDataForChart()
        {
            var random = new Random();
            var color = String.Format("#{0:X6}", random.Next(0x1000000));

            //1) get data from xml
            //Code here...

            //2) Insert to List of DonutChardLabels            
            DonutChardLabel donutChardLabel1 = new DonutChardLabel();
            donutChardLabel1.label = "Label 1";
            donutChardLabel1.color = String.Format("#{0:X6}", random.Next(0x1000000));
            donutChardLabel1.value = "80";
            donutChardLabels.Add(donutChardLabel1);
            DonutChardLabel donutChardLabel2 = new DonutChardLabel();
            donutChardLabel2.label = "Label 2";
            donutChardLabel2.color = String.Format("#{0:X6}", random.Next(0x1000000));
            donutChardLabel2.value = "20";
            donutChardLabels.Add(donutChardLabel2);

        }

        private void addDataToFrames()
        {
            foreach (var donutChardLabel in donutChardLabels)
            {
                Frame frame1 = new Frame
                {
                    HasShadow = false,
                    Padding = new Thickness(5),
                    Content = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        Spacing = 15,
                        Children =
                        {
                            new BoxView { Color = Color.FromHex(donutChardLabel.color), HeightRequest = 3 },
                            new Label { Text = donutChardLabel.label,
                                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                                VerticalOptions = LayoutOptions.Center }
                        }
                    }
                };
                StackLayoutData1.Children.Add(frame1);
            }
        }

        private void addDateToEntries()
        {
            foreach (var donutChardLabel in donutChardLabels)
            {
                int tmpInt = 0;
                try
                {
                    tmpInt = Int32.Parse(donutChardLabel.value);
                }
                catch (Exception intError)
                {
                    tmpInt = 0;
                }
                Console.WriteLine(donutChardLabel.value);
                Console.WriteLine(tmpInt);
                Console.WriteLine(donutChardLabel.color);
                entries.Add(new ChartEntry(tmpInt)
                {
                    Color = SKColor.Parse(donutChardLabel.color),
                    Label = donutChardLabel.label,
                    ValueLabel = donutChardLabel.value
                });
            }
        }

        async void ButtonClicked(object sender, EventArgs args)
        {
            //Do something.
        }
    }
}
