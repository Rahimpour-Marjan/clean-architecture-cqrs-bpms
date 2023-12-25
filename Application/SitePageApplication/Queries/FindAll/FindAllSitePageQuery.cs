using Application.Common;
using Application.SitePage.Models;
using MediatR;

namespace Application.SitePage.Queries.FindAll
{
    public class FindAllSitePageQuery : IRequest<FindAllQueryResponse<IList<SitePageInfo>>>
    {
        public string? Query { get; set; }
    }
}
