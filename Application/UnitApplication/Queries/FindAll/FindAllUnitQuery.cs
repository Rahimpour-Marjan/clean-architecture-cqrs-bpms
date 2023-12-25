using Application.Common;
using Application.UnitApplication.Models;
using MediatR;

namespace Application.UnitApplication.Queries.FindAll
{
    public class FindAllUnitQuery : IRequest<FindAllQueryResponse<IList<UnitInfo>>>
    {
        public string? Query { get; set; }
    }
}
