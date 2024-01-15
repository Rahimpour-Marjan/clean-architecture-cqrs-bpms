using Application.ProductCategoryApplication.Commands;
using FluentValidation;

namespace Application.ProductCategoryApplication
{
    public class ProductCategoryValidator : AbstractValidator<ProductCategoryCreate.Command>
    {
        public ProductCategoryValidator()
        {
            RuleFor(u => u.Title).NotEmpty().WithMessage("ProductCategory should have a Title.");
            RuleFor(u => u.IsActive).NotEmpty().WithMessage("ProductCategory should have a IsActive.");
            RuleFor(u => u.CreatorId).NotEmpty().WithMessage("ProductCategory should have a CreatorId.");
        }
    }
}
