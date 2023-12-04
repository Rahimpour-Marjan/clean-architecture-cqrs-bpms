using MediatR;
using Application.QuickAccess.Models;
using Application.Common;

namespace Application.QuickAccess.Queries.FindAll
{
    public class FindAllQuickAccessQuery : IRequest<FindAllQueryResponse<IList<QuickAccessInfo>>>
    {
        public int UserId { get; set; }
        public string? Query { get; set; }
    }
}
