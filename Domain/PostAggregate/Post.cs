namespace Domain
{
    public class Post
    {
        protected Post()
        {

        }

        public Post(string title, int? parentId, int creatorId)
        {
            Title = title;
            PostParentId = parentId;
            CreatorId = creatorId;
            CreateDate = DateTime.Now;
        }

        public int Id { get; private set; }
        public string Title { get; set; }
        public int? PostParentId { get; set; }
        public virtual Post? PostParent { get; set; }
        public int CreatorId { get; set; }
        public int? ModifireId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual ICollection<PostJuncUserGroup> PostJuncUserGroups { get; set; }
    }
}
