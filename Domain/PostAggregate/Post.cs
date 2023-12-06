namespace Domain
{
    public class Post
    {
        protected Post()
        {

        }

        public Post( string title, int? parentId)
        {
            Title = title;
            PostParentId = parentId;
        }

        public int Id { get; private  set; }
        public string Title { get;  set; }
        public int? PostParentId { get;  set; }
        public virtual Post? PostParent { get; set; }
        public virtual ICollection<PostJuncUserGroup> PostJuncUserGroups { get; set; }
    }
}
