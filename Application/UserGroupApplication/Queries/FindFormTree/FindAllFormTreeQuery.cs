using MediatR;
using Domain.Resources;

namespace Application.UserGroup.Queries.FindFormTree
{
    public class FindAllFormTreeQuery : IRequest<List<AccessTree?>>
    {
        public int? UserId { get; set; }
        public int? UserGroupId { get; set; }
        public int? PostId { get; set; }
        public bool? IsSelected { get; set; }
    }
}
