using Application.CountryApplication.Models;
using AutoMapper;
using Domain;

namespace Application.CountryApplication
{
    internal class CountryMapper : Profile
    {
        public CountryMapper()
        {
            CreateMap<Country, CountryInfo>();
        }
    }
}
