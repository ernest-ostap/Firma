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
    public class RecenzjaController : Controller
    {
        private readonly FirmaDbContext _context;

        public RecenzjaController(FirmaDbContext context)
        {
            _context = context;
        }

        // GET: Recenzja
        public async Task<IActionResult> Index()
        {
            var firmaDbContext = _context.Recenzje.Include(r => r.Klient).Include(r => r.Produkt);
            return View(await firmaDbContext.ToListAsync());
        }

        // GET: Recenzja/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recenzja = await _context.Recenzje
                .Include(r => r.Klient)
                .Include(r => r.Produkt)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recenzja == null)
            {
                return NotFound();
            }

            return View(recenzja);
        }

        // GET: Recenzja/Create
        public IActionResult Create()
        {
            ViewData["KlientId"] = new SelectList(_context.Klienci, "Id", "Email");
            ViewData["ProduktId"] = new SelectList(_context.Produkty, "Id", "Nazwa");
            return View();
        }

        // POST: Recenzja/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ocena,Komentarz,ProduktId,KlientId")] Recenzja recenzja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recenzja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KlientId"] = new SelectList(_context.Klienci, "Id", "Email", recenzja.KlientId);
            ViewData["ProduktId"] = new SelectList(_context.Produkty, "Id", "Nazwa", recenzja.ProduktId);
            return View(recenzja);
        }

        // GET: Recenzja/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recenzja = await _context.Recenzje.FindAsync(id);
            if (recenzja == null)
            {
                return NotFound();
            }
            ViewData["KlientId"] = new SelectList(_context.Klienci, "Id", "Email", recenzja.KlientId);
            ViewData["ProduktId"] = new SelectList(_context.Produkty, "Id", "Nazwa", recenzja.ProduktId);
            return View(recenzja);
        }

        // POST: Recenzja/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ocena,Komentarz,ProduktId,KlientId")] Recenzja recenzja)
        {
            if (id != recenzja.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recenzja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecenzjaExists(recenzja.Id))
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
            ViewData["KlientId"] = new SelectList(_context.Klienci, "Id", "Email", recenzja.KlientId);
            ViewData["ProduktId"] = new SelectList(_context.Produkty, "Id", "Nazwa", recenzja.ProduktId);
            return View(recenzja);
        }

        // GET: Recenzja/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recenzja = await _context.Recenzje
                .Include(r => r.Klient)
                .Include(r => r.Produkt)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recenzja == null)
            {
                return NotFound();
            }

            return View(recenzja);
        }

        // POST: Recenzja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recenzja = await _context.Recenzje.FindAsync(id);
            if (recenzja != null)
            {
                _context.Recenzje.Remove(recenzja);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecenzjaExists(int id)
        {
            return _context.Recenzje.Any(e => e.Id == id);
        }
    }
}
