using MediatR;
using Application.Menu.Models;

namespace Application.Menu.Queries.FindAll
{
    public class FindAllMenuQuery : IRequest<List<Domain.Resources.Menu?>>
    {
    }
}
