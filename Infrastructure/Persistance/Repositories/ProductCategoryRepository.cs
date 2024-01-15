using Domain;
using Domain.Common;
using Domain.Resources;
using Infrastructure.Persistance.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly MakmonDbContext _db;

        public ProductCategoryRepository(MakmonDbContext db)
        {
            _db = db;
        }
        public async Task<int> Create(ProductCategory productCategory)
        {
            var result = await _db.ProductCategories.AddAsync(productCategory);
            return result.Entity.Id;
        }
        public async Task<Tuple<IList<ProductCategory>, int>> FindAll(QueryFilter? queryFilter)
        {
            var query = _db.ProductCategories.AsQueryable();

            query = query.ApplyFiltering(queryFilter);

            var totalRecords = query.Count();

            query = query.ApplyOrdering(queryFilter, "Entity");

            query = query.ApplyPaging(queryFilter);

            return new Tuple<IList<ProductCategory>, int>(await query.ToListAsync(), totalRecords);
        }
        public async Task<ProductCategory> FindById(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _db.ProductCategories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<FilterResponse> FilterAllProductCategoryParent(int start, int length)
        {
            var q = from pc in _db.ProductCategories
                    join pc2 in _db.ProductCategories on pc.Id equals pc2.ProductCategoryParentId
                    select new FilterResponseData
                    {
                        Id = pc.Id,
                        Title = pc.Title
                    };
            return new FilterResponse
            {
                Length = length,
                Start = start,
                TotalRecords = q.Distinct().Count(),
                Data = await q.Distinct().Skip((start - 1) * length).Take(length).ToListAsync()
            };
        }

        public async Task Update(ProductCategory model)
        {
            _db.Entry((ProductCategory)model).State = EntityState.Modified;
        }
        public async Task Delete(int id)
        {
            var productCategory = await FindById(id);

            _db.Entry(productCategory).State = EntityState.Deleted;
        }
        public async Task DeleteAll(int[] ids)
        {
            var productCategories = await _db.ProductCategories.Where(x => ids.Contains(x.Id)).ToListAsync();
            _db.ProductCategories.RemoveRange(productCategories);
        }
    }
}