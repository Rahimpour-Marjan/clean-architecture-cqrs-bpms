using Application.QuickAccess.Models;
using MediatR;

namespace Application.QuickAccess.Queries.FindByUserId
{
    public class FindQuickAccessByUserIdQuery : IRequest<IList<QuickAccessInfo>>
    {
        public int UserId { get; set; }
    }
}
