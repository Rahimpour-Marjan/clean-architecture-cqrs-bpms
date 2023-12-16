namespace Domain
{
    public class PersonJuncPost
    {
        public PersonJuncPost()
        {
        }

        public PersonJuncPost(int personId, int postId)
        {
            PersonId = personId;
            PostId = postId;
        }

        public int Id { get; private set; }
        public int PersonId { get; private set; }
        public virtual Person Person { get;  set; }
        public int PostId { get; private set; }
        public virtual Post Post { get;  set; }
        
    }
}
