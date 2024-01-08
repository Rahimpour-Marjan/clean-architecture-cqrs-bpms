using Domain;
using Domain.Common;
using Domain.Resources;
using Infrastructure.Persistance.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly MakmonDbContext _db;

        public ArticleRepository(MakmonDbContext db)
        {
            _db = db;
        }
        public async Task<int> Create(Article article)
        {
            var result = await _db.Articles.AddAsync(article);
            return result.Entity.Id;
        }
        public async Task<Tuple<IList<Article>, int>> FindAll(QueryFilter? queryFilter)
        {
            var query = _db.Articles.Include(x => x.Category).AsQueryable();

            query = query.ApplyFiltering(queryFilter);

            var totalRecords = query.Count();

            query = query.ApplyOrdering(queryFilter, "Entity");

            query = query.ApplyPaging(queryFilter);

            return new Tuple<IList<Article>, int>(await query.ToListAsync(), totalRecords);
        }
        public async Task<Article> FindById(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _db.Articles.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<FilterResponse> FilterAllCategory(int start, int length)
        {
            var q = from c in _db.Categories
                    join a in _db.Articles on c.Id equals a.CategoryId
                    select new FilterResponseData
                    {
                        Id = c.Id,
                        Title = c.Title
                    };
            return new FilterResponse
            {
                Length = length,
                Start = start,
                TotalRecords = q.Distinct().Count(),
                Data = await q.Distinct().Skip((start - 1) * length).Take(length).ToListAsync()
            };
        }
        public async Task Update(Article model)
        {
            _db.Entry((Article)model).State = EntityState.Modified;
        }
        public async Task Delete(int id)
        {
            var article = await FindById(id);

            _db.Entry(article).State = EntityState.Deleted;
        }
        public async Task DeleteAll(int[] ids)
        {
            var articles = await _db.Articles.Where(x => ids.Contains(x.Id)).ToListAsync();
            _db.Articles.RemoveRange(articles);
        }
    }
}