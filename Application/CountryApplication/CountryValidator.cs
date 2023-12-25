using FluentValidation;
using Application.CountryApplication.Commands;

namespace Application.CountryApplication
{
    public class CountryValidator : AbstractValidator<CountryCreate.Command>
    {
        public CountryValidator()
        {
            RuleFor(u => u.Title).NotEmpty().WithMessage("Country should have a Title.");
            RuleFor(u => u.Code).NotEmpty().WithMessage("Country should have a Code.");
        }
    }
}
