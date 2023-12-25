using MediatR;

namespace Application.Menu.Queries.FindAll
{
    public class FindAllMenuQuery : IRequest<List<Domain.Resources.Menu?>>
    {
    }
}
