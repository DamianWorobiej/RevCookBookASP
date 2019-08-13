using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RevCookBookASP.Models;
using RevCookBookASP.ViewModels;

namespace RevCookBookASP.Controllers
{
    public class IngredientsController : Controller
    {
        private readonly RevCookBookContext _context;

        public IngredientsController(RevCookBookContext context)
        {
            _context = context;
        }

        // GET: Ingredients
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ingredients.ToListAsync());
        }

        // GET: Ingredients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredient = await _context.Ingredients
                .Include(model => model.Categories)
                .FirstOrDefaultAsync(m => m.IngredientId == id);
            if (ingredient == null)
            {
                return NotFound();
            }

            var ingredientViewModel = new IngredientViewModel(_context, ingredient);

            return View(ingredientViewModel);
        }

        // GET: Ingredients/Create
        public IActionResult Create()
        {
            return View(new IngredientViewModel(_context));
        }

        // POST: Ingredients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IngredientId,Name,CategoriesIds")] IngredientViewModel ingredientViewModel)
        {
            var ingredient = new Ingredient()
            {
                IngredientId = ingredientViewModel.IngredientId,
                Name = ingredientViewModel.Name
            };
            if (ModelState.IsValid)
            {
                _context.Add(ingredient);

                var pivots = _context.IngredientCategories
                        .Where(category => category.IngredientId == ingredient.IngredientId)
                        .ToList();

                foreach (var pivot in pivots)
                {
                    _context.Remove(pivot);
                }

                foreach (var categoryId in ingredientViewModel.CategoriesIds)
                {
                    _context.Add(new IngredientCategory()
                    {
                        IngredientId = ingredient.IngredientId,
                        CategoryId = categoryId
                    });
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ingredient);
        }

        // GET: Ingredients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredient = await _context.Ingredients.FindAsync(id);
            ingredient.Categories = await _context.IngredientCategories
                .Where(category => category.IngredientId == ingredient.IngredientId)
                .ToListAsync();

            if (ingredient == null)
            {
                return NotFound();
            }

            var ingredientViewModel = new IngredientViewModel(_context, ingredient);

            return View(ingredientViewModel);
        }

        // POST: Ingredients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IngredientId,Name,CategoriesIds")] IngredientViewModel ingredientViewModel)
        {
            var ingredient = new Ingredient()
            {
                IngredientId = ingredientViewModel.IngredientId,
                Name = ingredientViewModel.Name
            };

            if (id != ingredient.IngredientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ingredient);

                    var pivots = _context.IngredientCategories
                        .Where(category => category.IngredientId == ingredient.IngredientId)
                        .ToList();

                    foreach (var pivot in pivots)
                    {
                        _context.Remove(pivot);
                    }

                    foreach (var categoryId in ingredientViewModel.CategoriesIds)
                    {
                        _context.Add(new IngredientCategory()
                        {
                            IngredientId = ingredient.IngredientId,
                            CategoryId = categoryId
                        });
                    }

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IngredientExists(ingredient.IngredientId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ingredient);
        }

        // GET: Ingredients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredient = await _context.Ingredients
                .FirstOrDefaultAsync(m => m.IngredientId == id);
            if (ingredient == null)
            {
                return NotFound();
            }

            return View(ingredient);
        }

        // POST: Ingredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ingredient = await _context.Ingredients.FindAsync(id);
            _context.Ingredients.Remove(ingredient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IngredientExists(int id)
        {
            return _context.Ingredients.Any(e => e.IngredientId == id);
        }
    }
}
