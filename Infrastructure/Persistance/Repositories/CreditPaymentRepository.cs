using Domain;
using Domain.Common;
using Domain.Resources;
using Infrastructure.Persistance.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories
{
    public class CreditPaymentRepository : ICreditPaymentRepository
    {
        private readonly MakmonDbContext _db;

        public CreditPaymentRepository(MakmonDbContext db)
        {
            _db = db;
        }
        public async Task<int> Create(CreditPayment creditPayment)
        {
            var result = await _db.CreditPayments.AddAsync(creditPayment);
            return result.Entity.Id;
        }
        public async Task<Tuple<IList<CreditPayment>, int>> FindAll(QueryFilter? queryFilter)
        {
            var query = _db.CreditPayments.Include(x => x.Account).Include(x => x.AccountCredit).Include(x => x.CurrencyType).AsQueryable();

            query = query.ApplyFiltering(queryFilter);

            var totalRecords = query.Count();

            query = query.ApplyOrdering(queryFilter, "Entity");

            query = query.ApplyPaging(queryFilter);

            return new Tuple<IList<CreditPayment>, int>(await query.ToListAsync(), totalRecords);
        }
        public async Task<CreditPayment> FindById(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _db.CreditPayments.Include(x => x.Account).Include(x => x.AccountCredit).Include(x => x.CurrencyType).FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<FilterResponse> FilterAllAccount(int start, int length)
        {
            var q = from a in _db.Accounts
                    join c in _db.CreditPayments on a.Id equals c.AccountId
                    select new FilterResponseData
                    {
                        Id = a.Id,
                        Title = a.FirstName + " " + a.LastName
                    };
            return new FilterResponse
            {
                Length = length,
                Start = start,
                TotalRecords = q.Distinct().Count(),
                Data = await q.Distinct().Skip((start - 1) * length).Take(length).ToListAsync()
            };
        }
        public async Task<FilterResponse> FilterAllAccountCredit(int start, int length)
        {
            var q = from a in _db.AccountCredits
                    join c in _db.CreditPayments on a.Id equals c.AccountCreditId
                    select new FilterResponseData
                    {
                        Id = a.Id,
                        Title = a.CreditType.ToString()
                    };
            return new FilterResponse
            {
                Length = length,
                Start = start,
                TotalRecords = q.Distinct().Count(),
                Data = await q.Distinct().Skip((start - 1) * length).Take(length).ToListAsync()
            };
        }
        public async Task<FilterResponse> FilterAllCurrencyType(int start, int length)
        {
            var q = from ct in _db.CurrencyTypes
                    join c in _db.CreditPayments on ct.Id equals c.CurrencyTypeId
                    select new FilterResponseData
                    {
                        Id = ct.Id,
                        Title = ct.Title
                    };
            return new FilterResponse
            {
                Length = length,
                Start = start,
                TotalRecords = q.Distinct().Count(),
                Data = await q.Distinct().Skip((start - 1) * length).Take(length).ToListAsync()
            };
        }
        public async Task Update(CreditPayment model)
        {
            _db.Entry((CreditPayment)model).State = EntityState.Modified;
        }
        public async Task Delete(int id)
        {
            var creditPayment = await FindById(id);

            _db.Entry(creditPayment).State = EntityState.Deleted;
        }
        public async Task DeleteAll(int[] ids)
        {
            var creditPayments = await _db.CreditPayments.Where(x => ids.Contains(x.Id)).ToListAsync();
            _db.CreditPayments.RemoveRange(creditPayments);
        }
    }
}