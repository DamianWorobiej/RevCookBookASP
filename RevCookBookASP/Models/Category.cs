using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RevCookBookASP.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public ICollection<IngredientCategory> Ingredients { get; set; }
    }
}