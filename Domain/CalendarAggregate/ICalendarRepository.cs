namespace Domain
{
    public interface ICalendarRepository
    {
        Task<int> Create(Calendar calendar);
        Task Create(int[] receiversId, int calendarId);
        Task<int> Create(CalendarAttachment calendarAttachment);
        Task<IList<Calendar>> FindAll();
        Task<Calendar> FindById(int id);
        Task Update(Calendar calendar);
        Task Delete(int id);
        Task DeleteAll(int[] ids);
        Task CalendarRecevierDelete(int calendarId);
    }
}
