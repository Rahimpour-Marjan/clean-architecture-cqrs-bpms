using Application.UserGroup.Models;
using MediatR;

namespace Application.UserGroup.Queries.FindById
{
    public class FindUserGroupByIdQuery : IRequest<UserGroupInfo>
    {
        public int Id { get; set; }
    }
}
