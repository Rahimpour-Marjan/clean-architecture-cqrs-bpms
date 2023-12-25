using MediatR;
using Application.BankApplication.Models;

namespace Application.BankApplication.Queries.FindById
{
    public class FindBankByIdQuery : IRequest<BankInfo>
    {
        public int Id { get; set; }
    }
}
