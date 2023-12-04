using Application.Common;
using Application.Menu.Models;
using MediatR;

namespace Application.Menu.Queries.FindAllWithFilter
{
    public class FindAllMenuWithFilterQuery : IRequest<FindAllQueryResponse<IList<MenuInfo>>>
    {
        public string? Query { get; set; }
    }
}
