using MediatR;
using Application.UserGroup.Models;

namespace Application.UserGroup.Queries.FindById
{
    public class FindUserGroupByIdQuery : IRequest<UserGroupInfo>
    {
        public int Id { get; set; }
    }
}
