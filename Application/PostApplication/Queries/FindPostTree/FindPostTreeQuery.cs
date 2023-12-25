using Domain.Resources;
using MediatR;

namespace Application.PostApplication.Queries.FindPostTree
{
    public class FindPostTreeQuery : IRequest<IList<Tree>>
    {
    }
}
