namespace Domain
{
    public class UserGroup
    {
        protected UserGroup()
        {

        }
        public UserGroup(string title, bool isActive, bool isEditable, int? userGroupParentId, int creatorId)
        {
            Title = title;
            IsActive = isActive;
            IsEditable = isEditable;
            UserGroupParentId = userGroupParentId;
            CreatorId = creatorId;
            CreateDate= DateTime.Now;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public bool IsEditable { get; set; }
        public int? UserGroupParentId { get; set; }
        public virtual UserGroup? UserGroupParent { get; set; }
        public int CreatorId { get; set; }
        public int? ModifireId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual ICollection<PostJuncUserGroup> PostJuncUserGroups { get; set; }
        public virtual ICollection<UserGroupPrivilage> UserGroupPrivilages { get; set; }
    }
}
