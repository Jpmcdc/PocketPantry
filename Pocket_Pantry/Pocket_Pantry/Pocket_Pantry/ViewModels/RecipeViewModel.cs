using System;
using System.Collections.ObjectModel;

namespace Pocket_Pantry.ViewModels
{
    public class RecipeViewModel
    {

        public ObservableCollection<Recipe> Recipe_List { get; set; }

        public RecipeViewModel()
        {
            Recipe GreekSalad = new Recipe
            {
                title = "Greek Salad",
                type = "Salads"
            };

            Recipe OnionSoup = new Recipe
            {
                title = "Onion Soup",
                type = "Soups"
            };

            Recipe Enchiladas = new Recipe
            {
                title = "Chicken Enchiladas",
                type = "Mexican"
            };

            Recipe LemonMeringue = new Recipe
            {
                title = "Lemon Meringue",
                type = "Cheesecake"
            };

            Recipe PBSandwitch = new Recipe
            {
                title = "Grilled Peanut Butter and Banana Sandwich",
                type = "Sandwich"
            };

            Recipe_List = new ObservableCollection<Recipe>();
            Recipe_List.Add(GreekSalad);
            Recipe_List.Add(OnionSoup);
            Recipe_List.Add(Enchiladas);
            Recipe_List.Add(LemonMeringue);
            Recipe_List.Add(PBSandwitch);
        }
    }
}