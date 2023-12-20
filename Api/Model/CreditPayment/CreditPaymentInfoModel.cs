using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Api.Model.CreditPayment
{
    public class CreditPaymentInfoModel
    {

        [Required(ErrorMessage = "ارسال نام کاربر الزامی می باشد")]
        public int AccountId { get; set; }

        [Required(ErrorMessage = "ارسال کد اعتبار کاربر الزامی می باشد")]
        public int AccountCreditId { get; set; }

        [Required(ErrorMessage = "ارسال وضعیت الزامی می باشد")]
        public PaymentStatus Status { get; set; }
        public string? RefNumber { get; set; }
        public string? ExternalInfo1 { get; set; }
        public string? ExternalInfo2 { get; set; }

        [Required(ErrorMessage = "ارسال مبلغ تراکنش الزامی می باشد")]
        public long Amount { get; set; }

        [Required(ErrorMessage = "ارسال آیپی آدرس کاربر الزامی می باشد")]
        public string IpAddress { get; set; }
        public string? Description { get; set; }

        [Required(ErrorMessage = "ارسال واحد پول الزامی می باشد")]
        public int CurrencyTypeId { get; set; }

        [Required(ErrorMessage = "ارسال نوع پرداخت الزامی می باشد")]
        public bool IsInPlace { get; set; }
        public string? ImageUrl { get; set; }
    }
}
