using Application.CityApplication.Models;
using MediatR;

namespace Application.CityApplication.Queries.FindById
{
    public class FindCityByIdQuery : IRequest<CityInfo>
    {
        public int Id { get; set; }
    }
}
