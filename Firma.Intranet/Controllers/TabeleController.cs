using Microsoft.AspNetCore.Mvc;

namespace Firma.Intranet.Controllers
{
    public class TabeleController : Controller
    {
        public IActionResult Rezerwacje()
        {
            return View();
        }
        public IActionResult Klienci()
        {
            return View();
        }
        public IActionResult Sprzet()
        {
            return View();
        }
        public IActionResult Faktury()
        {
            return View();
        }



    }
}
