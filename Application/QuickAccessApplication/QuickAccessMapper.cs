using AutoMapper;
using Application.QuickAccess.Models;

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