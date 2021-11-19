using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecipeBooklet.Models;
using RecipeBooklet.Data;

namespace RecipeBooklet.Controllers
{
    public class RecipeBooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecipeBooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RecipeBooks
        public async Task<IActionResult> Index()
        {
            return View(await _context.RecipeBook.ToListAsync());
        }
       
        // GET: RecipeBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeBook = await _context.RecipeBook
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recipeBook == null)
            {
                return NotFound();
            }

            return View(recipeBook);
        }

        // GET: RecipeBooks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RecipeBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,RecipeId")] RecipeBook recipeBook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recipeBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recipeBook);
        }

        // GET: RecipeBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeBook = await _context.RecipeBook.FindAsync(id);
            if (recipeBook == null)
            {
                return NotFound();
            }
            return View(recipeBook);
        }

        // POST: RecipeBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,RecipeId")] RecipeBook recipeBook)
        {
            if (id != recipeBook.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipeBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeBookExists(recipeBook.Id))
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
            return View(recipeBook);
        }

        // GET: RecipeBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeBook = await _context.RecipeBook
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recipeBook == null)
            {
                return NotFound();
            }

            return View(recipeBook);
        }

        // POST: RecipeBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipeBook = await _context.RecipeBook.FindAsync(id);
            _context.RecipeBook.Remove(recipeBook);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipeBookExists(int id)
        {
            return _context.RecipeBook.Any(e => e.Id == id);
        }
    }
}
