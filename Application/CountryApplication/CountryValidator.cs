using FluentValidation;
using Application.CountryApplication.Commands;

namespace Application.CountryApplication
{
    public class CountryValidator : AbstractValidator<CountryCreate.Command>
    {
        public CountryValidator()
        {
            RuleFor(u => u.Title).NotEmpty().WithMessage("Unit should have a Name.");
            RuleFor(u => u.Code).NotEmpty().WithMessage("Unit should have a AbbreviatedTitle.");
        }
    }
}
