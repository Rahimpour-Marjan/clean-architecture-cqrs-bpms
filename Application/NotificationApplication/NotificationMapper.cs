using Application.Notification.Models;
using AutoMapper;

namespace Application.Notification
{
    internal class NotificationMapper : Profile
    {
        public NotificationMapper()
        {
            CreateMap<Domain.Notification, NotificationInfo>();
        }
    }
}
