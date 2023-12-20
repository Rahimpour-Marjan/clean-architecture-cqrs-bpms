using Application.BankApplication.Models;
using AutoMapper;
using Domain;

namespace Application.BankApplication
{
    internal class BankMapper : Profile
    {
        public BankMapper()
        {
            CreateMap<Bank, BankInfo>();
        }
    }
}
