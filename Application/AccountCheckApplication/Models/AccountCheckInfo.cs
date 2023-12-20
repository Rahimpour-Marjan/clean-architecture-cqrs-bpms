
using Application.Account.Models;
using Application.BankApplication.Models;

namespace Application.AccountCheckApplication.Models
{
    public class AccountCheckInfo
    {
        public int Id { get; set; }
        public AccountInfo Account { get; set; }
        public string CheckNumber { get; set; }
        public BankInfo Bank { get; set; }
        public string BranchName { get; set; }
        public double Amount { get; set; }
        public string PayTo { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ReceiptDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string FrontImageUrl { get; set; }
        public string BackImageUrl { get; set; }
        public string? SignatureUrl { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
