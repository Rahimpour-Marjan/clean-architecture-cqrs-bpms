using Domain;
using Domain.Resources;
using Infrastructure.Persistance.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories
{
    public class UserLogRepository : IUserLogRepository
    {
        private readonly MakmonDbContext _db;

        public UserLogRepository(MakmonDbContext db)
        {
            _db = db;
        }
        public async Task<int> Create(UserLog userLog)
        {
            var result = await _db.UserLogs.AddAsync(userLog);
            return result.Entity.Id;
        }
        public async Task<IList<UserLog>> FindAll()
        {
            return await _db.UserLogs
                            .Include(x => x.User).ThenInclude(x=>x.Account)
                            .ToListAsync();
        }
        public async Task<Tuple<IList<UserLog>, int>> FindAll(int? userId, QueryFilter? queryFilter)
        {
            var query = _db.UserLogs.Where(x=> userId == null || x.UserId==userId)
                            .Include(x => x.User).ThenInclude(x=>x.Account).AsQueryable();

            query = query.ApplyFiltering(queryFilter);

            var totalRecords = query.Count();

            query = query.ApplyOrdering(queryFilter, "Entity");

            query = query.ApplyPaging(queryFilter);

            return new Tuple<IList<UserLog>, int>(await query.ToListAsync(), totalRecords);
        }

        public async Task<UserLog> FindById(int id)
        {
            var userLog = await _db.UserLogs.Include(x => x.User).ThenInclude(x => x.Account).FirstOrDefaultAsync(a => a.Id == id);
            if (userLog != null)
                return userLog;
            return null;
        }

        public async Task Update(UserLog userLog)
        {
            _db.Entry(userLog).State = EntityState.Modified;
        }
    }
}