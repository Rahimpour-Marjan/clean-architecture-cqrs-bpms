using Application.AccountCheckApplication.Models;
using AutoMapper;
using Domain;

namespace Application.AccountCheckApplication
{
    internal class AccountCheckMapper : Profile
    {
        public AccountCheckMapper()
        {
            CreateMap<AccountCheck, AccountCheckInfo>();
        }
    }
}
