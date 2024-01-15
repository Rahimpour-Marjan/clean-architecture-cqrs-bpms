
namespace Domain
{
    public class ProductCategory
    {
        protected ProductCategory() { }

        public ProductCategory(string title, int? productCategoryParentId, bool isActive, string? url, string? body, bool? deleted, string? canonical, bool? noFollow, bool? noIndex, int? priority, string? imageUrl, int creatorId)
        {
            Title = title;
            ProductCategoryParentId = productCategoryParentId;
            IsActive = isActive;
            Url = url;
            Body = body;
            Deleted = deleted;
            Canonical = canonical;
            NoFollow = noFollow;
            NoIndex = noIndex;
            Priority = priority;
            ImageUrl = imageUrl;
            CreatorId = creatorId;
            CreateDate = DateTime.Now;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public int? ProductCategoryParentId { get; set; }
        public virtual ProductCategory? ProductCategoryParent { get; set; }
        public bool IsActive { get; set; }
        public string? Url { get; set; }
        public string? Body { get; set; }
        public bool? Deleted { get; set; }
        public string? Canonical { get; set; }
        public bool? NoFollow { get; set; }
        public bool? NoIndex { get; set; }
        public int? Priority { get; set; }
        public string? ImageUrl { get; set; }
        public int CreatorId { get; set; }
        public int? ModifireId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
    }
}