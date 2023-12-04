using System.ComponentModel.DataAnnotations;

namespace Api.Model.SiteAction
{
    public class SiteActionInfo
    {
        [Required(ErrorMessage = "ارسال کنترلر الزامی می باشد")]
        public string Title { get; set; }

        [Required(ErrorMessage = "ارسال کنترلر الزامی می باشد")]
        public string Controller { get; set; }

        [Required(ErrorMessage = "ارسال اکشن الزامی می باشد")]
        public string Action { get; set; }

        [Required(ErrorMessage = "ارسال کد صفحه الزامی می باشد")]
        public long SitePageId { get; set; }
    }
}
