using FluentValidation;
using Application.SiteActionApplication.Commands;

namespace Application.SiteActionApplication
{
    public class SiteActionValidator : AbstractValidator<SiteActionCreate.Command>
    {
        public SiteActionValidator()
        {
            RuleFor(u => u.Controller).NotEmpty().WithMessage("SiteAction should have a Controller.");
            RuleFor(u => u.Action).NotEmpty().WithMessage("SiteAction should have a Action.");
            RuleFor(u => u.SitePageId).NotEmpty().WithMessage("SiteAction should have a SitePageId.");
        }
    }
}
