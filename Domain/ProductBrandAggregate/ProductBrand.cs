
namespace Domain
{
    public class ProductBrand
    {
        protected ProductBrand() { }

        public ProductBrand(string title, int? productTypeId, bool isActive, string h1, string? url, string? body, string? description, int? priority ,string? imageUrl, DateTime modifiedDate)
        {
            Title = title;
            ProductTypeId = productTypeId;
            IsActive = isActive;
            H1 = h1;
            Url = url;
            Body = body;
            Description = description;
            Priority = priority;
            ImageUrl = imageUrl;
            ModifiedDate = modifiedDate;
            CreateDate = DateTime.Now;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public int? ProductTypeId { get; set; }
        public ProductType? ProductType { get; set; }
        public bool IsActive { get; set; }
        public string H1 { get; set; }
        public string? Url { get; set; }
        public string? Body { get; set; }
        public string? Description{ get; set; }
        public int? Priority { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}