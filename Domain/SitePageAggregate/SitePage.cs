using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class SitePage
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public int Priority { get; set; }
        public long? MenuId { get; set; }
        public string Key { get; set; }
        public virtual Menu Menu { get; set; }

        public virtual ICollection<SiteAction> SiteActions { get; set; }
        public virtual ICollection<UserGroupPrivilage> UserGroupPrivilages { get; set; }
        protected SitePage()
        {

        }
        public SitePage(string title, string url, string icon, int priority, long menuId, string key)
        {
            Title = title;
            Url = url;
            Icon = icon;
            Priority = priority;
            MenuId = menuId;
            Key = key;
        }
    }
}
