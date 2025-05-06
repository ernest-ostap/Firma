using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Firma.Data;
using Firma.Data.Models;

namespace Firma.Intranet.Controllers
{
    public class DostawaController : Controller
    {
        private readonly FirmaDbContext _context;

        public DostawaController(FirmaDbContext context)
        {
            _context = context;
        }

        // GET: Dostawa
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dostawy.ToListAsync());
        }

        // GET: Dostawa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dostawa = await _context.Dostawy
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dostawa == null)
            {
                return NotFound();
            }

            return View(dostawa);
        }

        // GET: Dostawa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dostawa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Adres,Sposob,Status")] Dostawa dostawa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dostawa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dostawa);
        }

        // GET: Dostawa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dostawa = await _context.Dostawy.FindAsync(id);
            if (dostawa == null)
            {
                return NotFound();
            }
            return View(dostawa);
        }

        // POST: Dostawa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Adres,Sposob,Status")] Dostawa dostawa)
        {
            if (id != dostawa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dostawa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DostawaExists(dostawa.Id))
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
            return View(dostawa);
        }

        // GET: Dostawa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dostawa = await _context.Dostawy
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dostawa == null)
            {
                return NotFound();
            }

            return View(dostawa);
        }

        // POST: Dostawa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dostawa = await _context.Dostawy.FindAsync(id);
            if (dostawa != null)
            {
                _context.Dostawy.Remove(dostawa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DostawaExists(int id)
        {
            return _context.Dostawy.Any(e => e.Id == id);
        }
    }
}
