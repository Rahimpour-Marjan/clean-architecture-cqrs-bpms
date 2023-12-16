using Application.Menu.Models;
using Application.SiteActionApplication.Models;

namespace Application.SitePage.Models
{
    public class SitePageInfo
    {
        public long Id { get; set; }
        public string Title { get; set; }
		public string Key { get; set; }
        public int Priority { get; set; }
        public MenuInfo Menu { get; set; }
        public List<SiteActionInfo> SiteActions { get; set; }
    }
}