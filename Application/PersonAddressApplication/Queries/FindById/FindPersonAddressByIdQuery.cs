using MediatR;
using Application.PersonAddressApplication.Models;

namespace Application.PersonAddressApplication.Queries.FindById
{
    public class FindPersonAddressByIdQuery : IRequest<PersonAddressInfo>
    {
        public int Id { get; set; }
    }
}
