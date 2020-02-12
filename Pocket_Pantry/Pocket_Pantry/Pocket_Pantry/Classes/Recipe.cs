using System;
namespace Pocket_Pantry
{
    public class Recipe
    {
        // variables that every recipe will have
        public String title { get; set; }
        public String ingredients { get; set; }
        public String type { get; set; }
        public String directions { get; set; }

        public string image_Url { get; set; }

        public string getName()
        {
            return title;
        }

    }
}
