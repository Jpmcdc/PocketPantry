using Pocket_Pantry.Models;
using System.Linq;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Collections.Generic;
using System;
using System.Windows.Input;
using System.Collections;

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

        /*
         * TODO: These are four ways to get the search bar going
         */

        //public void PantrySearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        //{
        //    //string keyword = PantrySearchBar.Text;
        //    //var result = PantryList.Where(x => x.Name.Contains(keyword));

        //    Pantry_List_View.BeginRefresh();

        //    if (string.IsNullOrWhiteSpace(e.NewTextValue))
        //        Pantry_List_View.ItemsSource = PantryList;
        //    else Pantry_List_View.ItemsSource = PantryList.Where(x => x.Name.Contains(e.NewTextValue));

        //    Pantry_List_View.EndRefresh();
        //}

        //void PantryList_OnRefreshing(System.Object sender, System.EventArgs e)
        //{
        //}


        /*
         * Second Searchbar Attempt
         */
        //public ICommand SearchCommand => new Command(() =>
        //{
        //    string keyword = PantrySearchBar.Text;
        //    var result = PantryList.Where(x => x.Name.Contains(keyword));
        //    //IEnumerable<String> searchresult = PantryList.Where(x => x.Contains(keyword));

        //    PantryList = new ObservableCollection<Pantry_PocketModel>(result);

        //});

        /*
         * Third Searchbar Attempt
         */

        //private void PantrySearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        //{
        //    ((SearchBar)sender).SearchCommand?.Execute(e.NewTextValue);
        //}

        /*
         * Fourth Searchbar Attempt
         */
        //private void PantrySearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        //{
        //    string keyword = PantrySearchBar.Text;
        //    var result = PantryList.Where(x => x.Name.Contains(keyword)); //add ToLower() case sensitive

        //    Pantry_List_View.ItemsSource = result;
        //}

    }
}