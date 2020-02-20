using Pocket_Pantry.Models;
using System.Linq;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Collections.Generic;
using System;
using System.Windows.Input;
//using System.Collections;

namespace Pocket_Pantry
{

    public partial class Pantry_Page : ContentPage
    {

        //private IEnumerable<object> PantryList;

        public ObservableCollection<Pantry_PocketModel> PantryList { get; set; }
        //public IEnumerable<string> Name { get; set; }

        public Pantry_Page()
        {
            InitializeComponent();

            ObservableCollection<Pantry_PocketModel> PantryList = new ObservableCollection<Pantry_PocketModel>
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

        /*
         * TODO: Fix method below
         */

        //public ICommand SearchCommand => new Command(() =>
        //{
        //    string keyword = PantrySearchBar.Text;
        //    var result = PantryList.Where(Name => Name.Contains(keyword));
        //    //IEnumerable<String> searchresult = PantryList.Where(Name => name.Contains(keyword));

        //    PantryList = new ObservableCollection<Pantry_PocketModel>(result);

        //});

        private void PantrySearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            ((SearchBar)sender).SearchCommand?.Execute(e.NewTextValue);
        }

        //private void PantrySearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        //{
        //    string keyword = PantrySearchBar.Text;
        //    IEnumerable<object> result = PantryList.Where(x => x.Equals(keyword)); //add ToLower() case sensitive

        //    Pantry_List_View.ItemsSource = result;
        //}

    }
}