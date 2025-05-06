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
    public class UstawieniaPortaluController : Controller
    {
        private readonly FirmaDbContext _context;

        public UstawieniaPortaluController(FirmaDbContext context)
        {
            _context = context;
        }

        // GET: UstawieniaPortalu
        public async Task<IActionResult> Index()
        {
            return View(await _context.UstawieniaPortalu.ToListAsync());
        }

        // GET: UstawieniaPortalu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ustawieniaPortalu = await _context.UstawieniaPortalu
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ustawieniaPortalu == null)
            {
                return NotFound();
            }

            return View(ustawieniaPortalu);
        }

        // GET: UstawieniaPortalu/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UstawieniaPortalu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GodzinyPracy,Kontakt,DaneFirmy")] UstawieniaPortalu ustawieniaPortalu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ustawieniaPortalu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ustawieniaPortalu);
        }

        // GET: UstawieniaPortalu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ustawieniaPortalu = await _context.UstawieniaPortalu.FindAsync(id);
            if (ustawieniaPortalu == null)
            {
                return NotFound();
            }
            return View(ustawieniaPortalu);
        }

        // POST: UstawieniaPortalu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GodzinyPracy,Kontakt,DaneFirmy")] UstawieniaPortalu ustawieniaPortalu)
        {
            if (id != ustawieniaPortalu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ustawieniaPortalu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UstawieniaPortaluExists(ustawieniaPortalu.Id))
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
            return View(ustawieniaPortalu);
        }

        // GET: UstawieniaPortalu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ustawieniaPortalu = await _context.UstawieniaPortalu
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ustawieniaPortalu == null)
            {
                return NotFound();
            }

            return View(ustawieniaPortalu);
        }

        // POST: UstawieniaPortalu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ustawieniaPortalu = await _context.UstawieniaPortalu.FindAsync(id);
            if (ustawieniaPortalu != null)
            {
                _context.UstawieniaPortalu.Remove(ustawieniaPortalu);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UstawieniaPortaluExists(int id)
        {
            return _context.UstawieniaPortalu.Any(e => e.Id == id);
        }
    }
}
