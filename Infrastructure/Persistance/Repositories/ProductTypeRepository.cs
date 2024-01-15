using Domain;
using Domain.Common;
using Domain.Resources;
using Infrastructure.Persistance.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly MakmonDbContext _db;

        public ProductTypeRepository(MakmonDbContext db)
        {
            _db = db;
        }
        public async Task<int> Create(ProductType productType)
        {
            var result = await _db.ProductTypes.AddAsync(productType);
            return result.Entity.Id;
        }
        public async Task<Tuple<IList<ProductType>, int>> FindAll(QueryFilter? queryFilter)
        {
            var query = _db.ProductTypes.AsQueryable();

            query = query.ApplyFiltering(queryFilter);

            var totalRecords = query.Count();

            query = query.ApplyOrdering(queryFilter, "Entity");

            query = query.ApplyPaging(queryFilter);

            return new Tuple<IList<ProductType>, int>(await query.ToListAsync(), totalRecords);
        }
        public async Task<ProductType> FindById(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _db.ProductTypes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<FilterResponse> FilterAllProductTypeParent(int start, int length)
        {
            var q = from pt in _db.ProductTypes
                    join pt2 in _db.ProductTypes on pt.Id equals pt2.ProductTypeParentId
                    select new FilterResponseData
                    {
                        Id = pt.Id,
                        Title = pt.Title
                    };
            return new FilterResponse
            {
                Length = length,
                Start = start,
                TotalRecords = q.Distinct().Count(),
                Data = await q.Distinct().Skip((start - 1) * length).Take(length).ToListAsync()
            };
        }

        public async Task Update(ProductType model)
        {
            _db.Entry((ProductType)model).State = EntityState.Modified;
        }
        public async Task Delete(int id)
        {
            var productType = await FindById(id);

            _db.Entry(productType).State = EntityState.Deleted;
        }
        public async Task DeleteAll(int[] ids)
        {
            var productTypes = await _db.ProductTypes.Where(x => ids.Contains(x.Id)).ToListAsync();
            _db.ProductTypes.RemoveRange(productTypes);
        }
    }
}