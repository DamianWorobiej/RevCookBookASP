using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevCookBookASP.Models
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        public int LanguageId { get; set; }
        public int DishId { get; set; }
        public string Text { get; set; }


        public Language Language { get; set; }

        public Dish Dish { get; set; }
    }
}
