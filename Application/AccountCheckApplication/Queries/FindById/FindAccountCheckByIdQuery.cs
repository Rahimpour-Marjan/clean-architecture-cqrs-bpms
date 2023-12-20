using MediatR;
using Application.AccountCheckApplication.Models;

namespace Application.AccountCheckApplication.Queries.FindById
{
    public class FindAccountCheckByIdQuery : IRequest<AccountCheckInfo>
    {
        public int Id { get; set; }
    }
}
