using Application.AccountAddressApplication.Models;
using Application.Common;
using MediatR;

namespace Application.AccountAddressApplication.Queries.FindAll
{
    public class FindAllAccountAddressQuery : IRequest<FindAllQueryResponse<IList<AccountAddressInfo>>>
    {
        public string? Query { get; set; }
    }
}
