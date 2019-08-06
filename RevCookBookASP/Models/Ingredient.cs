using System.Collections.Generic;

namespace RevCookBookASP.Models
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public string Name { get; set; }

        public ICollection<IngredientCategory> Categories { get; set; }
        public ICollection<DishIngredient> Dishes { get; set; }
    }
}