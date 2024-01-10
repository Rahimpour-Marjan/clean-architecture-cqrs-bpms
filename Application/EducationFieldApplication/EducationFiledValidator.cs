using Application.EducationFieldApplication.Commands;
using FluentValidation;

namespace Application.EducationFiledApplication
{
    public class EducationFiledValidator : AbstractValidator<EducationFieldCreate.Command>
    {
        public EducationFiledValidator()
        {
            RuleFor(u => u.Title).NotEmpty().WithMessage("EducationFiled should have a Title.");
            RuleFor(u => u.CreatorId).NotEmpty().WithMessage("EducationFiled should have a CreatorId.");
        }
    }
}
