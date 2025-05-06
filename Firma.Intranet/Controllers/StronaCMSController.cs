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
    public class StronaCMSController : Controller
    {
        private readonly FirmaDbContext _context;

        public StronaCMSController(FirmaDbContext context)
        {
            _context = context;
        }

        // GET: StronaCMS
        public async Task<IActionResult> Index()
        {
            return View(await _context.StronyCMS.ToListAsync());
        }

        // GET: StronaCMS/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stronaCMS = await _context.StronyCMS
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stronaCMS == null)
            {
                return NotFound();
            }

            return View(stronaCMS);
        }

        // GET: StronaCMS/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StronaCMS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Klucz,Tresc")] StronaCMS stronaCMS)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stronaCMS);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stronaCMS);
        }

        // GET: StronaCMS/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stronaCMS = await _context.StronyCMS.FindAsync(id);
            if (stronaCMS == null)
            {
                return NotFound();
            }
            return View(stronaCMS);
        }

        // POST: StronaCMS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Klucz,Tresc")] StronaCMS stronaCMS)
        {
            if (id != stronaCMS.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stronaCMS);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StronaCMSExists(stronaCMS.Id))
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
            return View(stronaCMS);
        }

        // GET: StronaCMS/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stronaCMS = await _context.StronyCMS
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stronaCMS == null)
            {
                return NotFound();
            }

            return View(stronaCMS);
        }

        // POST: StronaCMS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stronaCMS = await _context.StronyCMS.FindAsync(id);
            if (stronaCMS != null)
            {
                _context.StronyCMS.Remove(stronaCMS);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StronaCMSExists(int id)
        {
            return _context.StronyCMS.Any(e => e.Id == id);
        }
    }
}
