using Domain.Values;
using Application.SitePage.Models;

namespace Application.QuickAccess.Models
{
    public class QuickAccessInfo
    {
        public int Id { get; set; }
        public int Priority { get; set; }
        public SitePageInfo SitePage { get; set; }
    }
}