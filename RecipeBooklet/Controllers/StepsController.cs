using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecipeBooklet.Data;
using RecipeBooklet.Models;

namespace RecipeBooklet.Controllers
{
    public class StepsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StepsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Steps
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Steps.Include(s => s.Recipe);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Steps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var steps = await _context.Steps
                .Include(s => s.Recipe)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (steps == null)
            {
                return NotFound();
            }

            return View(steps);
        }

        // GET: Steps/Create
        public IActionResult Create()
        {
            ViewData["RecipeId"] = new SelectList(_context.Recipe, "Id", "Description");
            return View();
        }

        // POST: Steps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,RecipeId")] Steps steps)
        {
            if (ModelState.IsValid)
            {
                _context.Add(steps);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RecipeId"] = new SelectList(_context.Recipe, "Id", "Description", steps.RecipeId);
            return View(steps);
        }

        // GET: Steps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var steps = await _context.Steps.FindAsync(id);
            if (steps == null)
            {
                return NotFound();
            }
            ViewData["RecipeId"] = new SelectList(_context.Recipe, "Id", "Description", steps.RecipeId);
            return View(steps);
        }

        // POST: Steps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,RecipeId")] Steps steps)
        {
            if (id != steps.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(steps);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StepsExists(steps.Id))
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
            ViewData["RecipeId"] = new SelectList(_context.Recipe, "Id", "Description", steps.RecipeId);
            return View(steps);
        }

        // GET: Steps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var steps = await _context.Steps
                .Include(s => s.Recipe)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (steps == null)
            {
                return NotFound();
            }

            return View(steps);
        }

        // POST: Steps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var steps = await _context.Steps.FindAsync(id);
            _context.Steps.Remove(steps);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StepsExists(int id)
        {
            return _context.Steps.Any(e => e.Id == id);
        }
    }
}
