using Application.AccountCreditApplication.Commands;
using FluentValidation;

namespace Application.AccountCreditApplication
{
    public class AccountCreditValidator : AbstractValidator<AccountCreditCreate.Command>
    {
        public AccountCreditValidator()
        {
            RuleFor(u => u.AccountId).NotEmpty().WithMessage("AccountCredit should have a AccountId.");
            RuleFor(u => u.Amount).NotEmpty().WithMessage("AccountCredit should have a Amount.");
            RuleFor(u => u.Remain).NotEmpty().WithMessage("AccountCredit should have a Remain.");
            RuleFor(u => u.IsActive).NotEmpty().WithMessage("AccountCredit should have a IsActive.");
            RuleFor(u => u.CreditType).NotEmpty().WithMessage("AccountCredit should have a CreditType.");
            RuleFor(u => u.CreatorId).NotEmpty().WithMessage("AccountCredit should have a CreatorId.");
        }
    }
}
