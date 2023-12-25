using Application.QuickAccess.Models;
using AutoMapper;

namespace Application.QuickAccess
{
    internal class QuickAccessMapper : Profile
    {
        public QuickAccessMapper()
        {
            CreateMap<Domain.QuickAccess, QuickAccessInfo>();
        }
    }
}