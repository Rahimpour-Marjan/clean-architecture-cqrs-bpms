using Domain;
using Domain.Common;
using Domain.Resources;
using Infrastructure.Persistance.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories
{
    public class AccountCreditRepository : IAccountCreditRepository
    {
        private readonly MakmonDbContext _db;

        public AccountCreditRepository(MakmonDbContext db)
        {
            _db = db;
        }
        public async Task<int> Create(AccountCredit accountCredit)
        {
            var result = await _db.AccountCredits.AddAsync(accountCredit);
            return result.Entity.Id;
        }
        public async Task<Tuple<IList<AccountCredit>, int>> FindAll(QueryFilter? queryFilter)
        {
            var query = _db.AccountCredits.Include(x=>x.Account).Include(x=>x.AccountCheck).AsQueryable();

            query = query.ApplyFiltering(queryFilter);

            var totalRecords = query.Count();

            query = query.ApplyOrdering(queryFilter, "Entity");

            query = query.ApplyPaging(queryFilter);

            return new Tuple<IList<AccountCredit>, int>(await query.ToListAsync(), totalRecords);
        }
        public async Task<AccountCredit> FindById(int id)
        {
            #pragma warning disable CS8603 // Possible null reference return.
            return await _db.AccountCredits.Include(x => x.Account).Include(x => x.AccountCheck).FirstOrDefaultAsync(x=>x.Id == id);
        }
        public async Task<FilterResponse> FilterAllAccount(int start, int length)
        {
            var q = from a in _db.Accounts
                    join ac in _db.AccountCredits on a.Id equals ac.AccountId
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
        public async Task<FilterResponse> FilterAllAccountCheck(int start, int length)
        {
            var q = from b in _db.AccountChecks
                    join ac in _db.AccountCredits on b.Id equals ac.AccountCheckId
                    select new FilterResponseData
                    {
                        Id = b.Id,
                        Title = b.CheckNumber
                    };
            return new FilterResponse
            {
                Length = length,
                Start = start,
                TotalRecords = q.Distinct().Count(),
                Data = await q.Distinct().Skip((start - 1) * length).Take(length).ToListAsync()
            };
        }
        public async Task Update(AccountCredit model)
        {
            _db.Entry((AccountCredit)model).State = EntityState.Modified;
        }
        public async Task Delete(int id)
        {
            var accountCredit = await FindById(id);

            _db.Entry(accountCredit).State = EntityState.Deleted;
        }
        public async Task DeleteAll(int[] ids)
        {
            var accountCredits = await _db.AccountCredits.Where(x => ids.Contains(x.Id)).ToListAsync();
            _db.AccountCredits.RemoveRange(accountCredits);
        }
    }
}