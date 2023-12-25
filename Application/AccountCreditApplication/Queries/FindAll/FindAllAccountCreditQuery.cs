using Application.AccountCreditApplication.Models;
using Application.Common;
using MediatR;

namespace Application.AccountCreditApplication.Queries.FindAll
{
    public class FindAllAccountCreditQuery : IRequest<FindAllQueryResponse<IList<AccountCreditInfo>>>
    {
        public string? Query { get; set; }
    }
}
