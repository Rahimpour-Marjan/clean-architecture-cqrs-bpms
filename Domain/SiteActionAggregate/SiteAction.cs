namespace Domain
{
    public class SiteAction
    {
        protected SiteAction()
        {

        }
        public SiteAction(string title, string controller, string action, long sitePageId)
        {
            Title = title;
            Controller = controller;
            Action = action;
            SitePageId = sitePageId;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public int? ParentId { get; set; }
        public virtual SiteAction? Parent { get; set; }
        public long SitePageId { get; set; }
        public virtual SitePage SitePage { get; set; }

        public virtual ICollection<UserGroupPrivilage> UserGroupPrivilages { get; set; }
    }
}
