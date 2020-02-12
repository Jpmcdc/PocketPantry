using System;
//using System.Collections.ObjectModel;
//using System.ComponentModel;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Collections.Generic;

using Xamarin.Forms;
//using Xamarin.Forms.Xaml;

namespace Pocket_Pantry
{
    public partial class Pantry_Page : ContentPage
    {
        public IList<Ingredient> PantryList { get; private set; }

        public Pantry_Page()
        {
            InitializeComponent();

            PantryList = new List<Ingredient>
            {
                new Ingredient
                {
                    name = "Banana",
                    quantity_type = "Fruit" //fix this
                },

                new Ingredient
                {
                    name = "Cucumber",
                    quantity_type = "Vegetable"
                }
            };

            BindingContext = this;
        }

        //Search bar
        private void PantrySearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var keyword = PantrySearchBar.Text;
            var result = "nothing";

            for (int i = 0; i < PantryList.Count; i++)
            {
                //TODO: add adapter
                //result = PantryList.Contains(keyword).Where(x => x.Contains(keyword));
            }
            Pantry_List_View.ItemsSource = result;
        }
    }
}
