using System.Collections.Generic;

namespace RevCookBookASP.Models
{
    public class Dish
    {
        public int DishId { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }

        public ICollection<DishIngredient> Ingredients { get; set; }
        public ICollection<Recipe> Recipes { get; set; }
    }
}