using Application.CategoryApplication.Commands;
using FluentValidation;

namespace Application.CategoryApplication
{
    public class CategoryValidator : AbstractValidator<CategoryCreate.Command>
    {
        public CategoryValidator()
        {
            RuleFor(u => u.Title).NotEmpty().WithMessage("Category should have a Title.");
            RuleFor(u => u.Type).NotEmpty().WithMessage("Category should have a Type.");
            RuleFor(u => u.IsActive).NotEmpty().WithMessage("Category should have a IsActive.");
            RuleFor(u => u.CreatorId).NotEmpty().WithMessage("Category should have a CreatorId.");
        }
    }
}
