using Domain;
using Domain.Common;
using Domain.Resources;
using Infrastructure.Persistance.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly MakmonDbContext _db;
        public PostRepository(MakmonDbContext db)
        {
            _db = db;
        }
        public async Task<int> Create(Post post)
        {
            var result = await _db.Posts.AddAsync(post);
            return result.Entity.Id;
        }
        public async Task<Tuple<IList<Post>, int>> FindAll(QueryFilter? queryFilter, int? parenId)
        {
            var query = _db.Posts.Where(x => parenId == null || x.ParentId == parenId)
                         .Include(y => y.Parent).AsQueryable();


            query = query.ApplyFiltering(queryFilter);

            var totalRecords = query.Count();

            query = query.ApplyOrdering(queryFilter, "Entity");

            query = query.ApplyPaging(queryFilter);

            return new Tuple<IList<Post>, int>(await query.ToListAsync(), totalRecords);
        }

        public async Task<FilterResponse> FilterAllParent(int start, int length)
        {
            var q = from t in _db.Posts
                    join t1 in _db.Posts on t.Id equals t1.ParentId
                    select new FilterResponseData
                    {
                        Id = t.Id,
                        Title = t.Title
                    };
            return new FilterResponse
            {
                Length = length,
                Start = start,
                TotalRecords = q.Distinct().Count(),
                Data = await q.Distinct().Skip((start - 1) * length).Take(length).ToListAsync()
            };
        }
        
        public async Task<Post> FindById(int id)
        {
            #pragma warning disable CS8603 // Possible null reference return.
            return await _db.Posts
                            .Include(a => a.Parent)
                            .FirstOrDefaultAsync(c => c.Id == id);
        }
    
        public async Task Update(Post model)
        {
            _db.Entry((Post)model).State = EntityState.Modified;
        }
        public async Task Delete(int id)
        {
            var post = await FindById(id);
            _db.Entry(post).State = EntityState.Deleted;
        } 
        public async Task PostJuncUserGroupUpdateAssigned(int id)
        {
            var model= await _db.PostJuncUserGroups.FirstOrDefaultAsync(x => x.Id == id);
            if (model != null)
            {
                model.Assigned = true;
                _db.Entry(model).State = EntityState.Modified;
            }
        }     
        
        public async Task<PostJuncUserGroup> FindPostJuncUserGroup(int userGroupId, int postId)
        {
            return await _db.PostJuncUserGroups.FirstOrDefaultAsync(x => x.UserGroupId == userGroupId && x.PostId == postId);
        }   

        public async Task PostJuncUserGroupDelete(int postId,int[] userGroupIds)
        {
            var postJuncUserGroups = await _db.PostJuncUserGroups.Where(x => x.PostId == postId && userGroupIds.Contains(x.UserGroupId)).ToListAsync();
            if (postJuncUserGroups != null)
                _db.PostJuncUserGroups.RemoveRange(postJuncUserGroups);
        }
        public async Task PostDeleteAll(int[] ids)
        {
            var juncRest = await _db.Posts.Where(x => ids.Contains(x.Id)).ToListAsync();
            _db.Posts.RemoveRange(juncRest);
        }
        public async Task<int> Create(PostJuncUserGroup model)
        {
            var result = await _db.PostJuncUserGroups.AddAsync(model);
            return result.Entity.Id;
        }

        public async Task<List<Tree?>> FindPostTree()
        {
            var posts = await _db.Posts.Include(x => x.Parent).ToListAsync();
            var tree = new List<Tree>();
            if (posts.Any())
            {
                var roots = posts.Where(x => x.Parent == null);
                foreach (var item in roots)
                {
                    tree.Add(new Tree
                    {
                        Id = item.Id,
                        Title = item.Title,
                        Type = nameof(Post),
                        Children = LoadChilds(posts, item)
                    });
                }
            }
            return tree;
        }

        private List<Tree> LoadChilds(List<Post> biUnits, Post current)
        {
            var result = new List<Tree>();
            var childs = biUnits.Where(x => x.ParentId == current.Id);
            if (!childs.Any())
            {
                return new List<Tree>();
            }
            else
            {
                foreach (var item in childs)
                {
                    result.Add(new Tree
                    {
                        Id = item.Id,
                        Title = item.Title,
                        Type = nameof(Post),
                        Children = LoadChilds(biUnits, item)
                    });
                }
            }
            return result;
        }
    }
}
