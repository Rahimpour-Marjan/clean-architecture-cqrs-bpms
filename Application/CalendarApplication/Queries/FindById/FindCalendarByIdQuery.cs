using Application.Calendar.Models;
using MediatR;

namespace Application.Calendar.Queries.FindById
{
    public class FindCalendarByIdQuery : IRequest<CalendarInfo>
    {
        public int Id { get; set; }
    }
}
