using Microsoft.AspNetCore.Mvc;

namespace Zay_Projects.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
