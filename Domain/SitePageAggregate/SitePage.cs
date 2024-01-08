namespace Domain
{
    public class SitePage
    {
        protected SitePage()
        {

        }
        public SitePage(string title, string url, string icon, int priority, long menuId, string key, int creatorId)
        {
            Title = title;
            Url = url;
            Icon = icon;
            Priority = priority;
            MenuId = menuId;
            Key = key;
            CreatorId = creatorId;
            CreateDate = DateTime.Now;
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public int Priority { get; set; }
        public long? MenuId { get; set; }
        public string Key { get; set; }
        public virtual Menu Menu { get; set; }
        public int CreatorId { get; set; }
        public int? ModifireId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual ICollection<SiteAction> SiteActions { get; set; }
        public virtual ICollection<UserGroupPrivilage> UserGroupPrivilages { get; set; }
       
    }
}
