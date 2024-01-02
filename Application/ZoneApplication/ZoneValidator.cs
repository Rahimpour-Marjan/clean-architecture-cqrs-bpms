using Application.ZoneApplication.Commands;
using FluentValidation;

namespace Application.ZoneApplication
{
    public class ZoneValidator : AbstractValidator<ZoneCreate.Command>
    {
        public ZoneValidator()
        {
            RuleFor(u => u.Title).NotEmpty().WithMessage("Zone should have a Title.");
            RuleFor(u => u.CityId).NotEmpty().WithMessage("Zone should have a CityId.");
            RuleFor(u => u.Code).NotEmpty().WithMessage("Zone should have a Code.");
            RuleFor(u => u.CreatorId).NotEmpty().WithMessage("Zone should have a CreatorId.");
        }
    }
}
