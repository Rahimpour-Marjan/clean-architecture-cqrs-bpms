using MediatR;
using Application.Notification.Models;
using Application.Common;

namespace Application.Notification.Queries.FindAll
{
    public class FindAllNotificationQuery : IRequest<FindAllQueryResponse<IList<NotificationInfo>>>
    {
        public int UserId { get; set; }
        public string? Query { get; set; }
    }
}
