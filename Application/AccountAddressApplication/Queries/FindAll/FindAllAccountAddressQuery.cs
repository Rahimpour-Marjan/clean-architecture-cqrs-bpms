using MediatR;
using Application.AccountAddressApplication.Models;
using Application.Common;

namespace Application.AccountAddressApplication.Queries.FindAll
{
    public class FindAllAccountAddressQuery : IRequest<FindAllQueryResponse<IList<AccountAddressInfo>>>
    {
        public string? Query { get; set; }
    }
}
