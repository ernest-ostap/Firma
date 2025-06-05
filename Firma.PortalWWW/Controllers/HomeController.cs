using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Firma.PortalWWW.Models;
using Firma.Data; 
using System.Linq; 
using Microsoft.EntityFrameworkCore; 
using Firma.Data.Models;
using System.Threading.Tasks;

namespace Firma.PortalWWW.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly FirmaDbContext _context; 

    public HomeController(ILogger<HomeController> logger, FirmaDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        // Banery z tabeli StronaCMS
        var banery = _context.StronyCMS
            .Where(s => s.Klucz.StartsWith("Baner"))
            .OrderBy(s => s.Klucz)
            .Select(s => s.Tresc)
            .ToList();

        // Bestseller ID z CMS
        var bestsellerKeys = new[] { "Bestseller1", "Bestseller2", "Bestseller3", "Bestseller4" };
        var bestsellerIds = _context.StronyCMS
            .Where(s => bestsellerKeys.Contains(s.Klucz))
            .ToDictionary(s => s.Klucz, s => int.TryParse(s.Tresc, out var id) ? id : 0);

        var bestsellery = _context.Produkty
            .Where(p => bestsellerIds.Values.Contains(p.Id))
            .ToList();

        ViewBag.Banery = banery;
        ViewBag.Bestsellery = bestsellery;

        return View();
    }

    public async Task<IActionResult> OpisFirmy()
    {
        //Klucze z cms do opisów firmy
        var cms = await _context.StronyCMS
            .ToDictionaryAsync(s => s.Klucz, s => s.Tresc);

        var model = new OpisFirmyViewModel
        {
            Onas = cms.ContainsKey("Onas") ? cms["Onas"] : "Brak informacji.",
            NaszaMisja = cms.ContainsKey("NaszaMisja") ? cms["NaszaMisja"] : "Brak informacji.",
            NaszeUslugi = cms.ContainsKey("NaszeUslugi") ? cms["NaszeUslugi"] : "Brak informacji.",
            NaszZespol = cms.ContainsKey("NaszZespol") ? cms["NaszZespol"] : "Brak informacji.",
            DlaczegoMy = cms.ContainsKey("DlaczegoMy") ? cms["DlaczegoMy"] : "Brak informacji."
        };

        return View(model);
    }

    public IActionResult Kontakt()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
