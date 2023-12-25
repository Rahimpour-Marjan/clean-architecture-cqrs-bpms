using Domain;
using Domain.Resources;
using Infrastructure.Persistance.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories
{
    public class BankRepository : IBankRepository
    {
        private readonly MakmonDbContext _db;

        public BankRepository(MakmonDbContext db)
        {
            _db = db;
        }
        public async Task<int> Create(Bank bank)
        {
            var result = await _db.Banks.AddAsync(bank);
            return result.Entity.Id;
        }
        public async Task<Tuple<IList<Bank>, int>> FindAll(QueryFilter? queryFilter)
        {
            var query = _db.Banks.AsQueryable();

            query = query.ApplyFiltering(queryFilter);

            var totalRecords = query.Count();

            query = query.ApplyOrdering(queryFilter, "Entity");

            query = query.ApplyPaging(queryFilter);

            return new Tuple<IList<Bank>, int>(await query.ToListAsync(), totalRecords);
        }
        public async Task<Bank> FindById(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _db.Banks.FindAsync(id);
        }
        public async Task Update(Bank model)
        {
            _db.Entry((Bank)model).State = EntityState.Modified;
        }
        public async Task Delete(int id)
        {
            var bank = await FindById(id);

            _db.Entry(bank).State = EntityState.Deleted;
        }
        public async Task DeleteAll(int[] ids)
        {
            var banks = await _db.Banks.Where(x => ids.Contains(x.Id)).ToListAsync();
            _db.Banks.RemoveRange(banks);
        }
    }
}