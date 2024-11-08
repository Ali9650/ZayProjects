﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Zay_Projects.Areas.Admin.Models.Product;
using Zay_Projects.Data;

namespace Zay_Projects.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        #region Read
        [HttpGet]
        public IActionResult Index()
        {
            var model = new ProductIndexVM()
            {
                Products =_context.Products.Include(c=>c.Category).ToList(),
            };
            return View(model);
        }
        #endregion

        #region Create

        [HttpGet]
        public IActionResult Create()
        {
            var model = new ProductCreatVM
            {
                Categories = _context.Categories.Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }).ToList()
            };

            return View(model);
            
        }
        [HttpPost]
        public IActionResult Create(ProductCreatVM model)
        {
            model.Categories=_context.Categories.Select(c=>new SelectListItem
            {
                Text=c.Name,
                Value=c.Id.ToString()
            }).ToList();
            if (!ModelState.IsValid) return View(model);
           
            var category = _context.Categories.FirstOrDefault(c=>c.Id== model.CategoryId);  
            if (category == null) return NotFound();
            var Product = new Entities.Product
            {
                Title = model.Title,
                Size = model.Size,
                ImgUrl = model.ImgUrl,
                Price = model.Price,
                CategoryId = model.CategoryId
            };
            _context.Products.Add(Product);
            _context.SaveChanges(); 
            return RedirectToAction(nameof(Index));
        }


        #endregion


        #region update
        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = _context.Products.FirstOrDefault(c=>c.Id== id);
            if (product == null) return NotFound();
            var model = new ProductUpdateVM()
            {
                Title=product.Title,
                Size = product.Size,
                ImgUrl=product.ImgUrl,
                Price = product.Price,
                CategoryId = product.CategoryId,
                Categories=_context.Categories.Select(c=> new SelectListItem
                {
                    Text=c.Name,
                    Value=c.Id.ToString()
                }).ToList()

            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Update(int id, ProductUpdateVM model)
        {
            model.Categories = _context.Categories.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }).ToList();

            var product = _context.Products.FirstOrDefault(p=>p.Id== id);
            if (product == null) return NotFound();
            var category = _context.Categories.FirstOrDefault(c=>c.Id== model.CategoryId);
            if (category == null)
            {
                ModelState.AddModelError("CategoryId ", "Bele bir kategoriya yoxdur");
               return View(model);
            }

            product.Title = model.Title;
            product.Size = model.Size;
            product.ImgUrl = model.ImgUrl;
            product.Price = model.Price;
            product.CategoryId = model.CategoryId;
            product.UpdatedDate=DateTime.Now;

            _context.Products.Update(product);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        #endregion


        #region Delete
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}