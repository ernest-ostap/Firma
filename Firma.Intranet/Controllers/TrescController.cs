using Microsoft.AspNetCore.Mvc;

namespace Firma.Intranet.Controllers
{
    public class TrescController : Controller
    {
        public IActionResult ZarzadzanieTrescia()
        {
            return View();
        }
    }
}
