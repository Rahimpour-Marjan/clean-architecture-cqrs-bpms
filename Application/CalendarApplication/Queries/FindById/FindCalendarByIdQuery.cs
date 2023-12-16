using MediatR;
using Application.Calendar.Models;

namespace Application.Calendar.Queries.FindById
{
    public class FindCalendarByIdQuery : IRequest<CalendarInfo>
    {
        public int Id { get; set; }
    }
}
