using MediatR;
using Application.CityApplication.Models;
using Application.Common;

namespace Application.CityApplication.Queries.FindAll
{
    public class FindAllCityQuery : IRequest<FindAllQueryResponse<IList<CityInfo>>>
    {
        public string? Query { get; set; }
    }
}
