using Microsoft.AspNetCore.Mvc;
using Zay_Projects.Data;
using Zay_Projects.Migrations;
using Zay_Projects.Models;

namespace Zay_Projects.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var sliders=_context.Sliders.ToList();
            var slidersList = new List<SliderVM>();
            foreach (var slider in sliders)
            {
                var sliderVM = new SliderVM
                {
                     Description = slider.Description,
                     Title = slider.Title,
                     ImgUrl = slider.ImgUrl,
                     Name = slider.Name
                };
               slidersList.Add(sliderVM);
            }
            var model = new HomeIndexVM
            {
                Sliders = slidersList
            };


            return View(model);
        }
    }
}
