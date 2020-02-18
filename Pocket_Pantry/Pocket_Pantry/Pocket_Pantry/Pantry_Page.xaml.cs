using Pocket_Pantry.Models;
using System.Linq;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Collections;

namespace Pocket_Pantry
{

    public partial class Pantry_Page : ContentPage {

        public ObservableCollection<Pantry_PocketModel> PantryList { get; set; }
        public IEnumerable Ingredients { get; }

        public Pantry_Page()
        {
            InitializeComponent();

            PantryList = new ObservableCollection<Pantry_PocketModel>();

            PantryList.Add(new Pantry_PocketModel
            {
                Name = "Carrot",
                Image = "veggie.png",
                Category = "Veggie",
            });

            PantryList.Add(new Pantry_PocketModel
            {
                Name = "Zuchinni",
                Image = "veggie.png",
                Category = "Veggie",
            });

            PantryList.Add(new Pantry_PocketModel
            {
                Name = "Tomato",
                Image = "veggie.png",
                Category = "Veggie",
            });


            Pantry_List_View.ItemsSource = PantryList;
        }

        private void PantrySearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var keyword = PantrySearchBar.Text;
            var result = PantryList.Where(x => x.ToLower().Equals(keyword.ToLower()));

            Pantry_List_View.ItemsSource = result;
        }

        //On Tap = Another details page
        //private async void PantryList_OnItemTapped(Object sender, ItemTappedEventArgs e)
        //{
        //    var myDetails = e.Item as Pantry_PocketModel;
        //    await Navigation.PushAsync(new Pantry_PageDetail(myDetails.Name, myDetails.Ingredients, myDetails.Image));
        //}
    }
}




///**
//    *  The purpose of this list is to store all the Ingredients the user hasa dn doesn't in his pantry
//    *  This list will populate the Pantry_List_View in the xaml
//    */
//public IList<Ingredient> Pantry_List { get; private set; }

//public Pantry_Page()
//{
//    InitializeComponent();

//    Pantry_List = new List<Ingredient> {

//                new Ingredient {
//                    name = "Banana",
//                    quantity_type = "General Unit"
//                },

//                new Ingredient {
//                    name = "Flour",
//                    quantity_type = "Oz"
//                }
//            };

//    BindingContext = this;
//}

///**
// *  Search Bar
// *  Filter the names of Ingredients in Pantry_List to match user input in the search bar
// *  TODO: Make this work
// */
//private void PantrySearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
//{
//    var keyword = PantrySearchBar.Text;
//    var result = "nothing";

//    for (int i = 0; i < Pantry_List.Count; i++)
//    {
//        //TODO: add adapter
//        //result = PantryList.Contains(keyword).Where(x => x.Contains(keyword));
//    }
//    Pantry_List_View.ItemsSource = result;
//}

//void Pantry_List_View_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
//{
//}