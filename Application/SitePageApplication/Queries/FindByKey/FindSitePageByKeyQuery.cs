using MediatR;
using Application.QuickAccess.Models;
using Application.SitePage.Models;

namespace Application.SitePage.Queries.FindByKey
{
    public class FindSitePageByKeyQuery : IRequest<SitePageInfo>
    {
        public string Key { get; set; }
    }
}
