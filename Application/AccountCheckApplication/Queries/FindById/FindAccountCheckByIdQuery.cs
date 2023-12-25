using Application.AccountCheckApplication.Models;
using MediatR;

namespace Application.AccountCheckApplication.Queries.FindById
{
    public class FindAccountCheckByIdQuery : IRequest<AccountCheckInfo>
    {
        public int Id { get; set; }
    }
}
