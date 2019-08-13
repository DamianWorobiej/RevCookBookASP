using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using RevCookBookASP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RevCookBookASP.ViewModels
{
    public class RecipeViewModel
    {
        public int RecipeId { get; set; }
        public int LanguageId { get; set; }
        public int DishId { get; set; }
        public string Text { get; set; }


        public Recipe Recipe { get; set; }
        public Language Language { get; set; }
        public Dish Dish { get; set; }

        public SelectList DishesList { get; set; }
        public SelectList LanguagesList { get; set; }

        public RecipeViewModel(RevCookBookContext context)
        {
            populateLists(context);
        }

        public RecipeViewModel(RevCookBookContext context, Recipe recipe)
        {
            Recipe = recipe;
            RecipeId = recipe.RecipeId;
            LanguageId = recipe.LanguageId;
            DishId = recipe.DishId;
            Text = recipe.Text;

            Dish = recipe.Dish;
            Language = recipe.Language;

            populateLists(context, recipe.DishId, recipe.LanguageId);
        }

        private void populateLists(RevCookBookContext context, object SelectedDishId = null, object SelectedLanguageId = null)
        {
            var dishesQuery = from dishes
                              in context.Dishes
                              orderby dishes.Name
                              select dishes;
            var languagesQuery = from languages 
                                 in context.Languages
                                 orderby languages.LanguageId
                                 select languages;
            DishesList = new SelectList(dishesQuery, "DishId", "Name", SelectedDishId);
            LanguagesList = new SelectList(languagesQuery, "LanguageId", "LanguageCode", SelectedDishId);
        }
    }
}
