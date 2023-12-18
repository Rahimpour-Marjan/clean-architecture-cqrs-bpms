using MediatR;
using Application.PersonAddressApplication.Models;
using Application.Common;

namespace Application.PersonAddressApplication.Queries.FindAll
{
    public class FindAllPersonAddressQuery : IRequest<FindAllQueryResponse<IList<PersonAddressInfo>>>
    {
        public string? Query { get; set; }
    }
}
