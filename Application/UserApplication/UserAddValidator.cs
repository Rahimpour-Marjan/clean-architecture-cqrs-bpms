using Application.Users.Models;
using FluentValidation;

namespace Application.Users
{
    public class UserAddValidator : AbstractValidator<UserInfo>
    {
        public UserAddValidator()
        {
            //RuleFor(u => u.).NotEmpty().WithMessage("User should have a fullName.");
            //RuleFor(u => u.UserName).NotEmpty().WithMessage("User should have a userName.");
            //RuleFor(u => u.Email).NotEmpty().WithMessage("User should have a email.");
        }
    }
}
