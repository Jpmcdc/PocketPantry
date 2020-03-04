﻿using System;
using Pocket_Pantry;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Pocket_Pantry
{
    public partial class App : Application
    {
        public App(string fullPath)
        {
            InitializeComponent();

            MainPage = new MainPage();
            //MainPage = new NavigationPage(new Pantry_Page());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}