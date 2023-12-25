using Application.SiteActionApplication.Models;
using AutoMapper;
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
