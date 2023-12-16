using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class QuickAccess
    {
        protected QuickAccess()
        {
        }
        public QuickAccess(int userId, long sitePageId, int priority)
        {
            UserId = userId;
            SitePageId = sitePageId;
            Priority = priority;
        }

        public int Id { get; set; }
        public int UserId { get; set; }

        public long SitePageId { get; set; }
        public int Priority { get; set; }
        public virtual SitePage SitePage { get; set; }
    }
}