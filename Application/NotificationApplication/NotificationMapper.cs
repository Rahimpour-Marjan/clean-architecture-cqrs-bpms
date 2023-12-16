using AutoMapper;
using Application.Notification.Models;

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
