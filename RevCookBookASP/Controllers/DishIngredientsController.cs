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
    public class DishIngredientsController : Controller
    {
        private readonly RevCookBookContext _context;

        public DishIngredientsController(RevCookBookContext context)
        {
            _context = context;
        }

        // GET: DishIngredients
        public async Task<IActionResult> Index()
        {
            var revCookBookContext = _context.DishIngredients.Include(d => d.Dish).Include(d => d.Ingredient);
            return View(await revCookBookContext.ToListAsync());
        }

        // GET: DishIngredients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dishIngredient = await _context.DishIngredients
                .Include(d => d.Dish)
                .Include(d => d.Ingredient)
                .FirstOrDefaultAsync(m => m.DishId == id);
            if (dishIngredient == null)
            {
                return NotFound();
            }

            return View(dishIngredient);
        }

        // GET: DishIngredients/Create
        public IActionResult Create()
        {
            ViewData["DishId"] = new SelectList(_context.Dishes, "DishId", "DishId");
            ViewData["IngredientId"] = new SelectList(_context.Ingredients, "IngredientId", "IngredientId");
            return View();
        }

        // POST: DishIngredients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Amount,IngredientId,DishId")] DishIngredient dishIngredient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dishIngredient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DishId"] = new SelectList(_context.Dishes, "DishId", "DishId", dishIngredient.DishId);
            ViewData["IngredientId"] = new SelectList(_context.Ingredients, "IngredientId", "IngredientId", dishIngredient.IngredientId);
            return View(dishIngredient);
        }

        // GET: DishIngredients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dishIngredient = await _context.DishIngredients.FindAsync(id);
            if (dishIngredient == null)
            {
                return NotFound();
            }
            ViewData["DishId"] = new SelectList(_context.Dishes, "DishId", "DishId", dishIngredient.DishId);
            ViewData["IngredientId"] = new SelectList(_context.Ingredients, "IngredientId", "IngredientId", dishIngredient.IngredientId);
            return View(dishIngredient);
        }

        // POST: DishIngredients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Amount,IngredientId,DishId")] DishIngredient dishIngredient)
        {
            if (id != dishIngredient.DishId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dishIngredient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DishIngredientExists(dishIngredient.DishId))
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
            ViewData["DishId"] = new SelectList(_context.Dishes, "DishId", "DishId", dishIngredient.DishId);
            ViewData["IngredientId"] = new SelectList(_context.Ingredients, "IngredientId", "IngredientId", dishIngredient.IngredientId);
            return View(dishIngredient);
        }

        // GET: DishIngredients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dishIngredient = await _context.DishIngredients
                .Include(d => d.Dish)
                .Include(d => d.Ingredient)
                .FirstOrDefaultAsync(m => m.DishId == id);
            if (dishIngredient == null)
            {
                return NotFound();
            }

            return View(dishIngredient);
        }

        // POST: DishIngredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dishIngredient = await _context.DishIngredients.FindAsync(id);
            _context.DishIngredients.Remove(dishIngredient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DishIngredientExists(int id)
        {
            return _context.DishIngredients.Any(e => e.DishId == id);
        }
    }
}
