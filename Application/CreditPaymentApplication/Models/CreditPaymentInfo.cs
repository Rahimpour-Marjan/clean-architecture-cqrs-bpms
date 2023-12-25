
using Application.Account.Models;
using Application.CurrencyTypeApplication.Models;
using Domain.Enums;

namespace Application.CreditPaymentApplication.Models
{
    public class CreditPaymentInfo
    {
        public int Id { get; set; }
        public AccountInfo Account { get; set; }
        //public AccountCreditInfo AccountCredit { get; set; }
        public PaymentStatus Status { get; set; }
        public string? RefNumber { get; set; }
        public string? ExternalInfo1 { get; set; }
        public string? ExternalInfo2 { get; set; }
        public long Amount { get; set; }
        public string IpAddress { get; set; }
        public string? Description { get; set; }
        public CurrencyTypeInfo CurrencyType { get; set; }
        public bool IsInPlace { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
