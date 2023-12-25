using Application.Common;
using Application.CurrencyTypeApplication.Models;
using MediatR;

namespace Application.CurrencyTypeApplication.Queries.FindAll
{
    public class FindAllCurrencyTypeQuery : IRequest<FindAllQueryResponse<IList<CurrencyTypeInfo>>>
    {
        public string? Query { get; set; }
    }
}
