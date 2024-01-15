using Domain;
using Domain.Common;
using Domain.Resources;
using Infrastructure.Persistance.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories
{
    public class ProductBrandRepository : IProductBrandRepository
    {
        private readonly MakmonDbContext _db;

        public ProductBrandRepository(MakmonDbContext db)
        {
            _db = db;
        }
        public async Task<int> Create(ProductBrand productBrand)
        {
            var result = await _db.ProductBrands.AddAsync(productBrand);
            return result.Entity.Id;
        }
        public async Task<Tuple<IList<ProductBrand>, int>> FindAll(QueryFilter? queryFilter)
        {
            var query = _db.ProductBrands.AsQueryable();

            query = query.ApplyFiltering(queryFilter);

            var totalRecords = query.Count();

            query = query.ApplyOrdering(queryFilter, "Entity");

            query = query.ApplyPaging(queryFilter);

            return new Tuple<IList<ProductBrand>, int>(await query.ToListAsync(), totalRecords);
        }
        public async Task<ProductBrand> FindById(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _db.ProductBrands.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<FilterResponse> FilterAllProductType(int start, int length)
        {
            var q = from pt in _db.ProductTypes
                    join pb in _db.ProductBrands on pt.Id equals pb.ProductTypeId
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

        public async Task Update(ProductBrand model)
        {
            _db.Entry((ProductBrand)model).State = EntityState.Modified;
        }
        public async Task Delete(int id)
        {
            var productBrand = await FindById(id);

            _db.Entry(productBrand).State = EntityState.Deleted;
        }
        public async Task DeleteAll(int[] ids)
        {
            var productBrands = await _db.ProductBrands.Where(x => ids.Contains(x.Id)).ToListAsync();
            _db.ProductBrands.RemoveRange(productBrands);
        }
    }
}