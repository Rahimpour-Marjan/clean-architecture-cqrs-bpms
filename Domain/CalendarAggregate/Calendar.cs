namespace Domain
{
    public class Calendar
    {
        protected Calendar()
        {
        }
        public Calendar(string subject, string description, string eventDate, string eventTime, int senderId, string? notificationDate, string? notificationTime, bool? hasTwoStepNotification)
        {
            Subject = subject;
            Description = description;
            DateRecord = DateTime.Now;
            EventDate = eventDate;
            EventTime = eventTime;
            SenderId = senderId;
            NotificationDate = notificationDate;
            NotificationTime = notificationTime;
            HasTwoStepNotification = hasTwoStepNotification;
            NotificationSend = false;
            TwoStepNotificationSend = false;
        }

        public int Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime DateRecord { get; set; }
        public string EventDate { get; set; }
        public string EventTime { get; set; }
        public int SenderId { get; set; }
        public virtual Account Account { get; set; }
        public string? NotificationDate { get; set; }
        public string? NotificationTime { get; set; }
        public bool? HasTwoStepNotification { get; set; }
        public bool NotificationSend { get; set; }
        public bool TwoStepNotificationSend { get; set; }
    }
}


