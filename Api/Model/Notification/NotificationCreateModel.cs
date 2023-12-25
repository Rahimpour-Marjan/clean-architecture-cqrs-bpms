using System.ComponentModel.DataAnnotations;
namespace Api.Model.Notification
{
    public class NotificationCreateModel
    {

        [Required(ErrorMessage = "ارسال عنوان برای پیام الزامی می باشد")]
        public string Title { get; set; }
        [Required(ErrorMessage = "ارسال متن پیام الزامی می باشد")]
        public string Text { get; set; }
        [Required(ErrorMessage = "انتخاب دریافت کننده پیام الزامی می باشد")]
        public int ReceiverId { get; set; }
        [Required(ErrorMessage = "انتخاب آیکون پیام الزامی می باشد")]
        public string Icon { get; set; }
        [Required(ErrorMessage = "انتخاب لینک پیام الزامی می باشد")]
        public string Link { get; set; }
        //public bool IsRead { get; set; }
        //public bool IsStar { get; set; }
        //public bool IsArchive { get; set; }
        //public bool IsDeleted { get; set; }
        //public DateTime DateRecorde { get; set; }

    }
}
