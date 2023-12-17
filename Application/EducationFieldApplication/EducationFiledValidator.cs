using FluentValidation;
using Application.EducationFieldApplication.Commands;

namespace Application.EducationFiledApplication
{
    public class EducationFiledValidator : AbstractValidator<EducationFieldCreate.Command>
    {
        public EducationFiledValidator()
        {
            RuleFor(u => u.Title).NotEmpty().WithMessage("EducationFiled should have a Title.");
        }
    }
}
