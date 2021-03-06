﻿using System;
using System.IO;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;

namespace Pocket_Pantry
{


    public partial class View_Recipe : ContentPage
    {
       // Set mydetials with Recipe Type
        Recipe mydetails;

        /**
         *  View_Recipe Constructor
         */
        public View_Recipe(Recipe mydetails)
        {
            InitializeComponent();

            //Use mydetails from selected Items
            this.mydetails = mydetails;

            //Set details from mydetails to View_Recipe
            View_Title.Text = mydetails.title;
            View_Ingredients.Text = mydetails.ingredients;
            View_Directions.Text = mydetails.directions;
        }

        /**
         *  Handles "Back" button
         *  Navigates to the previous page
         */
        async void View_Recipe_Back(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }


        //Update information to Datbase
        void updateButton_Clicked(object sender, EventArgs e)
        {
            mydetails.title = View_Title.Text;
            mydetails.ingredients = View_Ingredients.Text;
            mydetails.directions = View_Directions.Text;
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))

            {
                conn.CreateTable<Recipe>();
                int rows = conn.Update(mydetails);

                if (rows > 0)
                {
                    DisplayAlert("Success", "You succesfully updated the Recipe", "Ok");
                    Navigation.PopModalAsync();
                }
                else
                    DisplayAlert("Failure", "Update failed", "Ok");
            }
        }

        //Delete the information in Database "mydetails"
        private void deleteButton_Clicked(object sender, EventArgs e)
        {
            {
                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    conn.CreateTable<Recipe>();
                    int rows = conn.Delete(mydetails);

                    if (rows > 0)
                    {
                        DisplayAlert("Success", "Experience succesfully updated", "Ok");
                        Navigation.PopModalAsync();
                    }
                    else
                        DisplayAlert("Failure", "Experience failed to be deleted", "Ok");
                }
            }
        }
    }
}
