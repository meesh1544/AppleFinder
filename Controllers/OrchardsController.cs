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
    public class OrchardsController : Controller
    {
        private readonly AppleContext _context;

        public OrchardsController(AppleContext context)
        {
            _context = context;
        }

        // GET: Orchards
        public async Task<IActionResult> Index()
        {
            var appleContext = _context.Orchard.Include(o => o.Apples).Include(o => o.Map);
            return View(await appleContext.ToListAsync());
        }

        // GET: Orchards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Orchard == null)
            {
                return NotFound();
            }

            var orchard = await _context.Orchard
                .Include(o => o.Apples)
                .Include(o => o.Map)
                .FirstOrDefaultAsync(m => m.OrchardId == id);
            if (orchard == null)
            {
                return NotFound();
            }

            return View(orchard);
        }

        // GET: Orchards/Create
        public IActionResult Create()
        {
            ViewData["ApplesID"] = new SelectList(_context.Apples, "ApplesID", "ApplesID");
            ViewData["MapID"] = new SelectList(_context.Map, "MapID", "MapID");
            return View();
        }

        // POST: Orchards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrchardId,MapID,ApplesID")] Orchard orchard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orchard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplesID"] = new SelectList(_context.Apples, "ApplesID", "ApplesID", orchard.ApplesID);
            ViewData["MapID"] = new SelectList(_context.Map, "MapID", "MapID", orchard.MapID);
            return View(orchard);
        }

        // GET: Orchards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Orchard == null)
            {
                return NotFound();
            }

            var orchard = await _context.Orchard.FindAsync(id);
            if (orchard == null)
            {
                return NotFound();
            }
            ViewData["ApplesID"] = new SelectList(_context.Apples, "ApplesID", "ApplesID", orchard.ApplesID);
            ViewData["MapID"] = new SelectList(_context.Map, "MapID", "MapID", orchard.MapID);
            return View(orchard);
        }

        // POST: Orchards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrchardId,MapID,ApplesID")] Orchard orchard)
        {
            if (id != orchard.OrchardId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orchard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrchardExists(orchard.OrchardId))
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
            ViewData["ApplesID"] = new SelectList(_context.Apples, "ApplesID", "ApplesID", orchard.ApplesID);
            ViewData["MapID"] = new SelectList(_context.Map, "MapID", "MapID", orchard.MapID);
            return View(orchard);
        }

        // GET: Orchards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Orchard == null)
            {
                return NotFound();
            }

            var orchard = await _context.Orchard
                .Include(o => o.Apples)
                .Include(o => o.Map)
                .FirstOrDefaultAsync(m => m.OrchardId == id);
            if (orchard == null)
            {
                return NotFound();
            }

            return View(orchard);
        }

        // POST: Orchards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Orchard == null)
            {
                return Problem("Entity set 'AppleContext.Orchard'  is null.");
            }
            var orchard = await _context.Orchard.FindAsync(id);
            if (orchard != null)
            {
                _context.Orchard.Remove(orchard);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrchardExists(int id)
        {
          return (_context.Orchard?.Any(e => e.OrchardId == id)).GetValueOrDefault();
        }
    }
}
