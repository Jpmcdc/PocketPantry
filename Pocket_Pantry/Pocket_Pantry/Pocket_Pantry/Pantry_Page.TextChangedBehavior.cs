using Xamarin.Forms;
//using System.Collections;

namespace Pocket_Pantry
{

    public partial class Pantry_Page
    {
        public class TextChangedBehavior : Behavior<SearchBar>
        {
            protected override void OnAttachedTo(SearchBar bindable)
            {
                base.OnAttachedTo(bindable);
                bindable.TextChanged += Bindable_TextChanged;
            }

            protected override void OnDetachingFrom(SearchBar bindable)
            {
                base.OnDetachingFrom(bindable);
                bindable.TextChanged -= Bindable_TextChanged;
            }

            private void Bindable_TextChanged(object sender, TextChangedEventArgs e)
            {
                ((SearchBar)sender).SearchCommand?.Execute(e.NewTextValue);
            }
        }

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