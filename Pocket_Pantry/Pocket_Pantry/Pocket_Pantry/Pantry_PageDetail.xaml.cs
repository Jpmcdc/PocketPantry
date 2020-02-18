using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Pocket_Pantry
{
    public partial class Pantry_PageDetail : ContentPage
    {
        public Pantry_PageDetail(string Name, string Ingredients, string source)
        {
            InitializeComponent();

            MyItemNameShow.Text = Name;
            MyIngredientItemShow.Text = Ingredients;
            MyImageCall.Source = new UriImageSource()
            {
                Uri = new Uri(source)
            };
        }
    }
}
