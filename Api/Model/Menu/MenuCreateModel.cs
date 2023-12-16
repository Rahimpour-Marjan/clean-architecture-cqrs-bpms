using System.ComponentModel.DataAnnotations;

namespace Api.Model.Menu
{
    public class MenuCreateModel
    {
        [Required(ErrorMessage = "ارسال نام منو الزامی می باشد")]
        public string Title { get; set; }
        [Required(ErrorMessage = "ارسال آدرس منو الزامی می باشد")]
        public string Url { get; set; }
        [Required(ErrorMessage = "ارسال آیکون منو الزامی می باشد")]
        public string Icon { get; set; }
        [Required(ErrorMessage = "انتخاب اولویت برای آیکون منو الزامی می باشد")]
        public int Priority { get; set; }
        [Required(ErrorMessage = "انتخاب وضعیت منو الزامی می باشد")]
        public bool IsActive { get; set; }
        public long? ParentId { get; set; }
    }
}
