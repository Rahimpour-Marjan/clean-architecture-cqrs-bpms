using MediatR;
using Application.StateApplication.Models;
using Application.Common;

namespace Application.StateApplication.Queries.FindAll
{
    public class FindAllStateQuery : IRequest<FindAllQueryResponse<IList<StateInfo>>>
    {
        public string? Query { get; set; }
    }
}
