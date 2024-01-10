
namespace Domain
{
    public class ProductType
    {
        protected ProductType() { }

        public ProductType(string title, int? productTypeParentId, bool isActive, string h1, string? url, string? body, int? priority ,string? imageUrl, DateTime modifiedDate)
        {
            Title = title;
            ProductTypeParentId = productTypeParentId;
            IsActive = isActive;
            H1 = h1;
            Url = url;
            Body = body;
            Priority = priority;
            ImageUrl = imageUrl;
            ModifiedDate = modifiedDate;
            CreateDate = DateTime.Now;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public int? ProductTypeParentId { get; set; }
        public ProductType? ProductTypeParent { get; set; }
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