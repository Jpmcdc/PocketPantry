using System;
using System.Collections.Generic;

using Xamarin.Forms;
using SQLite;
using Xamarin.Forms.Xaml;
using Plugin.Media.Abstractions;
using Plugin.Media;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;
using System.Linq;
using Pocket_Pantry.Models;

namespace Pocket_Pantry.Views
{
    public partial class New_Ingredient : ContentPage
    {
        public New_Ingredient()
        {
            InitializeComponent();
        }



        async void cancel_btn(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        async void Save_Clicked(System.Object sender, System.EventArgs e)
        {
            // add the new recipe using Recipe
            Pantry_PocketModel newIngredient = new Pantry_PocketModel();
            {
                newIngredient.ingredient_name = Entry_Ingredients.Text;
                newIngredient.Category = Entry_Category.Text;
            };

            //connection to the datbase & saving information
            SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);
            conn.CreateTable<Pantry_PocketModel>();
            int rows = conn.Insert(newIngredient);
            conn.Close();

            if (rows > 0)
            {
                //_ = DisplayAlert("Success: ", "Ingredient succesfully inserter", "OK");
                await Navigation.PopModalAsync();
            }
            else
                //_ = DisplayAlert("Failure: ", "Ingredient failed to be inserter", "OK");
                await Navigation.PopModalAsync();
        }

    }
}
