using Application.Users.Models;
using MediatR;

namespace Application.User.Queries.FindById
{
    public class FindUserByIdQuery : IRequest<UserInfo>
    {
        public int Id { get; set; }
    }
}
