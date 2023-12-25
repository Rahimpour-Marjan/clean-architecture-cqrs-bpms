using System.ComponentModel.DataAnnotations;
namespace Api.Model.Calendar
{
    public class CalendarCreateModel
    {

        [Required(ErrorMessage = "ارسال موضوع اجباری می باشد")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "ارسال متن محتوا اجباری می باشد")]
        public string Description { get; set; }
        [Required(ErrorMessage = "انتخاب تاریخ رویداد اجباری می باشد")]
        public string EventDate { get; set; }
        [Required(ErrorMessage = "انتخاب ساعت رویداد اجباری می باشد")]
        public string EventTime { get; set; }
        //public int SenderId { get; set; }
        public string? NotificationDate { get; set; }
        public string? NotificationTime { get; set; }
        public bool? HasTwoStepNotification { get; set; }
        [Required(ErrorMessage = "ارسال دریافت کننده رویداد اجباری می باشد")]
        public int[] ReceiversId { get; set; }
    }
}
