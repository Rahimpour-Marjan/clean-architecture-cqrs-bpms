using Application.Common;
using Application.StateApplication.Models;
using MediatR;

namespace Application.StateApplication.Queries.FindAll
{
    public class FindAllStateQuery : IRequest<FindAllQueryResponse<IList<StateInfo>>>
    {
        public string? Query { get; set; }
    }
}
