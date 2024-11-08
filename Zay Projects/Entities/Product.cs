namespace Zay_Projects.Entities
{
    public class Product :BaseEntity
    {
        public string Title { get; set; }
        public string ImgUrl { get; set; }
        public string Size { get; set; }
        public string Price { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; } 
    }
}
