using Application.BankApplication.Commands;
using FluentValidation;

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
