
using Application.Account.Models;
using Application.AccountCheckApplication.Models;
using Domain.Enums;

namespace Application.AccountCreditApplication.Models
{
    public class AccountCreditInfo
    {
        public int Id { get; set; }
        public AccountInfo Account { get; set; }
        public string? Description { get; set; }
        public long Amount { get; set; }
        public long Remain { get; set; }
        public AccountCheckInfo? AccountCheck { get; set; }
        public bool IsActive { get; set; }
        public CreditType CreditType { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
