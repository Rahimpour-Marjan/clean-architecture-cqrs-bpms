using Application.PackageApplication.Commands;
using FluentValidation;

namespace Application.PackageApplication
{
    public class PackageValidator : AbstractValidator<PackageCreate.Command>
    {
        public PackageValidator()
        {
            RuleFor(u => u.Title).NotEmpty().WithMessage("Package should have a Title.");
            RuleFor(u => u.Type).NotEmpty().WithMessage("Package should have a Type.");
            RuleFor(u => u.Code).NotEmpty().WithMessage("Package should have a Code.");
            RuleFor(u => u.IsActive).NotEmpty().WithMessage("Package should have a IsActive.");
            RuleFor(u => u.Price).NotEmpty().WithMessage("Package should have a Price.");
            RuleFor(u => u.CreatorId).NotEmpty().WithMessage("Package should have a CreatorId.");
        }
    }
}
