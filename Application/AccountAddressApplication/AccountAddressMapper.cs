using Application.AccountAddressApplication.Models;
using AutoMapper;
using Domain;

namespace Application.AccountAddressApplication
{
    internal class AccountAddressMapper : Profile
    {
        public AccountAddressMapper()
        {
            CreateMap<AccountAddress, AccountAddressInfo>();
        }
    }
}
