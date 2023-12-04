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
            ParentId = parentId;
        }

        public int Id { get; private  set; }
        public string Title { get;  set; }
        public int? ParentId { get;  set; }
        public virtual Post? Parent { get; set; }
        public virtual ICollection<PostJuncUserGroup> PostJuncUserGroups { get; set; }
    }
}
