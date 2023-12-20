using Application.ZoneApplication.Models;
using AutoMapper;
using Domain;

namespace Application.ZoneApplication
{
    internal class ZoneMapper : Profile
    {
        public ZoneMapper()
        {
            CreateMap<Zone, ZoneInfo>()
                 .ForMember(dto => dto.Country, opt => opt.MapFrom(src => src.City.State.Country))
                 .ForMember(dto => dto.State, opt => opt.MapFrom(src => src.City.State));
        }
    }
}
