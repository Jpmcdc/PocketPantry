using System;
using System.Collections.ObjectModel;
using System.Linq;
using Pocket_Pantry.ViewModels;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pocket_Pantry
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Recipes_Page : ContentPage {

        /**
         *  The purpose of this list is to store all the Recipes the user has saved
         *  This list will populate the Recipies_List_View in the xaml
         */
        public ObservableCollection<Recipe> Recipes_List { get; private set; }



        /*
        *   Recipes_Page Constructor
        */
        public Recipes_Page()
        {
            InitializeComponent();

            BindingContext = new RecipeViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Recipe>();
                var recipes = conn.Table<Recipe>().ToList(); 
                Recipes_List_View.ItemsSource = recipes;


            }
        }


        /*
        *   Handles when item in the list is selected
        *   Opens a new navigation page with the recipe information
        */
        private async void ListView_ItemTapped(Object sender, ItemTappedEventArgs e)
        {
            var mydetails = Recipes_List_View.SelectedItem as Recipe;
            if (mydetails != null) 
            {
                Navigation.PushModalAsync(new View_Recipe(mydetails));
            }


            //  var mydetails = e.Item as Recipe;
            //  await Navigation.PushModalAsync(new View_Recipe(mydetails.title, mydetails.type));
        }

        /*
        *   Handles "add recipe" button click
        *   Opens a new navigation page with entry points for new recipe
        */
        private async void AddRecipe_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new New_Recipe());
        }


        /**
         *  SearchBar Code
         */
        private void RecipeSearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var keyword = RecipeSearchBar.Text;
            var result = Recipes_List.Where(x => x.title.Contains(keyword));

            Recipes_List_View.ItemsSource = result;
           
        }

    }
}

