using MediatR;
namespace Application.UserGroup.Queries.FindByResultCode
{
    public class FindUserGroupByResultCodeQuery : IRequest<Domain.UserGroup>
    {
        public int ResultCode { get; set; }
    }
}
