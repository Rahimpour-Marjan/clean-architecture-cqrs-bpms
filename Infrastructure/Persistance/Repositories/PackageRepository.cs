using Domain;
using Domain.Resources;
using Infrastructure.Persistance.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories
{
    public class PackageRepository : IPackageRepository
    {
        private readonly MakmonDbContext _db;

        public PackageRepository(MakmonDbContext db)
        {
            _db = db;
        }
        public async Task<int> Create(Package package)
        {
            var result = await _db.Packages.AddAsync(package);
            return result.Entity.Id;
        }
        public async Task<Tuple<IList<Package>, int>> FindAll(QueryFilter? queryFilter)
        {
            var query = _db.Packages.AsQueryable();

            query = query.ApplyFiltering(queryFilter);

            var totalRecords = query.Count();

            query = query.ApplyOrdering(queryFilter, "Entity");

            query = query.ApplyPaging(queryFilter);

            return new Tuple<IList<Package>, int>(await query.ToListAsync(), totalRecords);
        }
        public async Task<Package> FindById(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _db.Packages.FindAsync(id);
        }
        public async Task Update(Package model)
        {
            _db.Entry((Package)model).State = EntityState.Modified;
        }
        public async Task Delete(int id)
        {
            var package = await FindById(id);

            _db.Entry(package).State = EntityState.Deleted;
        }
        public async Task DeleteAll(int[] ids)
        {
            var packages = await _db.Packages.Where(x => ids.Contains(x.Id)).ToListAsync();
            _db.Packages.RemoveRange(packages);
        }
    }
}