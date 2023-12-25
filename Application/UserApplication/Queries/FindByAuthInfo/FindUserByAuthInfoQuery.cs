using Application.Users.Models;
using MediatR;

namespace Application.User.Queries.FindByAuthInfo
{
    public class FindUserByAuthInfoQuery : IRequest<UserInfo>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
