using Application.CreditPaymentApplication.Commands;
using FluentValidation;

namespace Application.CreditPaymentApplication
{
    public class CreditPaymentValidator : AbstractValidator<CreditPaymentCreate.Command>
    {
        public CreditPaymentValidator()
        {
            RuleFor(u => u.AccountId).NotEmpty().WithMessage("CreditPayment should have a AccountId.");
            RuleFor(u => u.AccountCreditId).NotEmpty().WithMessage("CreditPayment should have a AccountCreditId.");
            RuleFor(u => u.Status).NotEmpty().WithMessage("CreditPayment should have a Status.");
            RuleFor(u => u.Amount).NotEmpty().WithMessage("CreditPayment should have a Amount.");
            RuleFor(u => u.IpAddress).NotEmpty().WithMessage("CreditPayment should have a IpAddress.");
            RuleFor(u => u.CurrencyTypeId).NotEmpty().WithMessage("CreditPayment should have a CurrencyTypeId.");
            RuleFor(u => u.IsInPlace).NotEmpty().WithMessage("CreditPayment should have a IsInPlace.");
            RuleFor(u => u.CreatorId).NotEmpty().WithMessage("CreditPayment should have a CreatorId.");
        }
    }
}
