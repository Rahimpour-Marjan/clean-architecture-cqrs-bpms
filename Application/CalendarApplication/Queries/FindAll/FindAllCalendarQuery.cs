using Application.Calendar.Models;
using MediatR;

namespace Application.Calendar.Queries.FindAll
{
    public class FindAllCalendarQuery : IRequest<IList<CalendarInfo>>
    {
    }
}
