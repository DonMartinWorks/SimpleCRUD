using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SimpleCRUD.Data;
using SimpleCRUD.Models;

namespace SimpleCRUD.Controllers
{
    public class AutomovilesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AutomovilesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Automoviles
        public async Task<IActionResult> Index()
        {
              return _context.Automoviles != null ? 
                          View(await _context.Automoviles.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Automoviles'  is null.");
        }

        // GET: Automoviles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Automoviles == null)
            {
                return NotFound();
            }

            var automovil = await _context.Automoviles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (automovil == null)
            {
                return NotFound();
            }

            return View(automovil);
        }

        // GET: Automoviles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Automoviles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Brand,Model,Kilometers,Price")] Automovil automovil)
        {
            if (ModelState.IsValid)
            {
                _context.Add(automovil);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(automovil);
        }

        // GET: Automoviles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Automoviles == null)
            {
                return NotFound();
            }

            var automovil = await _context.Automoviles.FindAsync(id);
            if (automovil == null)
            {
                return NotFound();
            }
            return View(automovil);
        }

        // POST: Automoviles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Brand,Model,Kilometers,Price")] Automovil automovil)
        {
            if (id != automovil.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(automovil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutomovilExists(automovil.Id))
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
            return View(automovil);
        }

        // GET: Automoviles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Automoviles == null)
            {
                return NotFound();
            }

            var automovil = await _context.Automoviles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (automovil == null)
            {
                return NotFound();
            }

            return View(automovil);
        }

        // POST: Automoviles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Automoviles == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Automoviles'  is null.");
            }
            var automovil = await _context.Automoviles.FindAsync(id);
            if (automovil != null)
            {
                _context.Automoviles.Remove(automovil);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutomovilExists(int id)
        {
          return (_context.Automoviles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
