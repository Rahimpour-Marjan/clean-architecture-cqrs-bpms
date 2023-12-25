using Domain.Enums;

namespace Domain
{
    public class AccountCredit
    {
        protected AccountCredit() { }

        public AccountCredit(int accountId, string? description, long amount, long remain , int? accountCheckId, bool isActive, CreditType creditType, DateTime modifiedDate)
        {
            AccountId = accountId;
            Description = description;
            Amount = amount;
            Remain=remain;
            AccountCheckId = accountCheckId;
            IsActive = isActive;
            CreditType = creditType;
            ModifiedDate = modifiedDate;
            CreateDate = DateTime.Now;
        }
        public int Id { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public string? Description { get; set; }
        public long Amount { get; set; }
        public long Remain { get; set; }
        public int? AccountCheckId { get; set; }
        public AccountCheck? AccountCheck { get; set; }
        public bool IsActive { get; set; }
        public CreditType CreditType { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual ICollection<CreditPayment> CreditPayments { get; set; }
    }
}