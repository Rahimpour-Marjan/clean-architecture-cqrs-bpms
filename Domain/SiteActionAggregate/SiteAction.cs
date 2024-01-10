namespace Domain
{
    public class SiteAction
    {
        protected SiteAction()
        {

        }
        public SiteAction(string title, string controller, string action, long sitePageId, int creatorId)
        {
            Title = title;
            Controller = controller;
            Action = action;
            SitePageId = sitePageId;
            CreatorId = creatorId;
            CreateDate = DateTime.Now;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public int? ParentId { get; set; }
        public virtual SiteAction? Parent { get; set; }
        public long SitePageId { get; set; }
        public virtual SitePage SitePage { get; set; }
        public int CreatorId { get; set; }
        public int? ModifireId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual ICollection<UserGroupPrivilage> UserGroupPrivilages { get; set; }
    }
}
