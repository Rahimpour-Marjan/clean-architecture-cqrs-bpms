using Domain.Values;

namespace Application.Notification.Models
{
    public class NotificationInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int? SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string Icon { get; set; }
        public string Link { get; set; }
        public bool IsRead { get; set; }
        public bool IsStar { get; set; }
        public bool IsArchive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateRecorde { get; set; }
    }
}
