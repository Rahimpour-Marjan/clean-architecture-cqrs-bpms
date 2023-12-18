using MediatR;
using Application.AccountAddressApplication.Models;

namespace Application.AccountAddressApplication.Queries.FindById
{
    public class FindAccountAddressByIdQuery : IRequest<AccountAddressInfo>
    {
        public int Id { get; set; }
    }
}
