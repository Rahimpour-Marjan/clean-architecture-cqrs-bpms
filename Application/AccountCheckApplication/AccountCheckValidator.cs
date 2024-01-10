using Application.AccountCheckApplication.Commands;
using FluentValidation;

namespace Application.AccountCheckApplication
{
    public class AccountCheckValidator : AbstractValidator<AccountCheckCreate.Command>
    {
        public AccountCheckValidator()
        {
            RuleFor(u => u.AccountId).NotEmpty().WithMessage("AccountCheck should have a AccountId.");
            RuleFor(u => u.CheckNumber).NotEmpty().WithMessage("AccountCheck should have a CheckNumber.");
            RuleFor(u => u.BankId).NotEmpty().WithMessage("AccountCheck should have a BankId.");
            RuleFor(u => u.BranchName).NotEmpty().WithMessage("AccountCheck should have a BranchName.");
            RuleFor(u => u.Amount).NotEmpty().WithMessage("AccountCheck should have a Amount.");
            RuleFor(u => u.PayTo).NotEmpty().WithMessage("AccountCheck should have a PayTo.");
            RuleFor(u => u.IssueDate).NotEmpty().WithMessage("AccountCheck should have a IssueDate.");
            RuleFor(u => u.ReceiptDate).NotEmpty().WithMessage("AccountCheck should have a ReceiptDate.");
            RuleFor(u => u.FrontImageUrl).NotEmpty().WithMessage("AccountCheck should have a FrontImageUrl.");
            RuleFor(u => u.BackImageUrl).NotEmpty().WithMessage("AccountCheck should have a BackImageUrl.");
            RuleFor(u => u.CreatorId).NotEmpty().WithMessage("AccountCheck should have a CreatorId.");
        }
    }
}
