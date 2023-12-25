using Application.Notification.Models;
using MediatR;

namespace Application.Notification.Queries.FindById
{
    public class FindNotificationByIdQuery : IRequest<NotificationInfo>
    {
        public int Id { get; set; }
        public int? UserId { get; set; }

    }
}
