using System;
using System.Collections.ObjectModel;
using Pocket_Pantry.Models;

namespace Pocket_Pantry.View_Model
{
    public class Pantry_PageViewModel
    {

        public ObservableCollection<Pantry_PocketModel> PantryList { get; set; }

        public Pantry_PageViewModel()
        {
            PantryList = new ObservableCollection<Pantry_PocketModel>();

            PantryList.Add(new Pantry_PocketModel {
                Name = "Carrot",
                Image = "veggie.png",
                Category = "Veggie",
                Detail = "This is our detail page!" });

        }
    }
}
