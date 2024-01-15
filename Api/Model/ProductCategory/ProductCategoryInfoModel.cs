using System.ComponentModel.DataAnnotations;

namespace Api.Model.ProductCategory
{
    public class ProductCategoryInfoModel
    {
        [Required(ErrorMessage = "ارسال عنوان الزامی می باشد")]
        public string Title { get; set; }
        public int? ProductCategoryParentId { get; set; }

        [Required(ErrorMessage = "ارسال وضعیت الزامی می باشد")]
        public bool IsActive { get; set; }
        public string? Url { get; set; }
        public string? Body { get; set; }
        public bool? Deleted { get; set; }
        public string? Canonical { get; set; }
        public bool? NoFollow { get; set; }
        public bool? NoIndex { get; set; }
        public int? Priority { get; set; }
        public string? ImageUrl { get; set; }
    }
}
