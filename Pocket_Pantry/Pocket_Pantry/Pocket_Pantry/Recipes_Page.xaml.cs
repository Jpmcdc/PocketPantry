using System;
using System.Collections.Generic;
using Pocket_Pantry.ViewModels;

using Xamarin.Forms;

namespace Pocket_Pantry {
    public partial class Recipes_Page : ContentPage {

        /**
         *  The purpose of this list is to store all the Recipes the user has saved
         *  This list will populate the Recipies_List_View in the xaml
         */
        public IList<Recipe> Recipes_List { get; private set; }


        public Recipes_Page()
        {
            InitializeComponent();
            BindingContext = new RecipeViewModel();
        }


        private async void ListView_ItemTapped(Object sender, ItemTappedEventArgs e)
        {
            var mydetails = e.Item as Recipe;
            await Navigation.PushModalAsync(new View_Recipe(mydetails.title, mydetails.type));
        }


        //private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e) {
        //    Recipe selectedItem = e.SelectedItem as Recipe;
        //}

        /**
         *  Handle the event of clicking on a recipie in the list
         *  This should open a Recipe Page with all the information form the specific recipe
         */
        //private void ListView_ItemTapped(object sender, ItemTappedEventArgs e) {
        //    Recipe tappedItem = e.Item as Recipe;
        //}


    }
}

