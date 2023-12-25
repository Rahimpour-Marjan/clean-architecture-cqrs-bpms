using Domain;
using Domain.Common;
using Domain.Resources;
using Infrastructure.Persistance.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly MakmonDbContext _db;

        public CityRepository(MakmonDbContext db)
        {
            _db = db;
        }
        public async Task<int> Create(City city)
        {
            var result = await _db.Cities.AddAsync(city);
            return result.Entity.Id;
        }
        public async Task<Tuple<IList<City>, int>> FindAll(QueryFilter? queryFilter)
        {
            var query = _db.Cities.Include(x=>x.State).ThenInclude(x=>x.Country).AsQueryable();

            query = query.ApplyFiltering(queryFilter);

            var totalRecords = query.Count();

            query = query.ApplyOrdering(queryFilter, "Entity");

            query = query.ApplyPaging(queryFilter);

            return new Tuple<IList<City>, int>(await query.ToListAsync(), totalRecords);
        }
        public async Task<City> FindById(int id)
        {
            #pragma warning disable CS8603 // Possible null reference return.
            return await _db.Cities.Include(x => x.State).ThenInclude(x => x.Country).FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<FilterResponse> FilterAllState(int start, int length)
        {
            var q = from c in _db.States
                    join s in _db.Cities on c.Id equals s.StateId
                    select new FilterResponseData
                    {
                        Id = c.Id,
                        Title = c.Title
                    };
            return new FilterResponse
            {
                Length = length,
                Start = start,
                TotalRecords = q.Distinct().Count(),
                Data = await q.Distinct().Skip((start - 1) * length).Take(length).ToListAsync()
            };
        }
        public async Task Update(City model)
        {
            _db.Entry((City)model).State = EntityState.Modified;
        }
        public async Task Delete(int id)
        {
            var city = await FindById(id);

            _db.Entry(city).State = EntityState.Deleted;
        }
        public async Task DeleteAll(int[] ids)
        {
            var cities = await _db.Cities.Where(x => ids.Contains(x.Id)).ToListAsync();
            _db.Cities.RemoveRange(cities);
        }
    }
}