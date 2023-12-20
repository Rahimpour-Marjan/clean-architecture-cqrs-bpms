using FluentValidation;
using Application.BankApplication.Commands;

namespace Application.BankApplication
{
    public class BankValidator : AbstractValidator<BankCreate.Command>
    {
        public BankValidator()
        {
            RuleFor(u => u.Title).NotEmpty().WithMessage("Bank should have a Title.");
            RuleFor(u => u.IsActive).NotEmpty().WithMessage("Bank should have a IsActive.");
        }
    }
}
