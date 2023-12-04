using Domain;
using Domain.Common;
using Domain.Resources;
using Infrastructure.Persistance.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly MakmonDbContext _db;
        public PersonRepository(MakmonDbContext db)
        {
            _db = db;
        }
        public async Task PersonJuncPostCreate(List<int> postIds, int personId)
        {
            foreach (var item in postIds)
            {
                var personJuncPost = new PersonJuncPost(personId, item);
                await _db.PersonJuncPost.AddAsync(personJuncPost);
            }
        }

        public async Task<int> Create(Person person)
        {
            var result = await _db.Persons.AddAsync(person);
            return result.Entity.Id;
        }

        public async Task<Tuple<IList<Person>, int>> FindAll(QueryFilter? queryFilter)
        {
            var query = _db.Persons
                        .Include(d => d.PersonJuncPosts)
                        .ThenInclude(x => x.Post).Where(x=>x.UserType != Domain.Enums.UserType.SystemUser).AsQueryable();

            query = query.ApplyFiltering(queryFilter);

            var totalRecords = query.Count();

            query = query.ApplyOrdering(queryFilter, "Entity");

            query = query.ApplyPaging(queryFilter);


            return new Tuple<IList<Person>, int>(await query.ToListAsync(), totalRecords);
        }
        public async Task<FilterResponse> FilterAllPost(int start, int length)
        {
            var q = from t in _db.PersonJuncPost
                    join t1 in _db.Persons on t.PersonId equals t1.Id
                    join t3 in _db.Posts on t.PostId equals t3.Id
                    select new FilterResponseData
                    {
                        Id = t3.Id,
                        Title = t3.Title
                    };
            return new FilterResponse
            {
                Length = length,
                Start = start,
                TotalRecords = q.Distinct().Count(),
                Data = await q.Distinct().Skip((start - 1) * length).Take(length).ToListAsync()
            };
        }

        public async Task<Person> FindById(int id)
        {
            #pragma warning disable CS8603 // Possible null reference return.
            return await _db.Persons
                        .Include(d => d.PersonJuncPosts)
                        .ThenInclude(x => x.Post)
                        .FirstOrDefaultAsync(t => t.Id == id && t.UserType != Domain.Enums.UserType.SystemUser);
        }
        public async Task<IList<Person>> FindAllByPost(int[] postIds)
        {
            if (postIds.Any())
            {
                return await _db.Persons.Where(x => x.PersonJuncPosts.Any(t => postIds.Contains(t.PostId)))
                           .Include(d => d.PersonJuncPosts)
                           .ThenInclude(x => x.Post).Where(x => x.UserType != Domain.Enums.UserType.SystemUser)
                           .ToListAsync();
            }
            else
            {
                return await _db.Persons
                             .Include(d => d.PersonJuncPosts)
                             .ThenInclude(x => x.Post).Where(x => x.UserType != Domain.Enums.UserType.SystemUser)
                             .ToListAsync();
            }
        }
        public async Task Update(Person person)
        {
            _db.Entry<Person>(person).State = EntityState.Modified;
        }
        public async Task Delete(int id)
        {
            var person = await FindById(id);
            _db.Entry((Person)person).State = EntityState.Deleted;
        }
        public async Task<IList<PersonJuncPost>> PersonJuncPostGet(int personId)
        {
            var result = await (from x in _db.PersonJuncPost
                                where x.PersonId == personId
                                select x).ToListAsync();
            return result;
            //return _db.PersonJuncPost.Where(x => x.PersonId == personId).ToList();
        }
        public async Task PersonJuncPostDelete(int personId)
        {
            var res = await _db.PersonJuncPost.Where(x => x.PersonId == personId).ToListAsync();
            _db.PersonJuncPost.RemoveRange(res);
        }
        public async Task PersonJuncPostCreate(IReadOnlyCollection<PersonJuncPost> model)
        {
            foreach (var item in model)
            {
                await _db.PersonJuncPost.AddAsync(item);
            }
        }
        public async Task PersonDeleteAll(int[] ids)
        {
            var juncRest = await _db.Persons.Where(x => ids.Contains(x.Id) && x.UserType != Domain.Enums.UserType.SystemUser).ToListAsync();
            _db.Persons.RemoveRange(juncRest);
        }
        public async Task PersonJuncPostDeleteAll(int[] ids)
        {
            var juncRest = await _db.PersonJuncPost.Where(x => ids.Contains(x.PersonId)).ToListAsync();
            _db.PersonJuncPost.RemoveRange(juncRest);
        }

        public async Task<bool> IsExistNationCode(string nationalCode)
        {
            return await _db.Persons.AnyAsync(x => x.NationalCode == nationalCode);
        }

        public async Task<bool> IsExistPersonalNumber(string personalNumber)
        {
            return await _db.Persons.AnyAsync(x => x.PersonalNumber == personalNumber);
        }
    }
}
