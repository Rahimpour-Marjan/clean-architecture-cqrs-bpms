using FluentValidation;
using Application.PersonAddressApplication.Commands;

namespace Application.PersonAddressApplication
{
    public class PersonAddressValidator : AbstractValidator<PersonAddressCreate.Command>
    {
        public PersonAddressValidator()
        {
            RuleFor(u => u.PersonId).NotEmpty().WithMessage("PersonAddress should have a PersonId.");
            RuleFor(u => u.Title).NotEmpty().WithMessage("PersonAddress should have a Title.");
            RuleFor(u => u.FullName).NotEmpty().WithMessage("PersonAddress should have a FullName.");
            RuleFor(u => u.Phone).NotEmpty().WithMessage("PersonAddress should have a Phone.");
            RuleFor(u => u.CountryId).NotEmpty().WithMessage("PersonAddress should have a CountryId.");
            RuleFor(u => u.StateId).NotEmpty().WithMessage("PersonAddress should have a StateId.");
            RuleFor(u => u.CityId).NotEmpty().WithMessage("PersonAddress should have a CityId.");
            RuleFor(u => u.Address).NotEmpty().WithMessage("PersonAddress should have a Address.");
            RuleFor(u => u.PostalCode).NotEmpty().WithMessage("PersonAddress should have a PostalCode.");
        }
    }
}
