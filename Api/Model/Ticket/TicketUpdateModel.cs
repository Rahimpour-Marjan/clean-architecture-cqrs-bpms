using Domain.Enums;
using System.ComponentModel.DataAnnotations;
namespace Api.Model.Ticket
{
    public class TicketUpdateModel
    {
        [Required(ErrorMessage = "ارسال عنوان تیکت اجباری می باشد")]
        public string Title { get; set; }
        [Required(ErrorMessage = "وارد نمودن متن تیکت اجباری می باشد")]
        public string TicketText { get; set; }
        public int? TicketParentId { get; set; }
        public int? WorkRequestId { get; set; }

        [Required(ErrorMessage = "وارد نمودن وضعیت تیکت اجباری می باشد")]
        public TicketStatus TicketStatus { get; set; }

        [Required(ErrorMessage = "وارد نمودن اولویت تیکت اجباری می باشد")]
        public TicketPriority TicketPriority { get; set; }
        [Required(ErrorMessage = "وارد نمودن نوع تیکت اجباری می باشد")]
        public TicketType TicketType { get; set; }
        public TicketAttachmentCreateModel[]? TicketAttachments { get; set; }
    }
}
