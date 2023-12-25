using Application.SitePage.Models;
using MediatR;

namespace Application.SitePage.Queries.FindById
{
    public class FindSitePageByIdQuery : IRequest<SitePageInfo>
    {
        public long Id { get; set; }
    }
}
