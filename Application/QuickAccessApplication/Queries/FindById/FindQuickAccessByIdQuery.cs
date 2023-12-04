using MediatR;
using Application.QuickAccess.Models;

namespace Application.QuickAccess.Queries.FindById
{
    public class FindQuickAccessByIdQuery : IRequest<QuickAccessInfo>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
    }
}
