using Microsoft.AspNetCore.Mvc;
using Zay_Projects.Data;
using Zay_Projects.Models;

namespace Zay_Projects.ViewComponents
{
    public class BrandViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public BrandViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke() 
        {
            var model = new BrandVM
            {
                Brand=_context.Brand.FirstOrDefault(),
                Photos = _context.BrandPhotos.ToList()
            };
            return View(model);
        
        }
    }
}
