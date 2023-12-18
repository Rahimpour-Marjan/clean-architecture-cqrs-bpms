using MediatR;
using Application.Account.Models;

namespace Application.Account.Queries.FindById
{
    public class FindAccountByIdQuery : IRequest<AccountInfo>
    {
        public int Id { get; set; }
    }
}
