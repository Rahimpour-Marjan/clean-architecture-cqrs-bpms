using FluentValidation;
using Application.CityApplication.Commands;

namespace Application.CityApplication
{
    public class CityValidator : AbstractValidator<CityCreate.Command>
    {
        public CityValidator()
        {
            RuleFor(u => u.Title).NotEmpty().WithMessage("State should have a Title.");
            RuleFor(u => u.StateId).NotEmpty().WithMessage("State should have a StateId.");
            RuleFor(u => u.Code).NotEmpty().WithMessage("State should have a Code.");
        }
    }
}
