using Domain;
using Domain.Resources;
using Infrastructure.Persistance.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MakmonDbContext _db;

        public CategoryRepository(MakmonDbContext db)
        {
            _db = db;
        }
        public async Task<int> Create(Category category)
        {
            var result = await _db.Categories.AddAsync(category);
            return result.Entity.Id;
        }
        public async Task<Tuple<IList<Category>, int>> FindAll(QueryFilter? queryFilter)
        {
            var query = _db.Categories.AsQueryable();

            query = query.ApplyFiltering(queryFilter);

            var totalRecords = query.Count();

            query = query.ApplyOrdering(queryFilter, "Entity");

            query = query.ApplyPaging(queryFilter);

            return new Tuple<IList<Category>, int>(await query.ToListAsync(), totalRecords);
        }
        public async Task<Category> FindById(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _db.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(Category model)
        {
            _db.Entry((Category)model).State = EntityState.Modified;
        }
        public async Task Delete(int id)
        {
            var category = await FindById(id);

            _db.Entry(category).State = EntityState.Deleted;
        }
        public async Task DeleteAll(int[] ids)
        {
            var categories = await _db.Categories.Where(x => ids.Contains(x.Id)).ToListAsync();
            _db.Categories.RemoveRange(categories);
        }
    }
}