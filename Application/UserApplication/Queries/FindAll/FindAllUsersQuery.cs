using MediatR;
using Application.Users.Models;
using Application.Common;

namespace Application.User.Queries.FindAll
{
    public class FindAllUsersQuery:IRequest<FindAllQueryResponse<IList<UserInfo>>>
    {
        public string? Query { get; set; }
    }
}
