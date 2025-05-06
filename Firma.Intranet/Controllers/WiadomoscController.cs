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
    public class WiadomoscController : Controller
    {
        private readonly FirmaDbContext _context;

        public WiadomoscController(FirmaDbContext context)
        {
            _context = context;
        }

        // GET: Wiadomosc
        public async Task<IActionResult> Index()
        {
            return View(await _context.Wiadomosci.ToListAsync());
        }

        // GET: Wiadomosc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wiadomosc = await _context.Wiadomosci
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wiadomosc == null)
            {
                return NotFound();
            }

            return View(wiadomosc);
        }

        // GET: Wiadomosc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Wiadomosc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tresc,Temat,DataWiadomosci,DotyczyRezerwacji,EmailNadawcy,ImieNazwiskoNadawcy")] Wiadomosc wiadomosc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wiadomosc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wiadomosc);
        }

        // GET: Wiadomosc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wiadomosc = await _context.Wiadomosci.FindAsync(id);
            if (wiadomosc == null)
            {
                return NotFound();
            }
            return View(wiadomosc);
        }

        // POST: Wiadomosc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tresc,Temat,DataWiadomosci,DotyczyRezerwacji,EmailNadawcy,ImieNazwiskoNadawcy")] Wiadomosc wiadomosc)
        {
            if (id != wiadomosc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wiadomosc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WiadomoscExists(wiadomosc.Id))
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
            return View(wiadomosc);
        }

        // GET: Wiadomosc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wiadomosc = await _context.Wiadomosci
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wiadomosc == null)
            {
                return NotFound();
            }

            return View(wiadomosc);
        }

        // POST: Wiadomosc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wiadomosc = await _context.Wiadomosci.FindAsync(id);
            if (wiadomosc != null)
            {
                _context.Wiadomosci.Remove(wiadomosc);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WiadomoscExists(int id)
        {
            return _context.Wiadomosci.Any(e => e.Id == id);
        }
    }
}
