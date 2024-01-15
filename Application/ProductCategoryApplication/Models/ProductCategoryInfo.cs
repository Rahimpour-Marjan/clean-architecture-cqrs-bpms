
namespace Application.ProductCategoryApplication.Models
{
    public class ProductCategoryInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ProductCategoryInfo? ProductCategoryParent { get; set; }
        public bool IsActive { get; set; }
        public string? Url { get; set; }
        public string? Body { get; set; }
        public bool? Deleted { get; set; }
        public string? Canonical { get; set; }
        public bool? NoFollow { get; set; }
        public bool? NoIndex { get; set; }
        public int? Priority { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
