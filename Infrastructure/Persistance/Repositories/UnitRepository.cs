using Domain;
using Domain.Resources;
using Infrastructure.Persistance.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories
{
    public class UnitRepository : IUnitRepository
    {
        private readonly MakmonDbContext _db;

        public UnitRepository(MakmonDbContext db)
        {
            _db = db;
        }
        public async Task<int> Create(Unit unit)
        {
            var result = await _db.Units.AddAsync(unit);
            return result.Entity.Id;
        }
        public async Task<Tuple<IList<Unit>, int>> FindAll(QueryFilter? queryFilter)
        {
            var query = _db.Units.AsQueryable();

            query = query.ApplyFiltering(queryFilter);

            var totalRecords = query.Count();

            query = query.ApplyOrdering(queryFilter, "Entity");

            query = query.ApplyPaging(queryFilter);

            return new Tuple<IList<Unit>, int>(await query.ToListAsync(), totalRecords);
        }
        public async Task<Unit> FindById(int id)
        {
            #pragma warning disable CS8603 // Possible null reference return.
            return await _db.Units.FindAsync(id);
        }
        public async Task Update(Unit model)
        {
            var unit = await FindById(model.Id);
            unit.Title = model.Title;
            unit.AbbreviatedTitle = model.AbbreviatedTitle;
            unit.Title = model.Title;

            _db.Entry(unit).State = EntityState.Modified;
        }
        public async Task Delete(int id)
        {
            var unit = await FindById(id);

            _db.Entry(unit).State = EntityState.Deleted;
        }
        public async Task DeleteAll(int[] ids)
        {
            var units = await _db.Units.Where(x => ids.Contains(x.Id)).ToListAsync();
            _db.Units.RemoveRange(units);
        }
    }
}