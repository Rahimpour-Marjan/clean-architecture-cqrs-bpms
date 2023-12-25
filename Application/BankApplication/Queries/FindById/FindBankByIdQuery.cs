using Application.BankApplication.Models;
using MediatR;

namespace Application.BankApplication.Queries.FindById
{
    public class FindBankByIdQuery : IRequest<BankInfo>
    {
        public int Id { get; set; }
    }
}
