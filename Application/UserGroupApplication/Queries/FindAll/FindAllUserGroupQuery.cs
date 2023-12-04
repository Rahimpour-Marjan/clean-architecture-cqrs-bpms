using MediatR;
using Application.UserGroup.Models;
using Application.Common;

namespace Application.UserGroup.Queries.FindAll
{
    public class FindAllUserGroupQuery : IRequest<FindAllQueryResponse<IList<UserGroupInfo>>>
    {
        public string? Query { get; set; }
    }
}
