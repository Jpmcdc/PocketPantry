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

            Items = new ObservableCollection<string>
            {
                "Item 1",
                "Item 2",
                "Item 3",
                "Item 4",
                "Item 5"
            };
			
			MyListView.ItemsSource = Items;
        }

        //Tap item = Pop up appears showing what item was tapped
        private void MyListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            try
            {
                var Items = MyListView.SelectedItem as string;

                DisplayAlert("Item Tapped", "This item was tapped: " + Items, "OK");
            }
            catch(Exception ex)
            {

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
            var result = Items.Where(x => x.Contains(keyword));

            MyListView.ItemsSource = result;
        }
    }
}
