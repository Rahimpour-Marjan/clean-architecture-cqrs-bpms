using AutoMapper;
using Application.SiteActionApplication.Models;
using Domain;

namespace Application.SiteActionApplication
{
    internal class SiteActionMapper : Profile
    {
        public SiteActionMapper()
        {
            CreateMap<SiteAction, SiteActionInfo>();
        }
    }
}
