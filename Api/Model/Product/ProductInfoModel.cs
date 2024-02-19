using System.ComponentModel.DataAnnotations;

namespace Api.Model.Product
{
    public class ProductInfoModel
    {
        [Required(ErrorMessage = "ارسال عنوان محصول الزامی می باشد")]
        public string Title { get; set; }

        [Required(ErrorMessage = "ارسال نوع محصول الزامی می باشد")]
        public int ProductTypeId { get; set; }

        [Required(ErrorMessage = "ارسال دسته بندی محصول الزامی می باشد")]
        public int ProductCategoryId { get; set; }
        public int? ProductBrandId { get; set; }
        public string? H1 { get; set; }
        public string? Url { get; set; }
        public string? CodeValue { get; set; }

        [Required(ErrorMessage = "ارسال خلاصه محصول الزامی می باشد")]
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
        public bool? ShowHomePage { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public int? SellCount { get; set; }
        public int? MaxOrderCount { get; set; }
        public long? DiscountValue { get; set; }
        public int? DiscountPercent { get; set; }
        public DateTime? DiscountExpireDate { get; set; }
        public string? MetaTagDescription { get; set; }
        public string? Canonical { get; set; }
        public bool? NoFollow { get; set; }
        public bool? NoIndex { get; set; }
        public string? Keywords { get; set; }
        public bool? IsService { get; set; }
        public bool? IsCopy { get; set; }
        public bool? IsPublic { get; set; }
        public bool? IsSpecial { get; set; }
        public bool? PayLater { get; set; }
        public bool? IsExport { get; set; }

        [Required(ErrorMessage = "ارسال وضعیت محصول الزامی می باشد")]
        public bool IsActive { get; set; }
        public string? VideoDemoFileUrl { get; set; }
        public string? ImageUrl { get; set; }
        public int? CreatorStoreId { get; set; }
    }
}
