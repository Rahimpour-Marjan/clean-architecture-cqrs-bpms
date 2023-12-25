using Application.SitePage.Models;
using MediatR;

namespace Application.SitePage.Queries.FindByKey
{
    public class FindSitePageByKeyQuery : IRequest<SitePageInfo>
    {
        public string Key { get; set; }
    }
}
