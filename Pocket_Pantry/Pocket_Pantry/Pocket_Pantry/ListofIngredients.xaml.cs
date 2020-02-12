using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pocket_Pantry
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewPage1 : ContentPage
    {
        
    public ObservableCollection<string> Items { get; set; }

    public ListViewPage1()
        {
            InitializeComponent();

            // TODO: Change this collection type to <Ingredient>
            Items = new ObservableCollection<string>
            {
                "Flour",
                "Tomatoes",
                "Sugar",
                "Brown Sugar",
                "Butter"
            };
			
			MyListView.ItemsSource = Items;
        }

        //Tap item = Pop up appears showing which item was tapped
        private void MyListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            try
            {
                var Items = MyListView.SelectedItem as string;

                DisplayAlert("Item Tapped", "This item was tapped: " + Items, "OK");
            }
            catch(Exception ex)
            {
                Console.Write(ex);
            }
         }

        /*async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }*/

        //Search bar
        private void PantrySearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var keyword = PantrySearchBar.Text;
            var result = Items.Where(x=>x.ToLower().Contains(keyword.ToLower()));

            MyListView.ItemsSource = result;
        }
    }
}
