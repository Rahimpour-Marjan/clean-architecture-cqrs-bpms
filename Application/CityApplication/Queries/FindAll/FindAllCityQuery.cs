using Application.CityApplication.Models;
using Application.Common;
using MediatR;

namespace Application.CityApplication.Queries.FindAll
{
    public class FindAllCityQuery : IRequest<FindAllQueryResponse<IList<CityInfo>>>
    {
        public string? Query { get; set; }
    }
}
