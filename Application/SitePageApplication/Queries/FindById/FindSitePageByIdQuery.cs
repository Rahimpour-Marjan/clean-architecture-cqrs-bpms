using MediatR;
using Application.SitePage.Models;

namespace Application.SitePage.Queries.FindById
{
    public class FindSitePageByIdQuery : IRequest<SitePageInfo>
    {
        public long Id { get; set; }
    }
}
