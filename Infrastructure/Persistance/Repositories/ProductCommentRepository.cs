using Domain;
using Domain.Common;
using Domain.Resources;
using Infrastructure.Persistance.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories
{
    public class ProductCommentRepository : IProductCommentRepository
    {
        private readonly MakmonDbContext _db;

        public ProductCommentRepository(MakmonDbContext db)
        {
            _db = db;
        }
        public async Task<int> Create(ProductComment ProductComment)
        {
            var result = await _db.ProductComments.AddAsync(ProductComment);
            return result.Entity.Id;
        }
        public async Task<Tuple<IList<ProductComment>, int>> FindAll(QueryFilter? queryFilter)
        {
            var query = _db.ProductComments.AsQueryable();

            query = query.ApplyFiltering(queryFilter);

            var totalRecords = query.Count();

            query = query.ApplyOrdering(queryFilter, "Entity");

            query = query.ApplyPaging(queryFilter);

            return new Tuple<IList<ProductComment>, int>(await query.ToListAsync(), totalRecords);
        }
        public async Task<ProductComment> FindById(int id)
        {
            #pragma warning disable CS8603 // Possible null reference return.
            return await _db.ProductComments.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<FilterResponse> FilterAllProduct(int start, int length)
        {
            var q = from pt in _db.Products
                    join pt2 in _db.ProductComments on pt.Id equals pt2.ProductId
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

        public async Task<FilterResponse> FilterAllProductCommentParent(int start, int length)
        {
            var q = from pt in _db.ProductComments
                    join pt2 in _db.ProductComments on pt.Id equals pt2.ProductCommentParentId
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

        public async Task Update(ProductComment model)
        {
            _db.Entry((ProductComment)model).State = EntityState.Modified;
        }
        public async Task Delete(int id)
        {
            var ProductComment = await FindById(id);

            _db.Entry(ProductComment).State = EntityState.Deleted;
        }
        public async Task DeleteAll(int[] ids)
        {
            var ProductComments = await _db.ProductComments.Where(x => ids.Contains(x.Id)).ToListAsync();
            _db.ProductComments.RemoveRange(ProductComments);
        }
    }
}