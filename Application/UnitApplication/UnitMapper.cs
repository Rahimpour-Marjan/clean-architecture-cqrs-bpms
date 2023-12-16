using AutoMapper;
using Application.UnitApplication.Models;
using Domain;

namespace Application.UnitApplication
{
    internal class UnitMapper : Profile
    {
        public UnitMapper()
        {
            CreateMap<Unit, UnitInfo>();
        }
    }
}
