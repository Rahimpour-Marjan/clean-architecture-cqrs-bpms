namespace Domain
{
    public class Notification
    {
        public Notification(string title, string text, int? senderId, int receiverId, string icon, string link, bool isRead, bool isStar, bool isArchive, bool isDeleted, int creatorId)
        {
            Title = title;
            Text = text;
            SenderId = senderId;
            ReceiverId = receiverId;
            Icon = icon;
            Link = link;
            IsRead = isRead;
            IsStar = isStar;
            IsArchive = isArchive;
            IsDeleted = isDeleted;
            CreatorId = creatorId;
            CreateDate = DateTime.Now;
        }

        protected Notification()
        {
        }


        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int? SenderId { get; set; }
        public int ReceiverId { get; set; }
        public virtual Account Account { get; set; }
        public string Icon { get; set; }
        public string Link { get; set; }
        public bool IsRead { get; set; }
        public bool IsStar { get; set; }
        public bool IsArchive { get; set; }
        public bool IsDeleted { get; set; }
        public int CreatorId { get; set; }
        public int? ModifireId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
