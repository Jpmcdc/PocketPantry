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
    }
}
