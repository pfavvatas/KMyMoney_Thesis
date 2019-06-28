﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace KMyMoney_Thesis.Droid
{
    [Activity(Theme = "@style/Theme.Splash",
        MainLauncher = false,
        NoHistory = true)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //StartActivity(typeof(MainActivity));
            
        }

        protected override void OnResume()
        {
            base.OnResume();
            StartActivity(typeof(MainActivity));
            //Task startupwork = new Task(() => { SimulateStartup(); });
        }

        private void SimulateStartup()
        {
            throw new NotImplementedException();
        }
    }
}