using System;
namespace Pocket_Pantry {
    public class Ingredient {

        // variables that every ingredient will have
        public String name { get; set; }
        public int quantity { get; set; }
        public String quantity_type { get; set; }
        public String[] categories { get; set; }
        public Boolean in_pantry { get; set; }

        public string ImageUrl { get; set; }

        public string getName() {
            return name;
        }
    }
}
