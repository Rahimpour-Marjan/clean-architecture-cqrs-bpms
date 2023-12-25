namespace Domain
{
    public class AccountJuncPost
    {
        public AccountJuncPost()
        {
        }

        public AccountJuncPost(int AccountId, int postId)
        {
            AccountId = AccountId;
            PostId = postId;
        }

        public int Id { get; private set; }
        public int AccountId { get; private set; }
        public virtual Account Account { get; set; }
        public int PostId { get; private set; }
        public virtual Post Post { get; set; }

    }
}
