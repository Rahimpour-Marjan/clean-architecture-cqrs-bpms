using Domain.Resources;
using MediatR;

namespace Application.UserGroupApplication.Queries.FindUserGroupTree
{
    public class FindUserGroupTreeQuery : IRequest<IList<Tree>>
    {
    }
}
