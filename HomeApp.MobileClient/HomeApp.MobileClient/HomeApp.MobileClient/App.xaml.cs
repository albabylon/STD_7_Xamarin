﻿using HomeApp.MobileClient.Pages;
using Xamarin.Forms;

namespace HomeApp.MobileClient
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new RegisterPage(); //new LoginPage(); // new LoadingPage();  new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
