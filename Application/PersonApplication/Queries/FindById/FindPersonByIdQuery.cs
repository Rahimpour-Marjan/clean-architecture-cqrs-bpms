using MediatR;
using Application.Person.Models;

namespace Application.Person.Queries.FindById
{
    public class FindPersonByIdQuery : IRequest<PersonInfo>
    {
        public int Id { get; set; }
    }
}
