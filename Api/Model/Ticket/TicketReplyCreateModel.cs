using Domain.Enums;
using System.ComponentModel.DataAnnotations;
namespace Api.Model.Ticket
{
    public class TicketReplyCreateModel
    {
        [Required(ErrorMessage = "وارد نمودن متن تیکت اجباری می باشد")]
        public string TicketText { get; set; }
        public int TicketParentId { get; set; }
        public TicketStatus? Status { get; set; }
        public TicketAttachmentCreateModel[]? TicketAttachments { get; set; }
    }
}
