using Domain;
using Domain.Resources;
using Infrastructure.Persistance.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly MakmonDbContext _db;
        public NotificationRepository(MakmonDbContext db)
        {
            _db = db;
        }
        public async Task<int> Create(Notification notification)
        {
            var result = await _db.Notifications.AddAsync(notification);
            return result.Entity.Id;
        }

        public async Task<Notification> FindById(int id, int? userId)
        {
            #pragma warning disable CS8603 // Possible null reference return.
            return await _db.Notifications
                          .Where(b => b.Id == id && b.SenderId == userId && b.IsDeleted == false)
                          .FirstOrDefaultAsync();
        }
        public async Task<Tuple<IList<Notification>, int>> FindAll(QueryFilter? queryFilter, int? userId)
        {
            var query = _db.Notifications
                        .Where(b => b.SenderId == userId && b.IsDeleted == false).AsQueryable();

            query = query.ApplyFiltering(queryFilter);

            var totalRecords = query.Count();

            query = query.ApplyOrdering(queryFilter, "Entity");

            query = query.ApplyPaging(queryFilter);

            return new Tuple<IList<Notification>, int>(await query.ToListAsync(), totalRecords);
        }
        public async Task Update(Notification notification)
        {
            _db.Entry((Notification)notification).State = EntityState.Modified;
        }
        public async Task Delete(int id, int? userId)
        {
            Notification validNotification=await FindById(id, userId);
            validNotification.IsDeleted = true;
            await Update(validNotification);
        }
        public async Task DeleteAll(int[] ids, int? userId)
        {
            var validNotifications = await _db.Notifications
                                            .Where(x => ids.Contains(x.Id) && x.SenderId == userId ).ToListAsync();
            foreach (Notification notification in validNotifications)
            {
                notification.IsDeleted = true;
                await Update(notification);
            }
        }
    }
}
