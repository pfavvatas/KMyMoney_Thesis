﻿using KMyMoney_Thesis.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace KMyMoney_Thesis
{
    public class SplashPage : ContentPage
    {
        readonly Image splashImage;

        public SplashPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            var sub = new AbsoluteLayout();
            splashImage = new Image
            {
                Source = "xamarin_logo.png",
                WidthRequest = 100,
                HeightRequest = 100
            };

            AbsoluteLayout.SetLayoutFlags(splashImage,
                AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(splashImage,
                new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            sub.Children.Add(splashImage);

            //this.BackgroundColor = Color.FromHex("#ff403a");
            this.Content = sub;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await splashImage.ScaleTo(1, 2000);
            //await splashImage.ScaleTo(0.9, 1500, Easing.Linear);
            await splashImage.RotateTo(360, 1000); ;//.ScaleTo(150, 1200, Easing.Linear);
            //await splashImage.FadeTo(1, 2000);

            //Application.Current.MainPage = new NavigationPage(new MainPage());
            //Application.Current.MainPage = new MainPage();
            //Application.Current.MainPage = new SetupPage();
            Application.Current.MainPage = new NavigationPage(new SetupPage());



        }
    }
}
