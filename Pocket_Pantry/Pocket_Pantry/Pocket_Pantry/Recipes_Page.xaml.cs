using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Pocket_Pantry
{
    public partial class Recipes_Page : ContentPage
    { 
        public IList<Recipe> Recipes { get; private set; }
    
    
        public Recipes_Page() 

        {
            InitializeComponent();

            Recipes = new List<Recipe>
            {
                new Recipe
                {
                    Title = "Greek Salad",
                    Type = "Salads"

                },

                new Recipe
                {
                    Title = "Onion Soup",
                    Type = "Soups"

                },

                 new Recipe
                {
                    Title = "Chicken Enchiladas",
                    Type = "Mexican"

                },
                  new Recipe
                {
                    Title = "Lemon Meringue",
                    Type = "Cheesecake"

                },
                   new Recipe
                {
                    Title = "Grille Peanut Butter and Banana Sandwich",
                    Type = "Sandwich"

                }


            };



            BindingContext = this;


        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Recipe selectedItem = e.SelectedItem as Recipe;
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Recipe tappedItem = e.Item as Recipe;
        }
    }
}

