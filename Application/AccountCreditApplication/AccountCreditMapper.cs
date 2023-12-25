using Application.AccountCreditApplication.Models;
using AutoMapper;
using Domain;

namespace Application.AccountCreditApplication
{
    internal class AccountCreditMapper : Profile
    {
        public AccountCreditMapper()
        {
            CreateMap<AccountCredit, AccountCreditInfo>();
        }
    }
}
