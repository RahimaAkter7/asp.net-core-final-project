using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core_Auth.Data;
using Core_Auth.Models;

namespace Core_Auth.Controllers
{
    public class potsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public potsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: pots
        public async Task<IActionResult> Index()
        {
            return View(await _context.pots.ToListAsync());
        }

        // GET: pots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pot = await _context.pots
                .FirstOrDefaultAsync(m => m.potId == id);
            if (pot == null)
            {
                return NotFound();
            }

            return View(pot);
        }

        // GET: pots/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: pots/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("potId,potName")] pot pot)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pot);
        }

        // GET: pots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pot = await _context.pots.FindAsync(id);
            if (pot == null)
            {
                return NotFound();
            }
            return View(pot);
        }

        // POST: pots/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("potId,potName")] pot pot)
        {
            if (id != pot.potId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!potExists(pot.potId))
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
            return View(pot);
        }

        // GET: pots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pot = await _context.pots
                .FirstOrDefaultAsync(m => m.potId == id);
            if (pot == null)
            {
                return NotFound();
            }

            return View(pot);
        }

        // POST: pots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pot = await _context.pots.FindAsync(id);
            _context.pots.Remove(pot);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool potExists(int id)
        {
            return _context.pots.Any(e => e.potId == id);
        }
    }
}
