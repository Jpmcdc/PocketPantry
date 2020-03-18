using Pocket_Pantry.Models;
using System.Linq;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System;
using Pocket_Pantry.Views;
using SQLite;
using Xamarin.Forms.Xaml;
using Pocket_Pantry.ViewModels;

namespace Pocket_Pantry
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pantry_Page : ContentPage
    {

        /*
         *  Pantry_Page Constructor
         */
        public Pantry_Page()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Pantry_PocketModel>();
                var ingredients = conn.Table<Pantry_PocketModel>().ToList();
                Pantry_List_View.ItemsSource = ingredients;
            }
        }

        /**
        *  Handles when item in the list is selected
        *   Opens an alert that displays the information
        *
        *   TODO: Figure out what really do when item selected on Pantry
        */
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

        /**
         *  SearchBar Code
         *  FIXME
         */
        private void PantrySearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var keyword = PantrySearchBar.Text;
            //var result = PantryList.Where(x => x.Name.Contains(keyword));

            //Pantry_List_View.ItemsSource = result;
        }

        /*
        *   Handles "add Ingredient" button click
        *   Opens a new navigation page with entry points for new ingredient
        */
        private async void AddIngredient_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new New_Ingredient());
        }
    }
}