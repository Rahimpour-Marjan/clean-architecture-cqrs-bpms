using Application.CityApplication.Models;
using AutoMapper;
using Domain;

namespace Application.CityApplication
{
    internal class CityMapper : Profile
    {
        public CityMapper()
        {
            CreateMap<City, CityInfo>();
        }
    }
}
