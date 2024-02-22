using Application.ProductCommentApplication.Commands;
using FluentValidation;

namespace Application.ProductCommentApplication
{
    public class ProductCommentValidator : AbstractValidator<ProductCommentCreate.Command>
    {
        public ProductCommentValidator()
        {
            RuleFor(u => u.Title).NotEmpty().WithMessage("ProductComment should have a Title.");
            RuleFor(u => u.ProductId).NotEmpty().WithMessage("ProductComment should have a ProductId.");
            RuleFor(u => u.Approved).NotEmpty().WithMessage("ProductComment should have a Approved.");
            RuleFor(u => u.NameFamily).NotEmpty().WithMessage("ProductComment should have a NameFamily.");
            RuleFor(u => u.EmailAddress).NotEmpty().WithMessage("ProductComment should have a EmailAddress.");
            RuleFor(u => u.Body).NotEmpty().WithMessage("ProductComment should have a Body.");
            RuleFor(u => u.CreatorId).NotEmpty().WithMessage("ProductComment should have a CreatorId.");
        }
    }
}
