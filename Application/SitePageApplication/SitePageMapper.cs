using AutoMapper;

namespace Application.SitePage.Models
{
    internal class SitePageMapper : Profile
    {
        public SitePageMapper()
        {
            CreateMap<Domain.SitePage, SitePageInfo>();
        }
    }
}
