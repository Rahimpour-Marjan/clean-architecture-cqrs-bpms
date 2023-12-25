using Application.Common;
using Application.Users.Models;
using MediatR;

namespace Application.User.Queries.FindAll
{
    public class FindAllUsersQuery : IRequest<FindAllQueryResponse<IList<UserInfo>>>
    {
        public string? Query { get; set; }
    }
}
