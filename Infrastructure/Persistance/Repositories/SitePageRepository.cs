using Domain;
using Domain.Resources;
using Infrastructure.Persistance.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories
{
    public class SitePageRepository : ISitePageRepository
    {
        private readonly MakmonDbContext _db;
        public SitePageRepository(MakmonDbContext db)
        {
            _db = db;
        }
        public async Task<long> Create(SitePage sitepage)
        {
            var result = await _db.SitePage.AddAsync(sitepage);
            return result.Entity.Id;
        }

        public async Task<SitePage> FindById(long id)
        {
            #pragma warning disable CS8603 // Possible null reference return.
            return await _db.SitePage
                          .Where(b => b.Id == id)
                          .Include(b => b.Menu).Include(b=>b.SiteActions)
                          .FirstOrDefaultAsync();
        }

        public async Task<SitePage> FindByKey(string sitePageKey)
        {
            return await _db.SitePage
                        .Where(x => x.Key == sitePageKey).Include(b => b.Menu).Include(b => b.SiteActions)
                        .FirstOrDefaultAsync();
        }
        public async Task<Tuple<IList<SitePage>, int>> FindAll(QueryFilter? queryFilter)
        {
            var query = _db.SitePage.Include(b => b.Menu).Include(b => b.SiteActions).AsQueryable();

            query = query.ApplyFiltering(queryFilter);

            var totalRecords = query.Count();

            query = query.ApplyOrdering(queryFilter, "Entity");

            query = query.ApplyPaging(queryFilter);

            return new Tuple<IList<SitePage>, int>(await query.ToListAsync(), totalRecords);
        }
        public async Task Update(SitePage sitepage)
        {
            _db.Entry(sitepage).State = EntityState.Modified;
        }
        public async Task Delete(long id)
        {
            var varSitePage = await FindById(id);
            _db.Entry(varSitePage).State = EntityState.Deleted;
        }
        public async Task DeleteAll(long[] ids)
        {
            var juct = await _db.SitePage.Where(x => ids.Contains(x.Id)).ToListAsync();
            _db.SitePage.RemoveRange(juct);
        }
    }
}
