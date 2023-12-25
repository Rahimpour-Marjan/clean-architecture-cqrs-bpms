using Application.Common;
using Application.CreditPaymentApplication.Models;
using MediatR;

namespace Application.CreditPaymentApplication.Queries.FindAll
{
    public class FindAllCreditPaymentQuery : IRequest<FindAllQueryResponse<IList<CreditPaymentInfo>>>
    {
        public string? Query { get; set; }
    }
}
