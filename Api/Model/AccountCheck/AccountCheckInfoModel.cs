using System.ComponentModel.DataAnnotations;

namespace Api.Model.AccountCheck
{
    public class AccountCheckInfoModel
    {

        [Required(ErrorMessage = "ارسال نام کاربر الزامی می باشد")]
        public int AccountId { get; set; }

        [Required(ErrorMessage = "ارسال شماره چک الزامی می باشد")]
        public string CheckNumber { get; set; }

        [Required(ErrorMessage = "ارسال بانک الزامی می باشد")]
        public int BankId { get; set; }

        [Required(ErrorMessage = "ارسال نام شعبه الزامی می باشد")]
        public string BranchName { get; set; }

        [Required(ErrorMessage = "ارسال مبلغ چک الزامی می باشد")]
        public long Amount { get; set; }

        [Required(ErrorMessage = "ارسال در وجه الزامی می باشد")]
        public string PayTo { get; set; }

        [Required(ErrorMessage = "ارسال تاریخ صدور الزامی می باشد")]
        public DateTime IssueDate { get; set; }

        [Required(ErrorMessage = "ارسال تاریخ وصول الزامی می باشد")]
        public DateTime ReceiptDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        [Required(ErrorMessage = "ارسال تصویر روی چک الزامی می باشد")]
        public string FrontImageUrl { get; set; }

        [Required(ErrorMessage = "ارسال تصویر پشت چک الزامی می باشد")]
        public string BackImageUrl { get; set; }
        public string? SignatureUrl { get; set; }
    }
}
