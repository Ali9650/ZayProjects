using Microsoft.AspNetCore.Mvc;
using Zay_Projects.Areas.Admin.Models.Category;
using Zay_Projects.Data;

namespace Zay_Projects.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;
        public CategoryController(AppDbContext context)
        {
             _context = context;
        }
        #region List
        [HttpGet]
        public IActionResult Index()
        {
            var model = new CategoryIndexVM
            {
                Categories=_context.Categories.ToList()
            };
            return View(model);
        }

        #endregion

        #region Update

        [HttpGet]
        public IActionResult Update(int id)
        {
            var category = _context.Categories.Find(id);
            if (category is null) return NotFound();

            var model = new CategoryUpdateVM
            {
                Name = category.Name
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(int id, CategoryUpdateVM model)
        {
            if (!ModelState.IsValid) return View();

            var Category = _context.Categories.Find(id);
            if (Category is null) return NotFound();

            var isExist = _context.Categories.Any(wc => wc.Name.ToLower() == model.Name.ToLower() && wc.Id != id);
            if (isExist)
            {
                ModelState.AddModelError("Name", "Bu adda kateqoriya mövcuddur");
                return View();
            }

            if (Category.Name != model.Name)
                Category.UpdatedDate = DateTime.Now;

            Category.Name = model.Name;

            _context.Categories.Update(Category);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Delete 

        [HttpPost]
        public IActionResult Delete (int id)
        {
            var category = _context.Categories.Find(id);
        
        if (category is null) return NotFound();
        
        _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryCreateVM model)
        {
            if (!ModelState.IsValid) return View();

            var Category = _context.Categories.FirstOrDefault(wc => wc.Name.ToLower() == model.Name.ToLower());
            if (Category is not null)
            {
                ModelState.AddModelError("Name", "Bu adda kateqoriya mövcuddur");
                return View();
            }

            Category = new Entities.Category
            {
                Name = model.Name
            };

            _context.Categories.Add(Category);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        #endregion
    }
}
