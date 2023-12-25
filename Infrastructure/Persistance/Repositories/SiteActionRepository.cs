using Domain;
using Domain.Resources;
using Infrastructure.Persistance.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories
{
    public class SiteActionRepository : ISiteActionRepository
    {
        private readonly MakmonDbContext _db;

        public SiteActionRepository(MakmonDbContext db)
        {
            _db = db;
        }
        public async Task<int> Create(SiteAction siteAction)
        {
            var result = await _db.SiteActions.AddAsync(siteAction);
            return result.Entity.Id;
        }
        public async Task<Tuple<IList<SiteAction>, int>> FindAll(QueryFilter? queryFilter)
        {
            var query = _db.SiteActions.Include(x => x.SitePage).AsQueryable();

            query = query.ApplyFiltering(queryFilter);

            var totalRecords = query.Count();

            query = query.ApplyOrdering(queryFilter, "Entity");

            query = query.ApplyPaging(queryFilter);

            return new Tuple<IList<SiteAction>, int>(await query.ToListAsync(), totalRecords);
        }

        public async Task<SiteAction> FindById(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _db.SiteActions.Include(x => x.SitePage).FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task Update(SiteAction model)
        {
            var siteAction = await FindById(model.Id);
            siteAction.Controller = model.Controller;
            siteAction.Action = model.Action;
            siteAction.SitePageId = model.SitePageId;
            _db.Entry(siteAction).State = EntityState.Modified;
        }
        public async Task Delete(int id)
        {
            var siteAction = await FindById(id);

            _db.Entry(siteAction).State = EntityState.Deleted;
        }
        public async Task DeleteAll(int[] ids)
        {
            var siteActions = await _db.SiteActions.Where(x => ids.Contains(x.Id)).ToListAsync();
            _db.SiteActions.RemoveRange(siteActions);
        }
    }
}