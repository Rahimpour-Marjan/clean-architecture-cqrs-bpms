using Application.ArticleApplication.Commands;
using FluentValidation;

namespace Application.ArticleApplication
{
    public class ArticleValidator : AbstractValidator<ArticleCreate.Command>
    {
        public ArticleValidator()
        {
            RuleFor(u => u.Title).NotEmpty().WithMessage("Article should have a Title.");
            RuleFor(u => u.CategoryId).NotEmpty().WithMessage("Article should have a CategoryId.");
            RuleFor(u => u.Summary).NotEmpty().WithMessage("Article should have a Summary.");
            RuleFor(u => u.Body).NotEmpty().WithMessage("Article should have a Body.");
            RuleFor(u => u.Active).NotEmpty().WithMessage("Article should have a Active.");
            RuleFor(u => u.CreatorId).NotEmpty().WithMessage("Article should have a CreatorId.");
        }
    }
}
