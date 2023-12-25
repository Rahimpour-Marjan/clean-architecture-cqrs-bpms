using Application.AccountCreditApplication.Models;
using MediatR;

namespace Application.AccountCreditApplication.Queries.FindById
{
    public class FindAccountCreditByIdQuery : IRequest<AccountCreditInfo>
    {
        public int Id { get; set; }
    }
}
