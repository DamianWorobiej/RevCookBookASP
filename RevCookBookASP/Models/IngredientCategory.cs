using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevCookBookASP.Models
{
    public class IngredientCategory
    {
        public int IngredientId { get; set; }
        public int CategoryId { get; set; }

        public Ingredient Ingredient { get; set; }
        public Category Category { get; set; }
    }
}
