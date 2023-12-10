using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppleFinder.Models;
using Microsoft.AspNetCore.Authorization;

namespace AppleFinder.Controllers
{
    public class MemberController : Controller
    {
        private readonly AppleContext _context;

        public MemberController(AppleContext context)
        {
            _context = context;
        }

        // GET: Member
        [Authorize(Roles ="Administrator, Manager, User")]
        public async Task<IActionResult> Index()
        {
            return _context.Membership != null ?
                        View(await _context.Membership.ToListAsync()) :
                          Problem("Entity set 'AppleContext.Membership'  is null.");
        }

        // GET: Member/Details/5
        [Authorize(Roles = "Administrator, Manager, User")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Membership == null)
            {
                return NotFound();
            }

            var members = await _context.Membership
                .FirstOrDefaultAsync(m => m.ID == id);
            if (members == null)
            {
                return NotFound();
            }

            return View(members);
        }

        // GET: Member/Create
        [Authorize(Roles = "Administrator, Manager")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Member/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,GenderIdentity,Address,City,State,Zip,Email,Cell")] Members members)
        {
            if (ModelState.IsValid)
            {
                _context.Add(members);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(members);
        }

        // GET: Member/Edit/5
        [Authorize(Roles = "Administrator, Manager")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Membership == null)
            {
                return NotFound();
            }

            var members = await _context.Membership.FindAsync(id);
            if (members == null)
            {
                return NotFound();
            }
            return View(members);
        }

        // POST: Member/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrator, Manager")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,GenderIdentity,Address,City,State,Zip,Email,Cell")] Members members)
        {
            if (id != members.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(members);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MembersExists(members.ID))
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
            return View(members);
        }

        // GET: Member/Delete/5
        [Authorize(Roles = "Administrator, Manager")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Membership == null)
            {
                return NotFound();
            }

            var members = await _context.Membership
                .FirstOrDefaultAsync(m => m.ID == id);
            if (members == null)
            {
                return NotFound();
            }

            return View(members);
        }

        // POST: Member/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, Manager")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Membership == null)
            {
                return Problem("Entity set 'AppleContext.Membership'  is null.");
            }
            var members = await _context.Membership.FindAsync(id);
            if (members != null)
            {
                _context.Membership.Remove(members);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MembersExists(int id)
        {
          return (_context.Membership?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
