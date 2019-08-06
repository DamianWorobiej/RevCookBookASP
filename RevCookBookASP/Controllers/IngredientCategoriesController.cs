using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RevCookBookASP.Models;

namespace RevCookBookASP.Controllers
{
    public class IngredientCategoriesController : Controller
    {
        private readonly RevCookBookContext _context;

        public IngredientCategoriesController(RevCookBookContext context)
        {
            _context = context;
        }

        // GET: IngredientCategories
        public async Task<IActionResult> Index()
        {
            var revCookBookContext = _context.IngredientCategories.Include(i => i.Category).Include(i => i.Ingredient);
            return View(await revCookBookContext.ToListAsync());
        }

        // GET: IngredientCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredientCategory = await _context.IngredientCategories
                .Include(i => i.Category)
                .Include(i => i.Ingredient)
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (ingredientCategory == null)
            {
                return NotFound();
            }

            return View(ingredientCategory);
        }

        // GET: IngredientCategories/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId");
            ViewData["IngredientId"] = new SelectList(_context.Ingredients, "IngredientId", "IngredientId");
            return View();
        }

        // POST: IngredientCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IngredientId,CategoryId")] IngredientCategory ingredientCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ingredientCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", ingredientCategory.CategoryId);
            ViewData["IngredientId"] = new SelectList(_context.Ingredients, "IngredientId", "IngredientId", ingredientCategory.IngredientId);
            return View(ingredientCategory);
        }

        // GET: IngredientCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredientCategory = await _context.IngredientCategories.FindAsync(id);
            if (ingredientCategory == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", ingredientCategory.CategoryId);
            ViewData["IngredientId"] = new SelectList(_context.Ingredients, "IngredientId", "IngredientId", ingredientCategory.IngredientId);
            return View(ingredientCategory);
        }

        // POST: IngredientCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IngredientId,CategoryId")] IngredientCategory ingredientCategory)
        {
            if (id != ingredientCategory.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ingredientCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IngredientCategoryExists(ingredientCategory.CategoryId))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", ingredientCategory.CategoryId);
            ViewData["IngredientId"] = new SelectList(_context.Ingredients, "IngredientId", "IngredientId", ingredientCategory.IngredientId);
            return View(ingredientCategory);
        }

        // GET: IngredientCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredientCategory = await _context.IngredientCategories
                .Include(i => i.Category)
                .Include(i => i.Ingredient)
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (ingredientCategory == null)
            {
                return NotFound();
            }

            return View(ingredientCategory);
        }

        // POST: IngredientCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ingredientCategory = await _context.IngredientCategories.FindAsync(id);
            _context.IngredientCategories.Remove(ingredientCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IngredientCategoryExists(int id)
        {
            return _context.IngredientCategories.Any(e => e.CategoryId == id);
        }
    }
}
