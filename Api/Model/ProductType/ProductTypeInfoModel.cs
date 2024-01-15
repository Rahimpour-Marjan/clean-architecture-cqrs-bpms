using System.ComponentModel.DataAnnotations;

namespace Api.Model.ProductType
{
    public class ProductTypeInfoModel
    {
        [Required(ErrorMessage = "ارسال عنوان الزامی می باشد")]
        public string Title { get; set; }
        public int? ProductTypeParentId { get; set; }

        [Required(ErrorMessage = "ارسال وضعیت الزامی می باشد")]
        public bool IsActive { get; set; }
        public string H1 { get; set; }
        public string? Url { get; set; }
        public string? Body { get; set; }
        public int? Priority { get; set; }
        public string? ImageUrl { get; set; }
    }
}
