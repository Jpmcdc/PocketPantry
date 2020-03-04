using Pocket_Pantry.Models;
using System.Linq;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System;

namespace Pocket_Pantry
{

    public partial class Pantry_Page : ContentPage
    {

        public ObservableCollection<Pantry_PocketModel> PantryList { get; set; }

        public Pantry_Page()
        {
            InitializeComponent();

            PantryList = new ObservableCollection<Pantry_PocketModel>
            {
                new Pantry_PocketModel
                {
                    Name = "Carrot",
                    Image = "veggie.png",
                    Category = "Veggie",
                },

                new Pantry_PocketModel
                {
                    Name = "Zuchinni",
                    Image = "veggie.png",
                    Category = "Veggie",
                },

                new Pantry_PocketModel
                {
                    Name = "Tomato",
                    Image = "veggie.png",
                    Category = "Veggie",
                }
            };

            Pantry_List_View.ItemsSource = PantryList;
        }

        private void PantryList_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            try
            {
                var PantryList = Pantry_List_View.SelectedItem as string;

                DisplayAlert("Item Tapped", "This ingredient was tapped: " + PantryList, "OK");
            }
            catch (Exception)
            {

            }
        }

        private void PantrySearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var keyword = PantrySearchBar.Text;
            var result = PantryList.Where(x => x.Name.Contains(keyword));

            Pantry_List_View.ItemsSource = result;
        }
    }
}