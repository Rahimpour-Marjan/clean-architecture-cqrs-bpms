using Application.EducationLevelApplication.Commands;
using FluentValidation;

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
