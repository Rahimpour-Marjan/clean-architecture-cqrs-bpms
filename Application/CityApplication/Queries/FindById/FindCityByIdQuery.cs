using MediatR;
using Application.CityApplication.Models;

namespace Application.CityApplication.Queries.FindById
{
    public class FindCityByIdQuery : IRequest<CityInfo>
    {
        public int Id { get; set; }
    }
}
