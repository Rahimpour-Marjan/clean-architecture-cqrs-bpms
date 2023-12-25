using Domain;
using Domain.Common;
using Domain.Resources;
using Infrastructure.Persistance.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories
{
    public class ZoneRepository : IZoneRepository
    {
        private readonly MakmonDbContext _db;

        public ZoneRepository(MakmonDbContext db)
        {
            _db = db;
        }
        public async Task<int> Create(Zone zone)
        {
            var result = await _db.Zones.AddAsync(zone);
            return result.Entity.Id;
        }
        public async Task<Tuple<IList<Zone>, int>> FindAll(QueryFilter? queryFilter)
        {
            var query = _db.Zones.Include(x => x.City).ThenInclude(x => x.State).ThenInclude(x => x.Country).AsQueryable();

            query = query.ApplyFiltering(queryFilter);

            var totalRecords = query.Count();

            query = query.ApplyOrdering(queryFilter, "Entity");

            query = query.ApplyPaging(queryFilter);

            return new Tuple<IList<Zone>, int>(await query.ToListAsync(), totalRecords);
        }
        public async Task<Zone> FindById(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _db.Zones.Include(x => x.City).ThenInclude(x => x.State).ThenInclude(x => x.Country).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<FilterResponse> FilterAllCity(int start, int length)
        {
            var q = from c in _db.Cities
                    join s in _db.Zones on c.Id equals s.CityId
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
        public async Task Update(Zone model)
        {
            _db.Entry((Zone)model).State = EntityState.Modified;
        }
        public async Task Delete(int id)
        {
            var zone = await FindById(id);

            _db.Entry(zone).State = EntityState.Deleted;
        }
        public async Task DeleteAll(int[] ids)
        {
            var zones = await _db.Zones.Where(x => ids.Contains(x.Id)).ToListAsync();
            _db.Zones.RemoveRange(zones);
        }
    }
}