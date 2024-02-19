
namespace Domain
{
    public class ProductComment
    {
        protected ProductComment() { }

        public ProductComment(string title, int productId, int? productCommentParentId, bool approved, string nameFamily, string emailAddress, string body, string? answerString, DateTime? answerDatetime, double? rate, int creatorId)
        {
            Title = title;
            ProductId = productId;
            ProductCommentParentId = productCommentParentId;
            Approved = approved;
            NameFamily = nameFamily;
            EmailAddress = emailAddress;
            Body = body;
            AnswerString = answerString;
            AnswerDatetime = answerDatetime;
            Rate = rate;
            CreatorId = creatorId;
            CreateDate = DateTime.Now;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int? ProductCommentParentId { get; set; }
        public virtual ProductComment? ProductCommentParent { get; set; }
        public bool Approved { get; set; }
        public string NameFamily { get; set; }
        public string EmailAddress { get; set; }
        public string Body { get; set; }
        public string? AnswerString { get; set; }
        public DateTime? AnswerDatetime { get; set; }
        public double? Rate { get; set; }
        public int CreatorId { get; set; }
        public int? ModifireId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}