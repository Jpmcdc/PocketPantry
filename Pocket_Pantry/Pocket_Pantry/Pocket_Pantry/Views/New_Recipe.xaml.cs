using System;
using System.Collections.Generic;
using Pocket_Pantry.ViewModels;
using Pocket_Pantry.Models;

using Xamarin.Forms;
using SQLite;

namespace Pocket_Pantry
{
    public partial class New_Recipe : ContentPage
    {

        public IList<Recipe> Recipes_List { get; private set; }

        public New_Recipe()
        {
            InitializeComponent();
            BindingContext = new RecipeViewModel();
        }



        async void cancel_btn(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        async void Save_Clicked(System.Object sender, System.EventArgs e)
        {

            Recipe newRecipe = new Recipe();
            {
                newRecipe.title = Entry_Title.Text;
                newRecipe.ingredients = Entry_Ingredients.Text;
                newRecipe.directions = Entry_Directions.Text;
               // newRecipe.type = Entry_Type.Text;
            };

            SQLiteConnection conn = new SQLiteConnection(Recipes_Page.DatabaseLocation);
            conn.CreateTable<Recipe>();
            int rows = conn.Insert(newRecipe);
            conn.Close();

            if (rows > 0)
                _ = DisplayAlert("Success: ", "Recipe succesfully inserter", "OK");
            else
                _ = DisplayAlert("Failure: ", "Recipe failed to be inserter", "OK");

            //Recipe newRecipe = new Recipe();

            // newRecipe.title = Entry_Title.Text;
            //newRecipe.ingredients = Entry_Ingredients.Text;
            // newRecipe.directions = Entry_Directions.Text;

            //Recipes_List.Add(newRecipe);

            //await Navigation.PopModalAsync();
        }
    }
}
