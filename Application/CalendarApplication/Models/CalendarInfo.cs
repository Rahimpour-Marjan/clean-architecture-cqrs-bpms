using Domain.Values;
using Application.Calendar.Models;

namespace Application.Calendar.Models
{
    public class CalendarInfo
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string DateRecord { get; set; }
        public string EventDate { get; set; }
        public string EventTime { get; set; }
        public int SenderId { get; set; }
        public string NotificationDate { get; set; }
        public string NotificationTime { get; set; }
        public bool HasTwoStepNotification { get; set; }
    }
}
