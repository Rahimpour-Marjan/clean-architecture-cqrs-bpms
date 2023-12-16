using MediatR;
using Application.Calendar.Models;

namespace Application.Calendar.Queries.FindAll
{
    public class FindAllCalendarQuery : IRequest<IList<CalendarInfo>>
    {
    }
}
