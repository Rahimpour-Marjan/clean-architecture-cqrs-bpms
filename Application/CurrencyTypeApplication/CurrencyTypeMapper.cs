using Application.CurrencyTypeApplication.Models;
using AutoMapper;
using Domain;

namespace Application.CurrencyTypeApplication
{
    internal class CurrencyTypeMapper : Profile
    {
        public CurrencyTypeMapper()
        {
            CreateMap<CurrencyType, CurrencyTypeInfo>();
        }
    }
}
