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
            Recipe newRecipe = new Recipe();
            {
                //newRecipe.title = Entry_Title.Text;
                //newRecipe.ingredients = Entry_Ingredients.Text;
                //newRecipe.directions = Entry_Directions.Text;
            };

            //connection to the datbase & saving information
            SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);
            conn.CreateTable<Recipe>();
            int rows = conn.Insert(newRecipe);
            conn.Close();

            if (rows > 0)
            {
                //_ = DisplayAlert("Success: ", "Recipe succesfully inserter", "OK");
                await Navigation.PopModalAsync();
            }
            else
                //_ = DisplayAlert("Failure: ", "Recipe failed to be inserter", "OK");
                await Navigation.PopModalAsync();
        }

    }
}
