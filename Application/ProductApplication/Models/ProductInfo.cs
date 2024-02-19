using Application.ProductBrandApplication.Models;
using Application.ProductCategoryApplication.Models;
using Application.ProductTypeApplication.Models;
using Application.StateApplication.Models;

namespace Application.ProductApplication.Models
{
    public class ProductInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ProductTypeInfo ProductType { get; set; }
        public ProductCategoryInfo ProductCategory { get; set; }
        public ProductBrandInfo? ProductBrand { get; set; }
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
        public int DiscountPercent { get; set; }
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
        public StateInfo CreatorStore { get; set; }
        public int CreatorId { get; set; }
        public int? ModifireId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
