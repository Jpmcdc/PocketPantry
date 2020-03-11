using System;
using System.Collections.Generic;
using Pocket_Pantry.ViewModels;
using Pocket_Pantry.Models;

using Xamarin.Forms;
using SQLite;
using Xamarin.Forms.Xaml;

namespace Pocket_Pantry
     
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class New_Recipe : ContentPage
    {

        /**
         *  This list will hold all the recipes
         */
        //public IList<Recipe> Recipes_List { get; private set; }

        /**
         *  New_Recipe Constructor
         */
        public New_Recipe()
        {
            InitializeComponent();
            //BindingContext = new RecipeViewModel();
        }

        /**
         *  Handles "Back" button
         *  Navigates to the previous page
         */
        async void cancel_btn(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        async void Save_Clicked(System.Object sender, System.EventArgs e)
        {
            // add the new recipe using Recipe
            Recipe newRecipe = new Recipe();
            {
                newRecipe.title = Entry_Title.Text;
                newRecipe.ingredients = Entry_Ingredients.Text;
                newRecipe.directions = Entry_Directions.Text;
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
