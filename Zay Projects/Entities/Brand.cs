namespace Zay_Projects.Entities
{
    public class Brand :BaseEntity
    {
        public string Title { get; set; }
        public string Desciption { get; set; }
        public List<BrandPhoto> Photos { get; set; }
    }
}
