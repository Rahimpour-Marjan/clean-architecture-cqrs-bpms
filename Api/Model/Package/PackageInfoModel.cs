using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Api.Model.Package
{
    public class PackageInfoModel
    {
        [Required(ErrorMessage = "ارسال نام الزامی می باشد")]
        public string Title { get; set; }

        [Required(ErrorMessage = "ارسال نوع پکیج الزامی می باشد")]
        public PackageType Type { get; set; }

        [Required(ErrorMessage = "ارسال کد الزامی می باشد")]
        public string Code { get; set; }

        [Required(ErrorMessage = "ارسال وضعیت الزامی می باشد")]
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "ارسال قیمت الزامی می باشد")]
        public long Price { get; set; }
        public long? Discount { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? ExpireDate { get; set; }
    }
}
