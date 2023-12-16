using System.ComponentModel.DataAnnotations;
namespace Api.Model.Ticket
{
    public class TicketAttachmentCreateModel
    {
        [Required(ErrorMessage = "ارسال عنوان الزامی می باشد")]
        public string Title { get; set; }

        [Required(ErrorMessage = "ارسال آدرس تصویر الزامی می باشد")]
        public string FileUrl { get; set; }
        public decimal Size { get; set; }
    }
}
