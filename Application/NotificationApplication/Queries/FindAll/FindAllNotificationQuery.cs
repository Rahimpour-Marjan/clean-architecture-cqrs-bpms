using Application.Common;
using Application.Notification.Models;
using MediatR;

namespace Application.Notification.Queries.FindAll
{
    public class FindAllNotificationQuery : IRequest<FindAllQueryResponse<IList<NotificationInfo>>>
    {
        public int UserId { get; set; }
        public string? Query { get; set; }
    }
}
