using Firma.Data;
using Firma.Data.Models;
using Firma.PortalWWW.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Firma.PortalWWW.Controllers
{
    public class ProduktyController : Controller
    {
        private readonly FirmaDbContext _context;
        public ProduktyController(FirmaDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Lista(int? kategoriaId, decimal? cenaMax)
        {
            var produktyQuery = _context.Produkty
                .Include(p => p.Kategoria)
                .AsQueryable();

            if (kategoriaId.HasValue)
            {
                produktyQuery = produktyQuery.Where(p => p.KategoriaId == kategoriaId.Value);
            }

            if (cenaMax.HasValue)
            {
                produktyQuery = produktyQuery.Where(p => p.CenaWypozyczenia <= cenaMax.Value);
            }

            var viewModel = new ProduktListaViewModel
            {
                Produkty = await produktyQuery.ToListAsync(),
                Kategorie = await _context.Kategorie.ToListAsync(),
                WybranaKategoriaId = kategoriaId,
                CenaMaksymalna = cenaMax
            };

            return View(viewModel);
        }


        [HttpGet]
        public async Task<IActionResult> Szczegoly(int id)
        {
            var produkt = await _context.Produkty
                .Include(p => p.Recenzje!)
                    .ThenInclude(r => r.Klient)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (produkt == null)
                return NotFound();

            ViewBag.Produkt = produkt;
            return View(new Recenzja { ProduktId = id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Szczegoly(int id, Recenzja recenzja, string imie, string nazwisko, string email)
        {
            var produkt = _context.Produkty.Include(p => p.Recenzje).FirstOrDefault(p => p.Id == id);
            if (produkt == null) return NotFound();

            // Sprawdź, czy istnieje klient o danym emailu
            var klient = _context.Klienci.FirstOrDefault(k => k.Email == email);
            if (klient == null)
            {
                klient = new Klient
                {
                    Imie = imie,
                    Nazwisko = nazwisko,
                    Email = email
                };
                _context.Klienci.Add(klient);
                _context.SaveChanges();
            }

            // Dodaj recenzję — ustaw tylko KlientId i ProduktId!
            var nowaRecenzja = new Recenzja
            {
                Ocena = recenzja.Ocena,
                Komentarz = recenzja.Komentarz,
                KlientId = klient.Id,
                ProduktId = produkt.Id
            };

            _context.Recenzje.Add(nowaRecenzja);
            _context.SaveChanges();

            TempData["Sukces"] = "Dziękujemy za opinię!";
            return RedirectToAction("Szczegoly", new { id = id });
        }

    }
}


