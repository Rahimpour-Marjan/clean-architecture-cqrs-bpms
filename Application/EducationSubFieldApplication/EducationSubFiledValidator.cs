using Application.EducationSubFieldApplication.Commands;
using FluentValidation;

namespace Application.EducationSubFiledApplication
{
    public class EducationSubFiledValidator : AbstractValidator<EducationSubFieldCreate.Command>
    {
        public EducationSubFiledValidator()
        {
            RuleFor(u => u.Title).NotEmpty().WithMessage("EducationSubFiled should have a Title.");
            RuleFor(u => u.EducationFieldId).NotEmpty().WithMessage("EducationSubFiled should have a EducationFieldId.");
        }
    }
}
