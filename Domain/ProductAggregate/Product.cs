
namespace Domain
{
    public class Product
    {
        protected Product() { }

        public Product(string title, int productTypeId,int productCategoryId,int? productBrandId,  string? h1, string? url, string? codeValue, string summary, string? description, string? body, 
            int? priority , int? maxShowCount, int? quantity, int? minOrder, long? lastPrice, long? price, long? minPrice, long? maxPrice, int? visitCount, bool showHomePage,
            string? latitude, string? longitude, int? sellCount, int? maxOrderCount, long? discountValue, int? discountPercent, DateTime? discountExpireDate, string? metaTagDescription,
            string? canonical, bool noFollow, bool noIndex, string? keywords, bool isService, bool isCopy, bool isPublic, bool isSpecial, bool payLater, bool isExport, bool isActive,
            string? videoDemoFileUrl, string? imageUrl, int? creatorStoreId, int creatorId)
        {
            Title = title;
            ProductTypeId = productTypeId;
            ProductCategoryId = productCategoryId;
            ProductBrandId = productBrandId;
            H1 = h1;
            Url = url;
            CodeValue = codeValue;
            Summary = summary;
            Description = description;
            Body = body;
            Priority = priority;
            MaxShowCount = maxShowCount;
            Quantity = quantity;
            MinOrder = minOrder;
            LastPrice = lastPrice;
            Price = price;
            MinPrice = minPrice;
            MaxPrice= maxPrice;
            VisitCount = visitCount;
            ShowHomePage = showHomePage;
            Latitude = latitude;
            Longitude = longitude;
            SellCount = sellCount;
            MaxOrderCount = maxOrderCount;
            DiscountValue = discountValue;
            DiscountPercent = discountPercent;
            DiscountExpireDate = discountExpireDate;
            MetaTagDescription = metaTagDescription;
            Canonical = canonical;
            NoFollow = noFollow;
            NoIndex = noIndex;
            Keywords = keywords;
            IsService = isService;
            IsCopy = isCopy;
            IsPublic = isPublic;
            IsSpecial = isSpecial;
            PayLater = payLater;
            IsExport = isExport;
            IsActive = isActive;
            VideoDemoFileUrl= videoDemoFileUrl;
            ImageUrl = imageUrl;
            CreatorStoreId= creatorStoreId;
            CreatorId = creatorId;
            CreateDate = DateTime.Now;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public int ProductTypeId { get; set; }
        public virtual ProductType ProductType { get; set; }
        public int ProductCategoryId { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        public int? ProductBrandId { get; set; }
        public virtual ProductBrand? ProductBrand { get; set; }
        public string? H1 { get; set; }
        public string? Url { get; set; }
        public string? CodeValue { get; set; }
        public string Summary { get; set; }
        public string? Description { get; set; }
        public string? Body { get; set; }
        public int? Priority { get; set; }
        public int? MaxShowCount { get; set; }
        public int? Quantity { get; set; }
        public int? MinOrder { get; set; }
        public long? LastPrice { get; set; }
        public long? Price { get; set; }
        public long? MinPrice { get; set; }
        public long? MaxPrice { get; set; }
        public int? VisitCount { get; set; }
        public bool ShowHomePage { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public int? SellCount { get; set; }
        public int? MaxOrderCount { get; set; }
        public long? DiscountValue { get; set; }
        public int? DiscountPercent { get; set; }
        public DateTime? DiscountExpireDate { get; set; }
        public string? MetaTagDescription { get; set; }
        public string? Canonical { get; set; }
        public bool NoFollow { get; set; }
        public bool NoIndex { get; set; }
        public string? Keywords { get; set; }
        public bool IsService { get; set; }
        public bool IsCopy { get; set; }
        public bool IsPublic { get; set; }
        public bool IsSpecial { get; set; }
        public bool PayLater { get; set; }
        public bool IsExport { get; set; }
        public bool IsActive { get; set; }
        public string? VideoDemoFileUrl { get; set; }
        public string? ImageUrl { get; set; }
        public int? CreatorStoreId { get; set; }
        public virtual Store? CreatorStore { get; set; }
        public int CreatorId { get; set; }
        public int? ModifireId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual ICollection<ProductComment> ProductComments { get; set; }
    }
}