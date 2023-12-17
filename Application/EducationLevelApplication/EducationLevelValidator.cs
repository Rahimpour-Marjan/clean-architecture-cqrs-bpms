using FluentValidation;
using Application.EducationLevelApplication.Commands;

namespace Application.EducationLevelApplication
{
    public class EducationLevelValidator : AbstractValidator<EducationLevelCreate.Command>
    {
        public EducationLevelValidator()
        {
            RuleFor(u => u.Title).NotEmpty().WithMessage("EducationLevel should have a Title.");
        }
    }
}
