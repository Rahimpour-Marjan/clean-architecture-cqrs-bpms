using MediatR;
using Application.ZoneApplication.Models;
using Application.Common;

namespace Application.ZoneApplication.Queries.FindAll
{
    public class FindAllZoneQuery : IRequest<FindAllQueryResponse<IList<ZoneInfo>>>
    {
        public string? Query { get; set; }
    }
}
