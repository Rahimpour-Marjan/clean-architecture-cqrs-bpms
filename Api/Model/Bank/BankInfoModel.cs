using System.ComponentModel.DataAnnotations;

namespace Api.Model.Bank
{
    public class BankInfoModel
    {
        [Required(ErrorMessage = "ارسال نام الزامی می باشد")]
        public string Title { get; set; }

        [Required(ErrorMessage = "ارسال وضعیت الزامی می باشد")]
        public bool IsActive { get; set; }
        public string? ImageUrl { get; set; }
    }
}
