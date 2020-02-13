using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Pocket_Pantry {
    public partial class Recipes_Page : ContentPage {

        /**
         *  The purpose of this list is to store all the Recipes the user has saved
         *  This list will populate the Recipies_List_View in the xaml
         */
        public IList<Recipe> Recipes_List { get; private set; }
    
    
        public Recipes_Page() {
            InitializeComponent();

            /**
             *  Extanziate Recipies_List and populate
             *  TODO: Figue out if this is where all the information will be stored
             */
            Recipes_List = new List<Recipe> {

                new Recipe {
                    title = "Greek Salad",
                    type = "Salads"

                },

                new Recipe {
                    title = "Onion Soup",
                    type = "Soups"

                },

                 new Recipe {
                    title = "Chicken Enchiladas",
                    type = "Mexican"

                },

                  new Recipe {
                    title = "Lemon Meringue",
                    type = "Cheesecake"

                },

                   new Recipe {
                    title = "Grilled Peanut Butter and Banana Sandwich",
                    type = "Sandwich"

                }
            };

            BindingContext = this;
        }

        
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e) {
            Recipe selectedItem = e.SelectedItem as Recipe;
        }

        /**
         *  Handle the event of clicking on a recipie in the list
         *  This should open a Recipe Page with all the information form the specific recipe
         */
        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e) {
            Recipe tappedItem = e.Item as Recipe;
        }

      
    }
}

