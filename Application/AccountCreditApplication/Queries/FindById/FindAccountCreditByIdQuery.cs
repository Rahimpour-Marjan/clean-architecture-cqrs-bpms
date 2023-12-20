using MediatR;
using Application.AccountCreditApplication.Models;

namespace Application.AccountCreditApplication.Queries.FindById
{
    public class FindAccountCreditByIdQuery : IRequest<AccountCreditInfo>
    {
        public int Id { get; set; }
    }
}
