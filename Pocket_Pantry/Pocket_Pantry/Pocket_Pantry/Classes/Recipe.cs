﻿using System;
namespace Pocket_Pantry
{
    public class Recipe
    {
        // variables that every recipe will have
        public String Title { get; set; }
        public String Ingredients { get; set; }
        public String Type { get; set; }
        public String Directions { get; set; }

        public string ImageUrl { get; set; }

        public override string ToString()
        {
            return Title;
        }

    }
}