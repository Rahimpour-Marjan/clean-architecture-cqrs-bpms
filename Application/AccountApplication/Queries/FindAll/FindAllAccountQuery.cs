using MediatR;
using Application.Account.Models;
using Application.Common;

namespace Application.Account.Queries.FindAll
{
    public class FindAllAccountQuery:IRequest<FindAllQueryResponse<IList<AccountView>>>
    {
        public string? Query { get; set; }
    }
}
