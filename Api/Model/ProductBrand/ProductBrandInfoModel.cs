using System.ComponentModel.DataAnnotations;

namespace Api.Model.ProductBrand
{
    public class ProductBrandInfoModel
    {
        [Required(ErrorMessage = "ارسال عنوان الزامی می باشد")]
        public string Title { get; set; }

        [Required(ErrorMessage = "ارسال نوع محصول الزامی می باشد")]
        public int ProductTypeId { get; set; }

        [Required(ErrorMessage = "ارسال وضعیت الزامی می باشد")]
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "ارسال H1 الزامی می باشد")]
        public string H1 { get; set; }
        public string? Url { get; set; }
        public string? Body { get; set; }
        public string? Description { get; set; }
        public int? Priority { get; set; }
        public string? ImageUrl { get; set; }
    }
}
