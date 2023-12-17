using MediatR;
using Application.Person.Models;
using Application.Common;

namespace Application.Person.Queries.FindAll
{
    public class FindAllPersonQuery:IRequest<FindAllQueryResponse<IList<PersonView>>>
    {
        public string? Query { get; set; }
    }
}
