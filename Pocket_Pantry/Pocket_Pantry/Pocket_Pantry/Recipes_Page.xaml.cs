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
                    title = "Greek Salad",
                    type = "Salads"

                },

                new Recipe
                {
                    title = "Onion Soup",
                    type = "Soups"

                },

                 new Recipe
                {
                    title = "Chicken Enchiladas",
                    type = "Mexican"

                },
                  new Recipe
                {
                    title = "Lemon Meringue",
                    type = "Cheesecake"

                },
                   new Recipe
                {
                    title = "Grilled Peanut Butter and Banana Sandwich",
                    type = "Sandwich"

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

