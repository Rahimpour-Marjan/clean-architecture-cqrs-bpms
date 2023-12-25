using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories
{
    public class CalendarRepository : ICalendarRepository
    {
        private readonly MakmonDbContext _db;
        public CalendarRepository(MakmonDbContext db)
        {
            _db = db;
        }
        public async Task<int> Create(Calendar calendar)
        {
            var result = await _db.Calendars.AddAsync(calendar);
            return result.Entity.Id;
        }
        public async Task Create(int[] receiversId, int calendarId)
        {
            foreach (var item in receiversId)
            {
                var validCalendarReceiver = new Domain.CalendarReceiver(calendarId, item);
                await _db.CalendarReceivers.AddAsync(validCalendarReceiver);
            }

        }

        public async Task<int> Create(CalendarAttachment calendarAttachment)
        {
            var result = await _db.CalendarAttachments.AddAsync(calendarAttachment);
            return result.Entity.Id;
        }
        public async Task<Calendar> FindById(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _db.Calendars
                        .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IList<Calendar>> FindAll()
        {
            return await _db.Calendars
                            .ToListAsync();
        }

        public async Task Update(Calendar calendar)
        {
            _db.Entry((Calendar)calendar).State = EntityState.Modified;
        }
        public async Task Delete(int id)
        {
            var calendar = await FindById(id);
            _db.Entry((Calendar)calendar).State = EntityState.Deleted;
        }
        public async Task DeleteAll(int[] ids)
        {
            var calendar = await _db.Calendars.Where(x => ids.Contains(x.Id)).ToListAsync();
            _db.Calendars.RemoveRange(calendar);
        }
        public async Task CalendarRecevierDelete(int calendarId)
        {
            var calendarRecevier = await _db.CalendarReceivers.Where(x => x.CalendarId == calendarId).ToListAsync();
            _db.CalendarReceivers.RemoveRange(calendarRecevier);
        }
    }
}
