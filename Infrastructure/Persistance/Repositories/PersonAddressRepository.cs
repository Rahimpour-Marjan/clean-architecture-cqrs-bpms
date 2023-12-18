using Domain;
using Domain.Common;
using Domain.Resources;
using Infrastructure.Persistance.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories
{
    public class PersonAddressRepository : IPersonAddressRepository
    {
        private readonly MakmonDbContext _db;

        public PersonAddressRepository(MakmonDbContext db)
        {
            _db = db;
        }
        public async Task<int> Create(PersonAddress personAddress)
        {
            var result = await _db.PersonAddresses.AddAsync(personAddress);
            return result.Entity.Id;
        }
        public async Task<Tuple<IList<PersonAddress>, int>> FindAll(QueryFilter? queryFilter)
        {
            var query = _db.PersonAddresses.AsQueryable();

            query = query.ApplyFiltering(queryFilter);

            var totalRecords = query.Count();

            query = query.ApplyOrdering(queryFilter, "Entity");

            query = query.ApplyPaging(queryFilter);

            return new Tuple<IList<PersonAddress>, int>(await query.ToListAsync(), totalRecords);
        }
        public async Task<PersonAddress> FindById(int id)
        {
            #pragma warning disable CS8603 // Possible null reference return.
            return await _db.PersonAddresses.FindAsync(id);
        }

        public async Task<FilterResponse> FilterAllPerson(int start, int length)
        {
            var q = from p in _db.Persons
                    join pa in _db.PersonAddresses on p.Id equals pa.PersonId
                    select new FilterResponseData
                    {
                        Id = p.Id,
                        Title = p.FirstName + " " + p.LastName,
                    };
            return new FilterResponse
            {
                Length = length,
                Start = start,
                TotalRecords = q.Distinct().Count(),
                Data = await q.Distinct().Skip((start - 1) * length).Take(length).ToListAsync()
            };
        }

        public async Task<FilterResponse> FilterAllCountry(int start, int length)
        {
            var q = from c in _db.Countries
                    join pa in _db.PersonAddresses on c.Id equals pa.CountryId
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
        public async Task<FilterResponse> FilterAllState(int start, int length)
        {
            var q = from st in _db.States
                    join pa in _db.PersonAddresses on st.Id equals pa.StateId
                    select new FilterResponseData
                    {
                        Id = st.Id,
                        Title = st.Title
                    };
            return new FilterResponse
            {
                Length = length,
                Start = start,
                TotalRecords = q.Distinct().Count(),
                Data = await q.Distinct().Skip((start - 1) * length).Take(length).ToListAsync()
            };
        }

        public async Task<FilterResponse> FilterAllCity(int start, int length)
        {
            var q = from c in _db.Cities
                    join pa in _db.PersonAddresses on c.Id equals pa.CityId
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

        public async Task<FilterResponse> FilterAllZone(int start, int length)
        {
            var q = from z in _db.Zones
                    join pa in _db.PersonAddresses on z.Id equals pa.ZoneId
                    select new FilterResponseData
                    {
                        Id = z.Id,
                        Title = z.Title
                    };
            return new FilterResponse
            {
                Length = length,
                Start = start,
                TotalRecords = q.Distinct().Count(),
                Data = await q.Distinct().Skip((start - 1) * length).Take(length).ToListAsync()
            };
        }
        public async Task Update(PersonAddress model)
        {
            _db.Entry((PersonAddress)model).State = EntityState.Modified;
        }
        public async Task Delete(int id)
        {
            var personAddress = await FindById(id);

            _db.Entry(personAddress).State = EntityState.Deleted;
        }
        public async Task DeleteAll(int[] ids)
        {
            var personAddresses = await _db.PersonAddresses.Where(x => ids.Contains(x.Id)).ToListAsync();
            _db.PersonAddresses.RemoveRange(personAddresses);
        }
    }
}