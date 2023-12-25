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
                            .Include(x => x.Account).ThenInclude(x => x.AccountJuncPosts).ThenInclude(x => x.Post)
                            .Where(x => x.UserType != Domain.Enums.UserType.SystemUser)
                            .ToListAsync();
        }
        public async Task<IList<User>> FindAllByPost(int postId)
        {
            return await _db.Users.Include(x => x.Account).ThenInclude(x => x.AccountJuncPosts)
                .ThenInclude(x => x.Post).Where(x => x.Account.AccountJuncPosts.Any(a => a.PostId == postId) && x.UserType != Domain.Enums.UserType.SystemUser).ToListAsync();
        }

        public async Task<IList<User>> FindAllByAccount(int AccountId)
        {
            return await _db.Users.Include(x => x.Account).ThenInclude(x => x.AccountJuncPosts)
                .ThenInclude(x => x.Post).Where(x => x.AccountId == AccountId && x.UserType != Domain.Enums.UserType.SystemUser).ToListAsync();
        }
        public async Task<Tuple<IList<User>, int>> FindAll(QueryFilter? queryFilter)
        {
            var query = _db.Users
                            .Include(x => x.Account).ThenInclude(x => x.AccountJuncPosts).ThenInclude(x => x.Post)
                            .Where(x => x.UserType != Domain.Enums.UserType.SystemUser).AsQueryable();

            query = query.ApplyFiltering(queryFilter);

            var totalRecords = query.Count();

            query = query.ApplyOrdering(queryFilter, "Entity");

            query = query.ApplyPaging(queryFilter);

            return new Tuple<IList<User>, int>(await query.ToListAsync(), totalRecords);
        }
        public async Task<User> FindById(int id)
        {
            var user = await _db.Users.Include(x => x.Account).ThenInclude(x => x.AccountJuncPosts).ThenInclude(x => x.Post).FirstOrDefaultAsync(a => a.Id == id);
            if (user != null)
                return user;
            return null;
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
                var Account = await _db.Accounts.Include(x => x.AccountJuncPosts).FirstOrDefaultAsync(x => x.Id == user.AccountId);
                if (Account != null)
                {
                    var posts = Account.AccountJuncPosts;
                    if (posts != null)
                    {
                        foreach (var subitem in posts)
                        {
                            userGroupIds = await _db.PostJuncUserGroups.Where(x => x.PostId == subitem.PostId).Select(x => x.UserGroupId).ToArrayAsync();
                        }
                    }
                }
            }
            var accessList = await _db.UserGroupPrivilages.Include(x => x.SiteAction).Where(x => userGroupIds.Contains(x.UserGroupId)).Select(x => x.SiteAction).ToListAsync();
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
                            .Include(x => x.Account)
                            .FirstOrDefaultAsync();
        }

        public async Task<User> FindByType(UserType userType)
        {
            return await _db.Users.Include(x => x.Account)
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