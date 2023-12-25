using MediatR;
using Application.CurrencyTypeApplication.Models;
using Application.Common;

namespace Application.CurrencyTypeApplication.Queries.FindAll
{
    public class FindAllCurrencyTypeQuery : IRequest<FindAllQueryResponse<IList<CurrencyTypeInfo>>>
    {
        public string? Query { get; set; }
    }
}
