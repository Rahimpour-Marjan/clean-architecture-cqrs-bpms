using Application.CityApplication.Models;
using AutoMapper;
using Domain;

namespace Application.CityApplication
{
    internal class CityMapper : Profile
    {
        public CityMapper()
        {
            CreateMap<City, CityInfo>()
                .ForMember(dto => dto.Country, opt => opt.MapFrom(src => src.State.Country));
        }
    }
}
