using Domain;
using Domain.Enums;
using Domain.Resources;
using Infrastructure.Persistance.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MakmonDbContext _db;

        public UserRepository(MakmonDbContext db)
        {
            _db = db;
        }
        public async Task<int> Create(User user)
        {
            var result = await _db.Users.AddAsync(user);
            return result.Entity.Id;
        }
        public async Task<IList<User>> FindAll()
        {
            return await _db.Users
                            .Include(x => x.Person).ThenInclude(x => x.PersonJuncPosts).ThenInclude(x => x.Post)
                            .Where(x => x.UserType != Domain.Enums.UserType.SystemUser)
                            .ToListAsync();
        }
        public async Task<IList<User>> FindAllByPost(int postId)
        {
            return await _db.Users.Include(x => x.Person).ThenInclude(x => x.PersonJuncPosts)
                .ThenInclude(x => x.Post).Where(x => x.Person.PersonJuncPosts.Any(a => a.PostId == postId) && x.UserType != Domain.Enums.UserType.SystemUser).ToListAsync();
        }

        public async Task<IList<User>> FindAllByPerson(int personId)
        {
            return await _db.Users.Include(x => x.Person).ThenInclude(x => x.PersonJuncPosts)
                .ThenInclude(x => x.Post).Where(x => x.PersonId == personId && x.UserType != Domain.Enums.UserType.SystemUser).ToListAsync();
        }
        public async Task<Tuple<IList<User>, int>> FindAll(QueryFilter? queryFilter)
        {
            var query = _db.Users
                            .Include(x => x.Person).ThenInclude(x => x.PersonJuncPosts).ThenInclude(x => x.Post)
                            .Where(x => x.UserType != Domain.Enums.UserType.SystemUser).AsQueryable();

            query = query.ApplyFiltering(queryFilter);

            var totalRecords = query.Count();

            query = query.ApplyOrdering(queryFilter, "Entity");

            query = query.ApplyPaging(queryFilter);

            return new Tuple<IList<User>, int>(await query.ToListAsync(), totalRecords);
        }
        public async Task<IList<User>> FindAllForBizaji()
        {
            return await _db.Users
                            .Where(x => x.ApiResultCode == null)
                            .ToListAsync();
        }

        public async Task<User> FindById(int id)
        {
            var user = await _db.Users.Include(x => x.Person).ThenInclude(x => x.PersonJuncPosts).ThenInclude(x => x.Post).FirstOrDefaultAsync(a => a.Id == id);
            if (user != null)
                return user;
            return null;
        }

        public async Task<User> FindByApiResultCode(int apiResultCode)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _db.Users
                            .Include(x => x.Person)
                            .FirstOrDefaultAsync(a => a.ApiResultCode == apiResultCode);
        }

        public async Task<User> FindByAuthInfo(string userName, string password)
        {
            return await _db.Users.Where(x => x.UserName == userName && x.Password == password && x.UserType != Domain.Enums.UserType.SystemUser).FirstOrDefaultAsync();
        }

        public async Task<List<SiteAction>?> FindAccess(int userId)
        {
            int[] userGroupIds = new int[] { };
            var user = await _db.Users.FirstOrDefaultAsync(x => x.Id == userId);
            if (user != null)
            {
                var person = await _db.Persons.Include(x => x.PersonJuncPosts).FirstOrDefaultAsync(x => x.Id == user.PersonId);
                if (person != null)
                {
                    var posts = person.PersonJuncPosts;
                    if (posts != null)
                    {
                        foreach (var subitem in posts)
                        {
                            userGroupIds = await _db.PostJuncUserGroups.Where(x => x.PostId == subitem.PostId).Select(x => x.UserGroupId).ToArrayAsync();
                        }
                    }
                }
            }
            var accessList = await _db.UserGroupPrivilages.Include(x=>x.SiteAction).Where(x => userGroupIds.Contains(x.UserGroupId)).Select(x=>x.SiteAction).ToListAsync();
            return accessList;
        }
        public async Task Update(User user)
        {
            _db.Entry(user).State = EntityState.Modified;
        }
        public async Task<User> FindByUserName(string userName)
        {
            return await _db.Users
                            .Where(x => x.UserName == userName && x.UserType != Domain.Enums.UserType.SystemUser)
                            .Include(x => x.Person)
                            .FirstOrDefaultAsync();
        }

        public async Task<User> FindByType(UserType userType)
        {
            return await _db.Users.Include(x => x.Person)
                            .FirstOrDefaultAsync(x => x.UserType == userType);
        }

        public async Task Delete(int id)
        {
            var store = await FindById(id);
            _db.Entry(store).State = EntityState.Deleted;
        }
        public async Task DeleteAll(int[] ids)
        {
            var store = await _db.Users.Where(x => ids.Contains(x.Id) && x.UserType != Domain.Enums.UserType.SystemUser).ToListAsync();
            _db.Users.RemoveRange(store);
        }
    }
}