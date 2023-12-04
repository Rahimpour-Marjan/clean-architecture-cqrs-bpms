using MediatR;
using Application.SitePage.Models;
using Application.Common;

namespace Application.SitePage.Queries.FindAll
{
    public class FindAllSitePageQuery : IRequest<FindAllQueryResponse<IList<SitePageInfo>>>
    {
        public string? Query { get; set; }
    }
}
