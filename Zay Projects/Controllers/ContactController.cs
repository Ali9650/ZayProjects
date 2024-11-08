using Microsoft.AspNetCore.Mvc;

namespace Zay_Projects.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.isContact = true;
            return View();
        }
    }
}
