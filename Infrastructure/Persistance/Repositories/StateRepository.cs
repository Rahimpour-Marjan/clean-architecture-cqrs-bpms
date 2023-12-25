using Domain;
using Domain.Common;
using Domain.Resources;
using Infrastructure.Persistance.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories
{
    public class StateRepository : IStateRepository
    {
        private readonly MakmonDbContext _db;

        public StateRepository(MakmonDbContext db)
        {
            _db = db;
        }
        public async Task<int> Create(State state)
        {
            var result = await _db.States.AddAsync(state);
            return result.Entity.Id;
        }
        public async Task<Tuple<IList<State>, int>> FindAll(QueryFilter? queryFilter)
        {
            var query = _db.States.AsQueryable();

            query = query.ApplyFiltering(queryFilter);

            var totalRecords = query.Count();

            query = query.ApplyOrdering(queryFilter, "Entity");

            query = query.ApplyPaging(queryFilter);

            return new Tuple<IList<State>, int>(await query.ToListAsync(), totalRecords);
        }
        public async Task<State> FindById(int id)
        {
            #pragma warning disable CS8603 // Possible null reference return.
            return await _db.States.FindAsync(id);
        }

        public async Task<FilterResponse> FilterAllCountry(int start, int length)
        {
            var q = from c in _db.Countries
                    join s in _db.States on c.Id equals s.CountryId
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
        public async Task Update(State model)
        {
            _db.Entry((State)model).State = EntityState.Modified;
        }
        public async Task Delete(int id)
        {
            var state = await FindById(id);

            _db.Entry(state).State = EntityState.Deleted;
        }
        public async Task DeleteAll(int[] ids)
        {
            var states = await _db.States.Where(x => ids.Contains(x.Id)).ToListAsync();
            _db.States.RemoveRange(states);
        }
    }
}