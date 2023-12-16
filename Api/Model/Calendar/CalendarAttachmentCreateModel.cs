using System.ComponentModel.DataAnnotations;
namespace Api.Model.Calendar
{
    public class CalendarAttachmentCreateModel
    {
        [Required(ErrorMessage = "انتخاب فایل پیوست اجباری می باشد.")]
        public byte[] File { get; set; }
    }
}
