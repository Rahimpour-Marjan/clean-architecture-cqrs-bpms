using Application.UserLogApplication.Commands;
using FluentValidation;

namespace Application.UserLogApplication
{
    public class UserLogValidator : AbstractValidator<UserLogCreate.Command>
    {
        public UserLogValidator()
        {
            RuleFor(u => u.UserId).NotEmpty().WithMessage("Unit should have a UserId.");
            RuleFor(u => u.Type).NotEmpty().WithMessage("Unit should have a Type.");
            RuleFor(u => u.IP).NotEmpty().WithMessage("Unit should have a IP.");
            RuleFor(u => u.Device).NotEmpty().WithMessage("Unit should have a Device.");
        }
    }
}
