using Application.AccountAddressApplication.Commands;
using FluentValidation;

namespace Application.AccountAddressApplication
{
    public class AccountAddressValidator : AbstractValidator<AccountAddressCreate.Command>
    {
        public AccountAddressValidator()
        {
            RuleFor(u => u.AccountId).NotEmpty().WithMessage("AccountAddress should have a AccountId.");
            RuleFor(u => u.Title).NotEmpty().WithMessage("AccountAddress should have a Title.");
            RuleFor(u => u.FullName).NotEmpty().WithMessage("AccountAddress should have a FullName.");
            RuleFor(u => u.Phone).NotEmpty().WithMessage("AccountAddress should have a Phone.");
            RuleFor(u => u.CountryId).NotEmpty().WithMessage("AccountAddress should have a CountryId.");
            RuleFor(u => u.StateId).NotEmpty().WithMessage("AccountAddress should have a StateId.");
            RuleFor(u => u.CityId).NotEmpty().WithMessage("AccountAddress should have a CityId.");
            RuleFor(u => u.Address).NotEmpty().WithMessage("AccountAddress should have a Address.");
            RuleFor(u => u.PostalCode).NotEmpty().WithMessage("AccountAddress should have a PostalCode.");
        }
    }
}
