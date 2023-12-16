using MediatR;
using Application.UnitApplication.Models;
using Application.Common;

namespace Application.UnitApplication.Queries.FindAll
{
    public class FindAllUnitQuery : IRequest<FindAllQueryResponse<IList<UnitInfo>>>
    {
        public string? Query { get; set; }
    }
}
