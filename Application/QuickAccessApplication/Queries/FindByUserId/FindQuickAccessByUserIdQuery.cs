using MediatR;
using Application.QuickAccess.Models;

namespace Application.QuickAccess.Queries.FindByUserId
{
    public class FindQuickAccessByUserIdQuery : IRequest<IList<QuickAccessInfo>>
    {
        public int UserId { get; set; }
    }
}
