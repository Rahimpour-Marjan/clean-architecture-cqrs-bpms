using Application.CreditPaymentApplication.Models;
using MediatR;

namespace Application.CreditPaymentApplication.Queries.FindById
{
    public class FindCreditPaymentByIdQuery : IRequest<CreditPaymentInfo>
    {
        public int Id { get; set; }
    }
}
