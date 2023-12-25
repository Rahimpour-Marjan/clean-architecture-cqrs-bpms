using Application.AccountCheckApplication.Models;
using Application.Common;
using MediatR;

namespace Application.AccountCheckApplication.Queries.FindAll
{
    public class FindAllAccountCheckQuery : IRequest<FindAllQueryResponse<IList<AccountCheckInfo>>>
    {
        public string? Query { get; set; }
    }
}
