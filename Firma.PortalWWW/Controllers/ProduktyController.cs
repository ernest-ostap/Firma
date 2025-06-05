using Firma.Data;
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


        public async Task<IActionResult> Szczegoly(int id)
        {
            var produkt = await _context.Produkty
                .Include(p => p.Kategoria)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (produkt == null)
                return NotFound();

            return View(produkt);
        }
    }
}
