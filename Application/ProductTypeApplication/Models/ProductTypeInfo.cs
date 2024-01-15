
namespace Application.ProductTypeApplication.Models
{
    public class ProductTypeInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ProductTypeInfo? ProductTypeParent { get; set; }
        public bool IsActive { get; set; }
        public string H1 { get; set; }
        public string? Url { get; set; }
        public string? Body { get; set; }
        public int? Priority { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
