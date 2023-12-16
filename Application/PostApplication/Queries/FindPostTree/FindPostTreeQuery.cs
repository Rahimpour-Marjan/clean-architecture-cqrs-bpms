using MediatR;
using Domain.Resources;

namespace Application.PostApplication.Queries.FindPostTree
{
    public class FindPostTreeQuery : IRequest<IList<Tree>>
    {
    }
}
