using Application.ProductApplication.Commands;
using FluentValidation;

namespace Application.ProductApplication
{
    public class ProductValidator : AbstractValidator<ProductCreate.Command>
    {
        public ProductValidator()
        {
            RuleFor(u => u.Title).NotEmpty().WithMessage("ProductType should have a Title.");
            RuleFor(u => u.H1).NotEmpty().WithMessage("ProductType should have a H1.");
            RuleFor(u => u.IsActive).NotEmpty().WithMessage("ProductType should have a IsActive.");
            RuleFor(u => u.CreatorId).NotEmpty().WithMessage("ProductType should have a CreatorId.");
        }
    }
}
