using System;

using Xamarin.Forms;

namespace Pocket_Pantry
{
    public class Recipes_Page : ContentPage
    {
        public Recipes_Page()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

