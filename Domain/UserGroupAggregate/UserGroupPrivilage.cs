namespace Domain
{
    public class UserGroupPrivilage
    {

        protected UserGroupPrivilage()
        {
        }
        public UserGroupPrivilage(int userGroupId, long menuId, long sitePageId, int siteActionId, int creatorId)
        {
            UserGroupId = userGroupId;
            MenuId = menuId;
            SitePageId = sitePageId;
            SiteActionId = siteActionId;
            CreatorId = creatorId;
            CreateDate= DateTime.Now;
        }
        public int Id { get; set; }
        public int UserGroupId { get; set; }
        public virtual UserGroup UserGroup { get; set; }
        public long MenuId { get; set; }
        public virtual Menu Menu { get; set; }
        public long SitePageId { get; set; }
        public virtual SitePage SitePage { get; set; }
        public int? SiteActionId { get; set; }
        public virtual SiteAction? SiteAction { get; set; }
        public int CreatorId { get; set; }
        public int? ModifireId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
