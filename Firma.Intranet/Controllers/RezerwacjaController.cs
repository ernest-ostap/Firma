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
    public class RezerwacjaController : Controller
    {
        private readonly FirmaDbContext _context;

        public RezerwacjaController(FirmaDbContext context)
        {
            _context = context;
        }

        // GET: Rezerwacja
        public async Task<IActionResult> Index()
        {
            var firmaDbContext = _context.Rezerwacje.Include(r => r.Klient).Include(r => r.Produkt);
            return View(await firmaDbContext.ToListAsync());
        }

        // GET: Rezerwacja/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezerwacja = await _context.Rezerwacje
                .Include(r => r.Klient)
                .Include(r => r.Produkt)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rezerwacja == null)
            {
                return NotFound();
            }

            return View(rezerwacja);
        }

        // GET: Rezerwacja/Create
        public IActionResult Create()
        {
            ViewData["KlientId"] = new SelectList(_context.Klienci, "Id", "Email");
            ViewData["ProduktId"] = new SelectList(_context.Produkty, "Id", "Nazwa");
            return View();
        }

        // POST: Rezerwacja/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataOd,DataDo,Status,KlientId,ProduktId")] Rezerwacja rezerwacja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rezerwacja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KlientId"] = new SelectList(_context.Klienci, "Id", "Email", rezerwacja.KlientId);
            ViewData["ProduktId"] = new SelectList(_context.Produkty, "Id", "Nazwa", rezerwacja.ProduktId);
            return View(rezerwacja);
        }

        // GET: Rezerwacja/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezerwacja = await _context.Rezerwacje.FindAsync(id);
            if (rezerwacja == null)
            {
                return NotFound();
            }
            ViewData["KlientId"] = new SelectList(_context.Klienci, "Id", "Email", rezerwacja.KlientId);
            ViewData["ProduktId"] = new SelectList(_context.Produkty, "Id", "Nazwa", rezerwacja.ProduktId);
            return View(rezerwacja);
        }

        // POST: Rezerwacja/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataOd,DataDo,Status,KlientId,ProduktId")] Rezerwacja rezerwacja)
        {
            if (id != rezerwacja.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rezerwacja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RezerwacjaExists(rezerwacja.Id))
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
            ViewData["KlientId"] = new SelectList(_context.Klienci, "Id", "Email", rezerwacja.KlientId);
            ViewData["ProduktId"] = new SelectList(_context.Produkty, "Id", "Nazwa", rezerwacja.ProduktId);
            return View(rezerwacja);
        }

        // GET: Rezerwacja/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezerwacja = await _context.Rezerwacje
                .Include(r => r.Klient)
                .Include(r => r.Produkt)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rezerwacja == null)
            {
                return NotFound();
            }

            return View(rezerwacja);
        }

        // POST: Rezerwacja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rezerwacja = await _context.Rezerwacje.FindAsync(id);
            if (rezerwacja != null)
            {
                _context.Rezerwacje.Remove(rezerwacja);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RezerwacjaExists(int id)
        {
            return _context.Rezerwacje.Any(e => e.Id == id);
        }
    }
}
