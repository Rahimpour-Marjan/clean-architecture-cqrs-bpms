using FluentValidation;
using Application.StateApplication.Commands;

namespace Application.StateApplication
{
    public class StateValidator : AbstractValidator<StateCreate.Command>
    {
        public StateValidator()
        {
            RuleFor(u => u.Title).NotEmpty().WithMessage("State should have a Title.");
            RuleFor(u => u.CountryId).NotEmpty().WithMessage("State should have a CountryId.");
            RuleFor(u => u.Code).NotEmpty().WithMessage("State should have a Code.");
        }
    }
}
