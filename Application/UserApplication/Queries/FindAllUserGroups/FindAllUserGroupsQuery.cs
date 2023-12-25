using Domain.Resources;
using MediatR;

namespace Application.User.Queries.FindAllUserGroups
{
    public class FindAllUserGroupsQuery : IRequest<IList<Tree>>
    {
        public int UserId { get; set; }
    }
}
