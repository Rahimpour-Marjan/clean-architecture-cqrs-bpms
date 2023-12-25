using Application.Common;
using Application.ZoneApplication.Models;
using MediatR;

namespace Application.ZoneApplication.Queries.FindAll
{
    public class FindAllZoneQuery : IRequest<FindAllQueryResponse<IList<ZoneInfo>>>
    {
        public string? Query { get; set; }
    }
}
