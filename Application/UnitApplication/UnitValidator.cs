using Application.UnitApplication.Commands;
using FluentValidation;

namespace Application.UnitApplication
{
    public class UnitValidator : AbstractValidator<UnitCreate.Command>
    {
        public UnitValidator()
        {
            RuleFor(u => u.Title).NotEmpty().WithMessage("Unit should have a Name.");
            RuleFor(u => u.AbbreviatedTitle).NotEmpty().WithMessage("Unit should have a AbbreviatedTitle.");
            RuleFor(u => u.CreatorId).NotEmpty().WithMessage("Unit should have a CreatorId.");
        }
    }
}
