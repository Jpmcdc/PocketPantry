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
                Title = "Greek Salad",
                Type = "Salads"
            };

            Recipe OnionSoup = new Recipe
            {
                Title = "Onion Soup",
                Type = "Soups"
            };

            Recipe Enchiladas = new Recipe
            {
                Title = "Chicken Enchiladas",
                Type = "Mexican"
            };

            Recipe LemonMeringue = new Recipe
            {
                Title = "Lemon Meringue",
                Type = "Cheesecake"
            };

            Recipe PBSandwitch = new Recipe
            {
                Title = "Grilled Peanut Butter and Banana Sandwich",
                Type = "Sandwich"
            };

            Recipe_List = new ObservableCollection<Recipe>
            {
                GreekSalad,
                OnionSoup,
                Enchiladas,
                LemonMeringue,
                PBSandwitch
            };
        }
    }
}
