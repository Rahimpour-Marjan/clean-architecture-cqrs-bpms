
using Application.ProductTypeApplication.Models;

namespace Application.ProductBrandApplication.Models
{
    public class ProductBrandInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ProductTypeInfo? ProductType { get; set; }
        public bool IsActive { get; set; }
        public string H1 { get; set; }
        public string? Url { get; set; }
        public string? Body { get; set; }
        public string? Description { get; set; }
        public int? Priority { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
