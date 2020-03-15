﻿using Pocket_Pantry.Models;
using System.Linq;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System;
using Pocket_Pantry.Views;
using SQLite;

namespace Pocket_Pantry
{

    public partial class Pantry_Page : ContentPage
    {

        /**
         *  The purpose of this list is to store all the Ingredients
         *  This list will populate the Pantry_List_View in the xaml
         */
        public ObservableCollection<Pantry_PocketModel> PantryList { get; private set; }

        /**
         *  Pantry_Page Constructor
         */
        public Pantry_Page()
        {
            InitializeComponent();
         
            /**
            *  TODO: This Observable Collection is being "hard" populated but we need to pull the information from the database
            */
            PantryList = new ObservableCollection<Pantry_PocketModel>
            {
 

                new Pantry_PocketModel
                {
                    Name = "Tomato",
                    Image = "veggie.png",
                    Category = "Veggie",
                }
            };

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Pantry_PocketModel>();
                var ingredient = conn.Table<Pantry_PocketModel>().ToList();
                Pantry_List_View.ItemsSource = ingredient;


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
         /*
        private async void PantryList_OnItemTapped(Object sender, ItemTappedEventArgs e)
        {
            var mydetails = Pantry_List_View.SelectedItem as Recipe;
            if (mydetails != null)
            {
                await Navigation.PushModalAsync(new View_Recipe(mydetails));
            }
        }
        */

        /**
         *  SearchBar Code
         */
        private void PantrySearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var keyword = PantrySearchBar.Text;
            var result = PantryList.Where(x => x.Name.Contains(keyword));

            Pantry_List_View.ItemsSource = result;
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