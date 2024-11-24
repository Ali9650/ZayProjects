using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Zay_Projects.Areas.Admin.Models.Product
{
    public class ProductUpdateVM
    {
        [Required(ErrorMessage = "Ad daxil edilməlidir")]
        [MinLength(3, ErrorMessage = "Adın minimum uzunluğu 3 simvol olmalıdır")]
        public string Title { get; set; }

      
        public string ?PhotoName { get; set; }
        public IFormFile ?Photo { get; set; }

        [Required(ErrorMessage = "Olcu daxil edilməlidir")]
        [MinLength(1, ErrorMessage = "Olcunun minimum uzunluğu 1 simvol olmalıdır")]
        public string Size { get; set; }

        [Required(ErrorMessage = "Qiymet daxil edilməlidir")]
        public string Price { get; set; }

        [Required(ErrorMessage = "Categoriya daxil edilməlidir")]
        [Display(Name = "Category ")]
        public int CategoryId { get; set; }
        public List<SelectListItem>? Categories { get; set; }
    }
}
