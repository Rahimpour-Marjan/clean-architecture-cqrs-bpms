using MediatR;
using Application.Notification.Models;

namespace Application.Notification.Queries.FindById
{
    public class FindNotificationByIdQuery : IRequest<NotificationInfo>
    {
        public int Id { get; set; }
        public int? UserId { get; set; }

    }
}
