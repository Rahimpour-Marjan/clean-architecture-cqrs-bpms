using Application.Common;
using Application.UserLogApplication.Models;
using MediatR;

namespace Application.UserLogApplication.Queries.FindAll
{
    public class FindAllUserLogQuery : IRequest<FindAllQueryResponse<IList<UserLogInfo>>>
    {
        public int? UserId { get; set; }
        public string? Query { get; set; }
    }
}
