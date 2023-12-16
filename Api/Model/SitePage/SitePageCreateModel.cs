using System.ComponentModel.DataAnnotations;

namespace Api.Model.SitePage
{
    public class SitePageCreateModel
    {
        [Required(ErrorMessage = "ارسال عنوان الزامی می باشد")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "ارسال آدرس الزامی می باشد")]
        public string Url { get; set; }
        [Required(ErrorMessage = "ارسال آیکون الزامی می باشد")]
        public string Icon { get; set; }
        [Required(ErrorMessage = "انتخاب اولویت الزامی می باشد")]
        public int Priority { get; set; }
        [Required(ErrorMessage = "انتخاب منو الزامی می باشد")]
        public long MenuId { get; set; }
        [Required(ErrorMessage = "ارسال کلید الزامی می باشد")]
        public string Key { get; set; }
    }
}
