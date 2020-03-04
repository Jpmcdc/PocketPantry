﻿using System;
using System.IO;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Pocket_Pantry {
    public partial class View_Recipe : ContentPage {

        public View_Recipe(String title, String type) {
            InitializeComponent();

            View_Title.Text = title;
        }

        async void View_Recipe_Back(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}