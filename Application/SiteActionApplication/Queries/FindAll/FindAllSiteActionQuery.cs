using MediatR;
using Application.SiteActionApplication.Models;
using Application.Common;

namespace Application.SiteActionApplication.Queries.FindAll
{
    public class FindAllSiteActionQuery : IRequest<FindAllQueryResponse<IList<SiteActionInfo>>>
    {
        public string? Query { get; set; }
    }
}
