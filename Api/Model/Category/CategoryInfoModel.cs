using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Api.Model.Category
{
    public class CategoryInfoModel
    {
        [Required(ErrorMessage = "ارسال عنوان الزامی می باشد")]
        public string Title { get; set; }
        public int? CategoryParentId { get; set; }

        [Required(ErrorMessage = "ارسال نوع دسته بندی الزامی می باشد")]
        public CategoryType Type { get; set; }

        [Required(ErrorMessage = "ارسال وضعیت الزامی می باشد")]
        public bool IsActive { get; set; }
        public string? Url { get; set; }
        public string? Body { get; set; }
        public string? ImageUrl { get; set; }
    }
}
