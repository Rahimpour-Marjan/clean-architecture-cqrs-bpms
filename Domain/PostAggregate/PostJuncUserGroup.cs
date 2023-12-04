namespace Domain
{
    public class PostJuncUserGroup
    {
        protected PostJuncUserGroup()
        {
        }
        public PostJuncUserGroup(int postId, int userGroupId, bool? assigned)
        {
            PostId = postId;
            UserGroupId = userGroupId;
            Assigned = assigned;
        }
        public int Id { get; set; }
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
        public int UserGroupId { get; set; }
        public virtual UserGroup UserGroup { get; set; }
        public bool? Assigned { get; set; }
    }

}
