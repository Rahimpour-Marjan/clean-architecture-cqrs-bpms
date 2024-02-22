
using Application.ProductApplication.Models;

namespace Application.ProductCommentApplication.Models
{
    public class ProductCommentInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual ProductInfo Product { get; set; }
        public virtual ProductCommentInfo? ProductCommentParent { get; set; }
        public bool Approved { get; set; }
        public string NameFamily { get; set; }
        public string EmailAddress { get; set; }
        public string Body { get; set; }
        public string? AnswerString { get; set; }
        public DateTime? AnswerDatetime { get; set; }
        public double? Rate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
