using Domain;
using Domain.Resources;
using Infrastructure.Persistance.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories
{
    public class CurrencyTypeRepository : ICurrencyTypeRepository
    {
        private readonly MakmonDbContext _db;

        public CurrencyTypeRepository(MakmonDbContext db)
        {
            _db = db;
        }
        public async Task<int> Create(CurrencyType currencyType)
        {
            var result = await _db.CurrencyTypes.AddAsync(currencyType);
            return result.Entity.Id;
        }
        public async Task<Tuple<IList<CurrencyType>, int>> FindAll(QueryFilter? queryFilter)
        {
            var query = _db.CurrencyTypes.AsQueryable();

            query = query.ApplyFiltering(queryFilter);

            var totalRecords = query.Count();

            query = query.ApplyOrdering(queryFilter, "Entity");

            query = query.ApplyPaging(queryFilter);

            return new Tuple<IList<CurrencyType>, int>(await query.ToListAsync(), totalRecords);
        }
        public async Task<CurrencyType> FindById(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _db.CurrencyTypes.FindAsync(id);
        }
        public async Task Update(CurrencyType model)
        {
            _db.Entry((CurrencyType)model).State = EntityState.Modified;
        }
        public async Task Delete(int id)
        {
            var currencyType = await FindById(id);

            _db.Entry(currencyType).State = EntityState.Deleted;
        }
        public async Task DeleteAll(int[] ids)
        {
            var currencyTypes = await _db.CurrencyTypes.Where(x => ids.Contains(x.Id)).ToListAsync();
            _db.CurrencyTypes.RemoveRange(currencyTypes);
        }
    }
}