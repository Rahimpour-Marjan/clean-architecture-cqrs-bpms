using MediatR;
using Application.CountryApplication.Models;
using Application.Common;

namespace Application.CountryApplication.Queries.FindAll
{
    public class FindAllCountryQuery : IRequest<FindAllQueryResponse<IList<CountryInfo>>>
    {
        public string? Query { get; set; }
    }
}
