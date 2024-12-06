using Microsoft.AspNetCore.Mvc;
using Zay_Projects.Data;
using Zay_Projects.Models;

namespace Zay_Projects.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;
        public ShopController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var Categories = _context.Categories.ToList();
            var CategoriesList= new List<CategoryVM>();
            var Products= _context.Products.ToList();
            var ProductsList = new List<ProductVM>();
            foreach (var product in Products)
            {
                var productVM = new ProductVM
                {
                    Title = product.Title,
                    PhotoName = product.PhotoName,
                    Price = product.Price,
                    Size = product.Size
                };
                ProductsList.Add(productVM);
            }
            foreach (var category in Categories)
            {
                var CategoryVM = new CategoryVM
                {
                    Id = category.Id,
                    Name = category.Name
                };
                CategoriesList.Add(CategoryVM);

            }
            var model = new ShopIndexVM
            {
                Products = ProductsList,
                Categories = CategoriesList
            };
            return View(model);
        }
       
        public IActionResult ShowProducts(int categoryId)
        {
           var products = _context.Products.ToList();
            if (categoryId>0) products=_context.Products.Where(p=>p.CategoryId==categoryId).ToList();
            
            return PartialView("_ProductPartial",products);
        }
        
        public IActionResult Detail(int id) 
        { 
            return View(); 
        }
    }
}
