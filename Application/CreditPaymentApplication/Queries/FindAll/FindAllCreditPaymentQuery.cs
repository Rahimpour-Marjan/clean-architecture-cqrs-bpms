using MediatR;
using Application.CreditPaymentApplication.Models;
using Application.Common;

namespace Application.CreditPaymentApplication.Queries.FindAll
{
    public class FindAllCreditPaymentQuery : IRequest<FindAllQueryResponse<IList<CreditPaymentInfo>>>
    {
        public string? Query { get; set; }
    }
}
