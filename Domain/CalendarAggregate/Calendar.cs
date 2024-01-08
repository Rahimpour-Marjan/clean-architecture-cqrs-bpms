namespace Domain
{
    public class Calendar
    {
        protected Calendar()
        {
        }
        public Calendar(string subject, string description, string eventDate, string eventTime, int senderId, string? notificationDate, string? notificationTime, bool? hasTwoStepNotification,int creatorId)
        {
            Subject = subject;
            Description = description;
            EventDate = eventDate;
            EventTime = eventTime;
            SenderId = senderId;
            NotificationDate = notificationDate;
            NotificationTime = notificationTime;
            HasTwoStepNotification = hasTwoStepNotification;
            NotificationSend = false;
            TwoStepNotificationSend = false;
            CreatorId = creatorId;
            CreateDate = DateTime.Now;
        }

        public int Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string EventDate { get; set; }
        public string EventTime { get; set; }
        public int SenderId { get; set; }
        public virtual Account Account { get; set; }
        public string? NotificationDate { get; set; }
        public string? NotificationTime { get; set; }
        public bool? HasTwoStepNotification { get; set; }
        public bool NotificationSend { get; set; }
        public bool TwoStepNotificationSend { get; set; }
        public int CreatorId { get; set; }
        public int? ModifireId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}


