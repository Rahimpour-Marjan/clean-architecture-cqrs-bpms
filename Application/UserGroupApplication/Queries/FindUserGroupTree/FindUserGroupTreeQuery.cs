using MediatR;
using Domain.Resources;

namespace Application.UserGroupApplication.Queries.FindUserGroupTree
{
    public class FindUserGroupTreeQuery : IRequest<IList<Tree>>
    {
    }
}
