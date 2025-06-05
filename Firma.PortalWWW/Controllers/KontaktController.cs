using Firma.Data;
using Firma.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;

namespace Firma.PortalWWW.Controllers
{
    public class KontaktController : Controller
    {
        private readonly FirmaDbContext _context;

        public KontaktController(FirmaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var ustawienia = await _context.UstawieniaPortalu.FirstOrDefaultAsync();
            ViewBag.Ustawienia = ustawienia;

            // Provide a default value for the required property "Tresc"  
            return View(new Wiadomosc { Tresc = string.Empty });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Wiadomosc model)
        {
            var ustawienia = await _context.UstawieniaPortalu.FirstOrDefaultAsync();
            ViewBag.Ustawienia = ustawienia;

            if (ModelState.IsValid)
            {
                _context.Wiadomosci.Add(model);
                await _context.SaveChangesAsync();
                ViewBag.Sukces = "Dziękujemy za wiadomość! Skontaktujemy się wkrótce.";
                ModelState.Clear();
                return View(new Wiadomosc { Tresc = string.Empty });
            }

            return View(model);
        }
    }
}
