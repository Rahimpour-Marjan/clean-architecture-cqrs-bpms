using Application.SitePage.Models;

namespace Application.Menu.Models
{
    public class MenuInfo
    {
        public MenuInfo()
        {
            Parent = null;
            SubMenus = new List<MenuInfo>();
            SitePages = new List<SitePageInfo>();
        }
        public long Id { get; set; }
        public string Title { get; set; }
        public MenuInfo? Parent { get; set; }
        public List<SitePageInfo> SitePages { get; set; }
        public List<MenuInfo> SubMenus { get; set; }
    }
}