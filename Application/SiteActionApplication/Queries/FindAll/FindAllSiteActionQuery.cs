using Application.Common;
using Application.SiteActionApplication.Models;
using MediatR;

namespace Application.SiteActionApplication.Queries.FindAll
{
    public class FindAllSiteActionQuery : IRequest<FindAllQueryResponse<IList<SiteActionInfo>>>
    {
        public string? Query { get; set; }
    }
}
