using Domain;
using Domain.Common;
using Domain.Resources;
using Infrastructure.Persistance.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MakmonDbContext _db;

        public ProductRepository(MakmonDbContext db)
        {
            _db = db;
        }
        public async Task<int> Create(Product product)
        {
            var result = await _db.Products.AddAsync(product);
            return result.Entity.Id;
        }
        public async Task<Tuple<IList<Product>, int>> FindAll(QueryFilter? queryFilter)
        {
            var query = _db.Products.AsQueryable();

            query = query.ApplyFiltering(queryFilter);

            var totalRecords = query.Count();

            query = query.ApplyOrdering(queryFilter, "Entity");

            query = query.ApplyPaging(queryFilter);

            return new Tuple<IList<Product>, int>(await query.ToListAsync(), totalRecords);
        }
        public async Task<Product> FindById(int id)
        {
            #pragma warning disable CS8603 // Possible null reference return.
            return await _db.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<FilterResponse> FilterAllProductType(int start, int length)
        {
            var q = from pt in _db.ProductTypes
                    join pt2 in _db.Products on pt.Id equals pt2.ProductTypeId
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

        public async Task<FilterResponse> FilterAllProductCategory(int start, int length)
        {
            var q = from pt in _db.ProductCategories
                    join pt2 in _db.Products on pt.Id equals pt2.ProductCategoryId
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

        public async Task<FilterResponse> FilterAllProductBrand(int start, int length)
        {
            var q = from pt in _db.ProductBrands
                    join pt2 in _db.Products on pt.Id equals pt2.ProductBrandId
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

        public async Task Update(Product model)
        {
            _db.Entry((Product)model).State = EntityState.Modified;
        }
        public async Task Delete(int id)
        {
            var product = await FindById(id);

            _db.Entry(product).State = EntityState.Deleted;
        }
        public async Task DeleteAll(int[] ids)
        {
            var products = await _db.Products.Where(x => ids.Contains(x.Id)).ToListAsync();
            _db.Products.RemoveRange(products);
        }
    }
}