using Application.ProductBrandApplication.Commands;
using FluentValidation;

namespace Application.ProductBrandApplication
{
    public class ProductBrandValidator : AbstractValidator<ProductBrandCreate.Command>
    {
        public ProductBrandValidator()
        {
            RuleFor(u => u.Title).NotEmpty().WithMessage("ProductBrand should have a Title.");
            RuleFor(u => u.H1).NotEmpty().WithMessage("ProductBrand should have a H1.");
            RuleFor(u => u.IsActive).NotEmpty().WithMessage("ProductBrand should have a IsActive.");
            RuleFor(u => u.CreatorId).NotEmpty().WithMessage("ProductBrand should have a CreatorId.");
        }
    }
}
