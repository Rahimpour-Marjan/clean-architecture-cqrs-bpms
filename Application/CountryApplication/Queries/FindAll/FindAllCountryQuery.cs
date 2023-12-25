using Application.Common;
using Application.CountryApplication.Models;
using MediatR;

namespace Application.CountryApplication.Queries.FindAll
{
    public class FindAllCountryQuery : IRequest<FindAllQueryResponse<IList<CountryInfo>>>
    {
        public string? Query { get; set; }
    }
}
