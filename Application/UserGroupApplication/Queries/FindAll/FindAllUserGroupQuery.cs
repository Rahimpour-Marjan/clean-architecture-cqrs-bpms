using Application.Common;
using Application.UserGroup.Models;
using MediatR;

namespace Application.UserGroup.Queries.FindAll
{
    public class FindAllUserGroupQuery : IRequest<FindAllQueryResponse<IList<UserGroupInfo>>>
    {
        public string? Query { get; set; }
    }
}
