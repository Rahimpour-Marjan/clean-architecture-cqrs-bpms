using Application.QuickAccess.Models;
using MediatR;

namespace Application.QuickAccess.Queries.FindByKey
{
    public class FindQuickAccessByKeyQuery : IRequest<QuickAccessInfo>
    {
        public int UserId { get; set; }
        public string Key { get; set; }
    }
}