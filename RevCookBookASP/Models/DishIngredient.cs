namespace RevCookBookASP.Models
{
    public class DishIngredient
    {
        public int Amount { get; set; }
        public int IngredientId { get; set; }
        public int DishId { get; set; }
        public Ingredient Ingredient { get; set; }
        public Dish Dish { get; set; }
    }
}