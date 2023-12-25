using Application.Account.Models;
using MediatR;

namespace Application.Account.Queries.FindById
{
    public class FindAccountByIdQuery : IRequest<AccountInfo>
    {
        public int Id { get; set; }
    }
}
