using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Api.Model.AccountCredit
{
    public class AccountCreditInfoModel
    {

        [Required(ErrorMessage = "ارسال نام کاربر الزامی می باشد")]
        public int AccountId { get; set; }
        public string? Description { get; set; }

        [Required(ErrorMessage = "ارسال مبلغ مورد نیاز الزامی می باشد")]
        public long Amount { get; set; }

        [Required(ErrorMessage = "ارسال اعتبار الزامی می باشد")]
        public long Remain { get; set; }
        public int? AccountCheckId { get; set; }

        [Required(ErrorMessage = "ارسال وضعیت الزامی می باشد")]
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "ارسال نوع تراکنش الزامی می باشد")]
        public CreditType CreditType { get; set; }
    }
}
