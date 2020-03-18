using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using System.Text;


namespace Pocket_Pantry.Models
{
    public class Pantry_PocketModel

    {
        [PrimaryKey, AutoIncrement]
        public int id_ingredient { get; set; }
        public string ingredient_name { get; set; }
        public string Detail { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public string Ingredients { get; set; }

 
       

        public string getName()
        {
            return Ingredients;
        }
            //IEnumerable<Pantry_PocketModel> Pantry_PocketModels;


        }
}
