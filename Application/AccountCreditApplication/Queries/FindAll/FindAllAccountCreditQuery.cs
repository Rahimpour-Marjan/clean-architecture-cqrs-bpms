using MediatR;
using Application.AccountCreditApplication.Models;
using Application.Common;

namespace Application.AccountCreditApplication.Queries.FindAll
{
    public class FindAllAccountCreditQuery : IRequest<FindAllQueryResponse<IList<AccountCreditInfo>>>
    {
        public string? Query { get; set; }
    }
}
