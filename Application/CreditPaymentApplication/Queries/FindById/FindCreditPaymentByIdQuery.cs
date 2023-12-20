using MediatR;
using Application.CreditPaymentApplication.Models;

namespace Application.CreditPaymentApplication.Queries.FindById
{
    public class FindCreditPaymentByIdQuery : IRequest<CreditPaymentInfo>
    {
        public int Id { get; set; }
    }
}
