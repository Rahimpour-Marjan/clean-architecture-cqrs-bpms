using Domain;
using Domain.Resources;
using Infrastructure.Persistance.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly MakmonDbContext _db;
        public MenuRepository(MakmonDbContext db)
        {
            _db = db;
        }
        public async Task<long> Create(Domain.Menu menu)
        {
            var result = _db.Menu.Add(menu);
            return result.Entity.Id;
        }

        public async Task<Domain.Menu> FindById(long id)
        {
            return await _db.Menu.FindAsync(id);
        }
        //public async Task<IList<Menu>> FindAll()
        //{
        //    return await _db.Menu.Include(x => x.SitePages).Include(x => x.SubMenus).OrderBy(x=>x.Priority).ToListAsync();
        //}
        public async Task<List<Domain.Resources.Menu?>> FindAll()
        {
            var menues = await _db.Menu.Include(x => x.SitePages).Include(x => x.SubMenus).Include(x => x.Parent).OrderBy(x => x.Priority).ToListAsync();
            var tree = new List<Domain.Resources.Menu>();
            if (menues.Any())
            {
                var roots = menues.Where(x => x.Parent == null);
                foreach (var item in roots)
                {
                    tree.Add(new Domain.Resources.Menu
                    {
                        Id = item.Id,
                        Title = item.Title,
                        Key = item.SitePages.FirstOrDefault() != null ? item.SitePages.FirstOrDefault().Key : "",
                        IsPage = (item.SitePages != null && item.SitePages.Any()) ? true : false,
                        Children = LoadChilds(menues, item)
                    });
                }
            }
            return tree;
        }

        public async Task<Tuple<IList<Domain.Menu>, int>> FindAll(QueryFilter? queryFilter)
        {
            var query = _db.Menu.Include(x => x.SitePages).Include(x => x.SubMenus).Include(x => x.Parent).OrderBy(x => x.Priority).AsQueryable();

            query = query.ApplyFiltering(queryFilter);

            var totalRecords = query.Count();

            query = query.ApplyOrdering(queryFilter, "Entity");

            query = query.ApplyPaging(queryFilter);

            return new Tuple<IList<Domain.Menu>, int>(await query.ToListAsync(), totalRecords);
        }
        private List<Domain.Resources.Menu> LoadChilds(List<Domain.Menu> menues, Domain.Menu current)
        {
            var result = new List<Domain.Resources.Menu>();
            var childs = menues.Where(x => x.ParentId == current.Id);
            if (!childs.Any())
            {
                return new List<Domain.Resources.Menu>();
            }
            else
            {
                foreach (var item in childs)
                {
                    result.Add(new Domain.Resources.Menu
                    {
                        Id = item.Id,
                        Title = item.Title,
                        Key = item.SitePages.FirstOrDefault() != null ? item.SitePages.FirstOrDefault().Key : "",
                        IsPage = (item.SitePages != null && item.SitePages.Any()) ? true : false,
                        Children = LoadChilds(menues, item)
                    });
                }
            }
            return result;
        }
        public async Task Update(Domain.Menu menu)
        {
            _db.Entry((Domain.Menu)menu).State = EntityState.Modified;
        }
        public async Task Delete(long id)
        {
            var varMenu = await FindById(id);
            _db.Entry((Domain.Menu)varMenu).State = EntityState.Deleted;
        }
        public async Task DeleteAll(long[] ids)
        {
            var juct = _db.Menu.Where(x => ids.Contains(x.Id)).ToList();
            _db.Menu.RemoveRange(juct);
        }
    }
}
