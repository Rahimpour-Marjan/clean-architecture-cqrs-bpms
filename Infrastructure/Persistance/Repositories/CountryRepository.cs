using Domain;
using Domain.Resources;
using Infrastructure.Persistance.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly MakmonDbContext _db;

        public CountryRepository(MakmonDbContext db)
        {
            _db = db;
        }
        public async Task<int> Create(Country country)
        {
            var result = await _db.Countries.AddAsync(country);
            return result.Entity.Id;
        }
        public async Task<Tuple<IList<Country>, int>> FindAll(QueryFilter? queryFilter)
        {
            var query = _db.Countries.AsQueryable();

            query = query.ApplyFiltering(queryFilter);

            var totalRecords = query.Count();

            query = query.ApplyOrdering(queryFilter, "Entity");

            query = query.ApplyPaging(queryFilter);

            return new Tuple<IList<Country>, int>(await query.ToListAsync(), totalRecords);
        }
        public async Task<Country> FindById(int id)
        {
            #pragma warning disable CS8603 // Possible null reference return.
            return await _db.Countries.FindAsync(id);
        }
        public async Task Update(Country model)
        {
            _db.Entry((Country)model).State = EntityState.Modified;
        }
        public async Task Delete(int id)
        {
            var country = await FindById(id);

            _db.Entry(country).State = EntityState.Deleted;
        }
        public async Task DeleteAll(int[] ids)
        {
            var countries = await _db.Countries.Where(x => ids.Contains(x.Id)).ToListAsync();
            _db.Countries.RemoveRange(countries);
        }
    }
}