using Domain.Enums;

namespace Domain
{
    public class CreditPayment
    {
        protected CreditPayment() { }

        public CreditPayment(int accountId, int accountCreditId, PaymentStatus status, string? refNumber, string? externalInfo1, string? externalInfo2, long amount,string ipAddress, string? description,int currencyTypeId, bool isInPlace, string? imageUrl, DateTime modifiedDate)
        {
            AccountId = accountId;
            AccountCreditId = accountCreditId;
            Status = status;
            RefNumber = refNumber;
            ExternalInfo1 = externalInfo1;
            ExternalInfo2 = externalInfo2;
            Amount = amount;
            IpAddress = ipAddress;
            Description = description;
            CurrencyTypeId = currencyTypeId;
            IsInPlace = isInPlace;
            ImageUrl = imageUrl;
            ModifiedDate = modifiedDate;
            CreateDate = DateTime.Now;
        }
        public int Id { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public int AccountCreditId { get; set; }
        public AccountCredit AccountCredit { get; set; }
        public PaymentStatus Status { get; set; }
        public string? RefNumber { get; set; }
        public string? ExternalInfo1 { get; set; }
        public string? ExternalInfo2 { get; set; }
        public long Amount { get; set; }
        public string IpAddress { get; set; }
        public string? Description { get; set; }
        public int CurrencyTypeId { get; set; }
        public CurrencyType CurrencyType { get; set; }
        public bool IsInPlace { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}