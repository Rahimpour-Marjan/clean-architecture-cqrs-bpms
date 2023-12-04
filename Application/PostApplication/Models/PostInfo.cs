namespace Application.Post.Models
{
    public class PostInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        //public int ParentId { get; set; }
        public PostInfo Parent { get; set; }
    }
}
