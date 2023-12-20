using FluentValidation;
using Application.CurrencyTypeApplication.Commands;

namespace Application.CurrencyTypeApplication
{
    public class CurrencyTypeValidator : AbstractValidator<CurrencyTypeCreate.Command>
    {
        public CurrencyTypeValidator()
        {
            RuleFor(u => u.Title).NotEmpty().WithMessage("CurrencyType should have a Title.");
            RuleFor(u => u.CurrencySign).NotEmpty().WithMessage("CurrencyType should have a CurrencySign.");
            RuleFor(u => u.UnitPrice).NotEmpty().WithMessage("CurrencyType should have a UnitPrice.");
        }
    }
}
