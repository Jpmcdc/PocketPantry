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

                }
            };



            BindingContext = this;
        }
    }
}

