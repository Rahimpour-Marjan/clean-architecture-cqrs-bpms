using Application.ZoneApplication.Models;
using AutoMapper;
using Domain;

namespace Application.ZoneApplication
{
    internal class ZoneMapper : Profile
    {
        public ZoneMapper()
        {
            CreateMap<Zone, ZoneInfo>();
        }
    }
}
