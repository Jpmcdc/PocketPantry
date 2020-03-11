using System;
using System.IO;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pocket_Pantry {

   
    public partial class View_Recipe : ContentPage {

        /**
         *  View_Recipe Constructor
         */
        public View_Recipe(String title, String type) {
            InitializeComponent();

            View_Title.Text = title;
        }

        /**
         *  Handles "Back" button
         *  Navigates to the previous page
         */
        async void View_Recipe_Back(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
