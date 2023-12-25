using Domain;
using Domain.Common;
using Domain.Resources;
using Infrastructure.Persistance.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories
{
    public class AccountCheckRepository : IAccountCheckRepository
    {
        private readonly MakmonDbContext _db;

        public AccountCheckRepository(MakmonDbContext db)
        {
            _db = db;
        }
        public async Task<int> Create(AccountCheck accountCheck)
        {
            var result = await _db.AccountChecks.AddAsync(accountCheck);
            return result.Entity.Id;
        }
        public async Task<Tuple<IList<AccountCheck>, int>> FindAll(QueryFilter? queryFilter)
        {
            var query = _db.AccountChecks.Include(x=>x.Account).Include(x=>x.Bank).AsQueryable();

            query = query.ApplyFiltering(queryFilter);

            var totalRecords = query.Count();

            query = query.ApplyOrdering(queryFilter, "Entity");

            query = query.ApplyPaging(queryFilter);

            return new Tuple<IList<AccountCheck>, int>(await query.ToListAsync(), totalRecords);
        }
        public async Task<AccountCheck> FindById(int id)
        {
            #pragma warning disable CS8603 // Possible null reference return.
            return await _db.AccountChecks.Include(x => x.Account).Include(x => x.Bank).FirstOrDefaultAsync(x=>x.Id == id);
        }
        public async Task<FilterResponse> FilterAllAccount(int start, int length)
        {
            var q = from a in _db.Accounts
                    join ac in _db.AccountChecks on a.Id equals ac.AccountId
                    select new FilterResponseData
                    {
                        Id = a.Id,
                        Title = a.FirstName + " " + a.LastName,
                    };
            return new FilterResponse
            {
                Length = length,
                Start = start,
                TotalRecords = q.Distinct().Count(),
                Data = await q.Distinct().Skip((start - 1) * length).Take(length).ToListAsync()
            };
        }
        public async Task<FilterResponse> FilterAllBank(int start, int length)
        {
            var q = from b in _db.Banks
                    join ac in _db.AccountChecks on b.Id equals ac.BankId
                    select new FilterResponseData
                    {
                        Id = b.Id,
                        Title = b.Title
                    };
            return new FilterResponse
            {
                Length = length,
                Start = start,
                TotalRecords = q.Distinct().Count(),
                Data = await q.Distinct().Skip((start - 1) * length).Take(length).ToListAsync()
            };
        }
        public async Task Update(AccountCheck model)
        {
            _db.Entry((AccountCheck)model).State = EntityState.Modified;
        }
        public async Task Delete(int id)
        {
            var accountCheck = await FindById(id);

            _db.Entry(accountCheck).State = EntityState.Deleted;
        }
        public async Task DeleteAll(int[] ids)
        {
            var accountChecks = await _db.AccountChecks.Where(x => ids.Contains(x.Id)).ToListAsync();
            _db.AccountChecks.RemoveRange(accountChecks);
        }
    }
}