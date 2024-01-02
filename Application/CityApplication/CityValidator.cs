using Application.CityApplication.Commands;
using FluentValidation;

namespace Application.CityApplication
{
    public class CityValidator : AbstractValidator<CityCreate.Command>
    {
        public CityValidator()
        {
            RuleFor(u => u.Title).NotEmpty().WithMessage("City should have a Title.");
            RuleFor(u => u.StateId).NotEmpty().WithMessage("City should have a StateId.");
            RuleFor(u => u.Code).NotEmpty().WithMessage("City should have a Code.");
            RuleFor(u => u.CreatorId).NotEmpty().WithMessage("City should have a CreatorId.");
        }
    }
}
