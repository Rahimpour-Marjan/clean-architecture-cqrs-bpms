using Application.AccountAddressApplication.Models;
using MediatR;

namespace Application.AccountAddressApplication.Queries.FindById
{
    public class FindAccountAddressByIdQuery : IRequest<AccountAddressInfo>
    {
        public int Id { get; set; }
    }
}
