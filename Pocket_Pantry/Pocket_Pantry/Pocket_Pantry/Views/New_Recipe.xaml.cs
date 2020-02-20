using System;
using System.Collections.Generic;
using Pocket_Pantry.ViewModels;

using Xamarin.Forms;

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

            newRecipe.title = Entry_Title.Text;
            newRecipe.ingredients = Entry_Ingredients.Text;
            newRecipe.directions = Entry_Directions.Text;

            Recipes_List.Add(newRecipe);

            await Navigation.PopModalAsync();
        }
    }
}
