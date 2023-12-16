using MediatR;
using Application.CountryApplication.Models;

namespace Application.CountryApplication.Queries.FindById
{
    public class FindCountryByIdQuery : IRequest<CountryInfo>
    {
        public int Id { get; set; }
    }
}
