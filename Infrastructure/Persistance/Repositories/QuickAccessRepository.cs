using Domain;
using Domain.Resources;
using Infrastructure.Persistance.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories
{
    public class QuickAccessRepository : IQuickAccessRepository
    {
        private readonly MakmonDbContext _db;

        public QuickAccessRepository(MakmonDbContext db)
        {
            _db = db;
        }
        public async Task<int> Create(QuickAccess model)
        {
            var result =await _db.QuickAccess.AddAsync(model);
            return result.Entity.Id;
        }
        public async Task<QuickAccess?> FindWithParam(int userId, long pageId)
        {
            return await (from qa in _db.QuickAccess
                          where qa.UserId == userId
                          && qa.SitePageId == pageId
                          select qa).FirstOrDefaultAsync();

        }

        public async Task<QuickAccess?> FindById(int id, int userId)
        {
            return await _db.QuickAccess
                            .Where(b => b.Id == id && b.UserId == userId)
                            .Include(b => b.SitePage)
                            .FirstOrDefaultAsync();
        }
        public async Task<QuickAccess?> FindByKey(string key, int userId)
        {
            var page = await _db.SitePage.Where(x => x.Key.ToLower() == key.ToLower()).FirstOrDefaultAsync();
            if (page == null)
                return null;
            var model = await _db.QuickAccess.Where(x => x.SitePageId == page.Id && x.UserId == userId).FirstOrDefaultAsync();
            return model;
        }
        public async Task<List<QuickAccess?>> FindByUserId(int userId)
        {
            #pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.
            return await _db.QuickAccess.Where(x => x.UserId == userId).ToListAsync();
        }
        public async Task<Tuple<IList<QuickAccess>, int>> FindAll(QueryFilter? queryFilter, int userId)
        {
            var query = _db.QuickAccess
                           .Where(b => b.UserId == userId)
                           .Include(b => b.SitePage).AsQueryable();

            query = query.ApplyFiltering(queryFilter);

            var totalRecords = query.Count();

            query = query.ApplyOrdering(queryFilter, "Entity");

            query = query.ApplyPaging(queryFilter);

            return new Tuple<IList<QuickAccess>, int>(await query.ToListAsync(), totalRecords);
        }
        public async Task Update(QuickAccess model)
        {
            _db.Entry(model).State = EntityState.Modified;
        }
        public async Task Delete(string key, int userId)
        {
            var quickaccess = await FindByKey(key, userId);
            if (quickaccess != null)
                _db.Entry(quickaccess).State = EntityState.Deleted;
        }
        public async Task DeleteAll(string[] keys, int userId)
        {
            List<int> ids = new List<int>();
            foreach (var item in keys)
            {
                var quickaccess = await FindByKey(item, userId);
                if (quickaccess != null)
                    ids.Add(quickaccess.Id);
            }
            var result = await _db.QuickAccess.Where(x => ids.Contains(x.Id) && x.UserId == userId).ToListAsync();
            _db.QuickAccess.RemoveRange(result);
        }
    }
}