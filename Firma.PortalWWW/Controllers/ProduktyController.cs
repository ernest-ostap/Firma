using Microsoft.AspNetCore.Mvc;

namespace Firma.PortalWWW.Controllers
{
    public class ProduktyController : Controller
    {
        public IActionResult Lista()
        {
            // Tu dane z bazy (efcore)
            return View();
        }

        public IActionResult Szczegoly(int id)
        {
            // Do dodania pozniej - pobieranie id z bazy
            ViewBag.IdProduktu = id;
            return View();
        }
    }
}
