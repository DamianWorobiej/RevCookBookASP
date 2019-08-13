using Microsoft.AspNetCore.Mvc.Rendering;
using RevCookBookASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevCookBookASP.ViewModels
{
    public class IngredientViewModel
    {
        public int IngredientId { get; set; }
        public string Name { get; set; }

        public ICollection<IngredientCategory> Categories { get; set; }
        public ICollection<Category> SelectedCategories { get; set; }
        public ICollection<int> CategoriesIds { get; set; }

        public MultiSelectList CategoriesList{ get; set; }

        public IngredientViewModel()
        {
            //needed to pass it to controller function
        }

        public IngredientViewModel(RevCookBookContext context, Ingredient ingredient = null)
        {
            if (ingredient != null)
            {
                IngredientId = ingredient.IngredientId;
                Name = ingredient.Name;
                Categories = ingredient.Categories;
            }
            populateLists(context);
        }

        private void populateLists(RevCookBookContext context)
        {
            //var categoriesList = new List<SelectListItem>();
            var selectedCategoriesIds = new List<int>();
            if (Categories != null)
            {
                foreach (var category in Categories)
                {
                    selectedCategoriesIds.Add(category.CategoryId);
                }
            }

            CategoriesList = new MultiSelectList(context.Categories, "CategoryId", "Name", selectedCategoriesIds);
            SelectedCategories = context.Categories
                .Where(category => selectedCategoriesIds.FindIndex(id => id == category.CategoryId) != -1)
                .ToList();
            //foreach (var category in context.Categories)
            //{
            //    SelectListItem selectListItem = new SelectListItem()
            //    {
            //        Text = category.Name,
            //        Value = category.CategoryId.ToString(),
            //        Selected = selectedCategoriesIds.FindIndex(id => id == category.CategoryId) != -1
            //    };
            //    categoriesList.Add(selectListItem);
            //}
            //CategoriesList = categoriesList;
        }
    }
}
