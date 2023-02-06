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
    public class PlantSizesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlantSizesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PlantSizes
        public async Task<IActionResult> Index()
        {
            return View(await _context.plantSizes.ToListAsync());
        }

        // GET: PlantSizes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plantSize = await _context.plantSizes
                .FirstOrDefaultAsync(m => m.SizeId == id);
            if (plantSize == null)
            {
                return NotFound();
            }

            return View(plantSize);
        }

        // GET: PlantSizes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PlantSizes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SizeId,SizeType")] PlantSize plantSize)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plantSize);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(plantSize);
        }

        // GET: PlantSizes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plantSize = await _context.plantSizes.FindAsync(id);
            if (plantSize == null)
            {
                return NotFound();
            }
            return View(plantSize);
        }

        // POST: PlantSizes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SizeId,SizeType")] PlantSize plantSize)
        {
            if (id != plantSize.SizeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plantSize);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlantSizeExists(plantSize.SizeId))
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
            return View(plantSize);
        }

        // GET: PlantSizes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plantSize = await _context.plantSizes
                .FirstOrDefaultAsync(m => m.SizeId == id);
            if (plantSize == null)
            {
                return NotFound();
            }

            return View(plantSize);
        }

        // POST: PlantSizes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var plantSize = await _context.plantSizes.FindAsync(id);
            _context.plantSizes.Remove(plantSize);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlantSizeExists(int id)
        {
            return _context.plantSizes.Any(e => e.SizeId == id);
        }
    }
}
