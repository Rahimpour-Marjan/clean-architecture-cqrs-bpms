using Application.CountryApplication.Models;
using MediatR;

namespace Application.CountryApplication.Queries.FindById
{
    public class FindCountryByIdQuery : IRequest<CountryInfo>
    {
        public int Id { get; set; }
    }
}
