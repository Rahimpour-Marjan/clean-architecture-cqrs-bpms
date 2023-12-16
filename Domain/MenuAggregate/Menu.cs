namespace Domain
{
    public class Menu
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public int Priority { get; set; }
        public bool IsActive { get; set; }
        public long? ParentId { get; set; }
        public virtual Menu? Parent { get; set; }
        public DateTime DateRecord { get; set; }
        public virtual ICollection<SitePage> SitePages { get; set; }
        public virtual ICollection<Menu> SubMenus { get; set; }
        public virtual ICollection<UserGroupPrivilage> UserGroupPrivilages { get; set; }
        protected Menu()
        {

        }

        public Menu(string title, string url, string icon, int priority, bool isActive, long? parentId)
        {
            Title = title;
            Url = url;
            Icon = icon;
            Priority = priority;
            IsActive = isActive;
            ParentId = parentId;
            DateRecord = DateTime.Now;
        }
    }
}
