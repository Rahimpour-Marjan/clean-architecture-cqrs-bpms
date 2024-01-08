namespace Domain
{
    public class QuickAccess
    {
        protected QuickAccess()
        {
        }
        public QuickAccess(int userId, long sitePageId, int priority, int creatorId)
        {
            UserId = userId;
            SitePageId = sitePageId;
            Priority = priority;
            CreatorId = creatorId;
            CreateDate = DateTime.Now;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public long SitePageId { get; set; }
        public virtual SitePage SitePage { get; set; }
        public int Priority { get; set; }
        public int CreatorId { get; set; }
        public int? ModifireId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}