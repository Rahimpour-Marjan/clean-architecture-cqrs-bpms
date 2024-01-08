using System.ComponentModel.DataAnnotations;

namespace Api.Model.Article
{
    public class ArticleInfoModel
    {
        [Required(ErrorMessage = "ارسال عنوان الزامی می باشد")]
        public string Title { get; set; }

        [Required(ErrorMessage = "ارسال دسته بندی الزامی می باشد")]
        public int CategoryId { get; set; }
        public string? Keywords { get; set; }

        [Required(ErrorMessage = "ارسال خلاصه الزامی می باشد")]
        public string Summary { get; set; }

        [Required(ErrorMessage = "ارسال متن مقاله الزامی می باشد")]
        public string Body { get; set; }
        public bool? IsSlider { get; set; }

        [Required(ErrorMessage = "ارسال وضعیت الزامی می باشد")]
        public bool Active { get; set; }
        public string? Url { get; set; }
        public string? H1 { get; set; }
        public string? Writer { get; set; }
        public string? WriterPosition { get; set; }
        public string? WriterImageUrl { get; set; }
        public string? Aparat { get; set; }
        public string? Canonical { get; set; }
        public bool? NoFollow { get; set; }
        public bool? NoIndex { get; set; }
        public string? PostLabel { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? ShowDateTime { get; set; }
        public DateTime? ExpireDateTime { get; set; }
    }
}
