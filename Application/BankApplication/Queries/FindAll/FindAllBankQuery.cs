using Application.BankApplication.Models;
using Application.Common;
using MediatR;

namespace Application.BankApplication.Queries.FindAll
{
    public class FindAllBankQuery : IRequest<FindAllQueryResponse<IList<BankInfo>>>
    {
        public string? Query { get; set; }
    }
}
