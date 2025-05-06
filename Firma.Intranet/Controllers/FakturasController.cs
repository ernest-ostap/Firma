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
    public class FakturasController : Controller
    {
        private readonly FirmaDbContext _context;

        public FakturasController(FirmaDbContext context)
        {
            _context = context;
        }

        // GET: Fakturas
        public async Task<IActionResult> Index()
        {
            var firmaDbContext = _context.Faktury.Include(f => f.Klient);
            return View(await firmaDbContext.ToListAsync());
        }

        // GET: Fakturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faktura = await _context.Faktury
                .Include(f => f.Klient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (faktura == null)
            {
                return NotFound();
            }

            return View(faktura);
        }

        // GET: Fakturas/Create
        public IActionResult Create()
        {
            ViewData["KlientId"] = new SelectList(_context.Klienci, "Id", "Email");
            return View();
        }

        // POST: Fakturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataWystawienia,Kwota,KlientId,Uwagi")] Faktura faktura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(faktura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KlientId"] = new SelectList(_context.Klienci, "Id", "Email", faktura.KlientId);
            return View(faktura);
        }

        // GET: Fakturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faktura = await _context.Faktury.FindAsync(id);
            if (faktura == null)
            {
                return NotFound();
            }
            ViewData["KlientId"] = new SelectList(_context.Klienci, "Id", "Email", faktura.KlientId);
            return View(faktura);
        }

        // POST: Fakturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataWystawienia,Kwota,KlientId,Uwagi")] Faktura faktura)
        {
            if (id != faktura.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(faktura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FakturaExists(faktura.Id))
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
            ViewData["KlientId"] = new SelectList(_context.Klienci, "Id", "Email", faktura.KlientId);
            return View(faktura);
        }

        // GET: Fakturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faktura = await _context.Faktury
                .Include(f => f.Klient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (faktura == null)
            {
                return NotFound();
            }

            return View(faktura);
        }

        // POST: Fakturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var faktura = await _context.Faktury.FindAsync(id);
            if (faktura != null)
            {
                _context.Faktury.Remove(faktura);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FakturaExists(int id)
        {
            return _context.Faktury.Any(e => e.Id == id);
        }
    }
}
