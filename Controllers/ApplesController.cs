using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppleFinder.Models;

namespace AppleFinder.Controllers
{
    public class ApplesController : Controller
    {
        private readonly AppleContext _context;

        public ApplesController(AppleContext context)
        {
            _context = context;
        }

        // GET: Apples
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DescriptionSortParm"] = String.IsNullOrEmpty(sortOrder) ? "description_desc" : "";

              return _context.Apples != null ? 
                          View(await _context.Apples.ToListAsync()) :
                          Problem("Entity set 'AppleContext.Apples'  is null.");
        }

        // GET: Apples/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Apples == null)
            {
                return NotFound();
            }

            var apples = await _context.Apples
                .FirstOrDefaultAsync(m => m.ApplesID == id);
            if (apples == null)
            {
                return NotFound();
            }

            return View(apples);
        }

        // GET: Apples/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Apples/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApplesID,Name,Description")] Apples apples)
        {
            if (ModelState.IsValid)
            {
                _context.Add(apples);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(apples);
        }

        // GET: Apples/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Apples == null)
            {
                return NotFound();
            }

            var apples = await _context.Apples.FindAsync(id);
            if (apples == null)
            {
                return NotFound();
            }
            return View(apples);
        }

        // POST: Apples/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ApplesID,Name,Description")] Apples apples)
        {
            if (id != apples.ApplesID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apples);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplesExists(apples.ApplesID))
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
            return View(apples);
        }

        // GET: Apples/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Apples == null)
            {
                return NotFound();
            }

            var apples = await _context.Apples
                .FirstOrDefaultAsync(m => m.ApplesID == id);
            if (apples == null)
            {
                return NotFound();
            }

            return View(apples);
        }

        // POST: Apples/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Apples == null)
            {
                return Problem("Entity set 'AppleContext.Apples'  is null.");
            }
            var apples = await _context.Apples.FindAsync(id);
            if (apples != null)
            {
                _context.Apples.Remove(apples);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplesExists(int id)
        {
          return (_context.Apples?.Any(e => e.ApplesID == id)).GetValueOrDefault();
        }
    }
}
