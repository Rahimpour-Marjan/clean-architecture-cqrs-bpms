using Domain;
using Domain.Common;
using Domain.Resources;
using Infrastructure.Persistance.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories
{
    public class UserGroupRepository : IUserGroupRepository
    {
        private readonly MakmonDbContext _db;
        public UserGroupRepository(MakmonDbContext db)
        {
            _db = db;
        }
        public async Task<int> Create(UserGroup usergroup)
        {
            var result = await _db.UserGroups.AddAsync(usergroup);
            return result.Entity.Id;
        }
        public async Task<int> Create(UserGroupPrivilage userGroupPrivilage)
        {
            var result = await _db.UserGroupPrivilages.AddAsync(userGroupPrivilage);
            return result.Entity.Id;
        }

        public async Task<UserGroup> FindById(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _db.UserGroups.Include(x => x.UserGroupParent).Include(x => x.PostJuncUserGroups).ThenInclude(x => x.Post).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Tuple<IList<UserGroup>, int>> FindAll(QueryFilter? queryFilter)
        {
            var query = _db.UserGroups.Include(x => x.UserGroupParent).Include(x => x.PostJuncUserGroups).ThenInclude(x => x.Post).AsQueryable();

            query = query.ApplyFiltering(queryFilter);

            var totalRecords = query.Count();

            query = query.ApplyOrdering(queryFilter, "Entity");

            query = query.ApplyPaging(queryFilter);

            return new Tuple<IList<UserGroup>, int>(await query.ToListAsync(), totalRecords);
        }

        public async Task<List<Tree?>> FindAllByUserId(int userId)
        {
            var user = await _db.Users.FirstOrDefaultAsync(x => x.Id == userId);
            var tree = new List<Tree>();
            if (user != null)
            {
                var post = _db.PersonJuncPost.FirstOrDefault(x => x.PersonId == user.PersonId);
                if (post != null)
                {
                    var userGroups = await _db.UserGroups.Where(x => x.PostJuncUserGroups.Any(a => a.PostId == post.PostId)).Include(x => x.UserGroupParent).Include(x => x.PostJuncUserGroups).ThenInclude(x => x.Post).ToListAsync();

                    if (userGroups.Any())
                    {
                        foreach (var item in userGroups)
                        {
                            if (item.UserGroupParentId != null)
                            {
                                var root = await _db.UserGroups.FirstOrDefaultAsync(x => x.Id == item.UserGroupParentId);
                                if (root != null)
                                {
                                    tree.Add(new Tree
                                    {
                                        Id = root.Id,
                                        Title = root.Title,
                                        Type = nameof(UserGroup),
                                        Children = LoadUserGroupChilds(userGroups, root)
                                    });
                                }
                            }
                            else
                            {
                                tree.Add(new Tree
                                {
                                    Id = item.Id,
                                    Title = item.Title,
                                    Type = nameof(UserGroup),
                                    Children = LoadUserGroupChilds(userGroups, item)
                                });
                            }
                        }
                    }
                }
            }

            return tree;
        }

        public async Task<List<AccessTree?>> FindTree(int? userId, int? userGroupId, int? postId, bool? isSelected)
        {
            var menus = await _db.Menu.Include(x => x.SitePages).Include(x => x.Parent).OrderBy(x => x.Priority).ToListAsync();

            int[] userGroupIds = new int[] { };
            if (userId != null)
            {
                var user = await _db.Users.FirstOrDefaultAsync(x => x.Id == userId);
                if (user != null)
                {
                    var person = await _db.Persons.Include(x => x.PersonJuncPosts).FirstOrDefaultAsync(x => x.Id == user.PersonId);
                    if (person != null)
                    {
                        var posts = person.PersonJuncPosts;
                        if (posts != null)
                        {
                            foreach (var subitem in posts)
                            {
                                userGroupIds = await _db.PostJuncUserGroups.Where(x => x.PostId == subitem.PostId).Select(x => x.UserGroupId).ToArrayAsync();
                            }
                        }
                    }
                }
            }
            else if (postId != null)
                userGroupIds = await _db.PostJuncUserGroups.Where(x => x.PostId == postId).Select(x => x.UserGroupId).ToArrayAsync();
            else if (userGroupId != null)
                userGroupIds = new int[] { userGroupId ?? 0 };
            var tree = new List<AccessTree>();
            if (menus.Any())
            {
                var roots = await _db.Menu.Include(x => x.SitePages).Include(x => x.Parent).Where(x => x.ParentId == null).OrderBy(x => x.Priority).ToListAsync();
                if (roots.Any())
                {
                    foreach (var root in roots)
                    {
                        var menuTree = new AccessTree
                        {
                            Id = (int)root.Id,
                            Title = root.Title,
                            Type = nameof(Domain.Menu),
                            Key = root.SitePages.FirstOrDefault() != null ? root.SitePages.FirstOrDefault().Key : "",
                            IsPage = (root.SitePages != null && root.SitePages.Any()) ? true : false,
                            IsSelected = false,
                            Children = LoadChilds(menus, root, userGroupIds, isSelected).Where(x => isSelected == null || x.IsSelected == isSelected).ToList()
                        };
                        var menuIds = menuTree.Children.Select(x => (long)x.Id).ToArray();
                        var isAccess = _db.UserGroupPrivilages.FirstOrDefault(x => (userGroupIds.Any() && userGroupIds.Contains(x.UserGroupId)) && (x.MenuId == root.Id || menuIds.Contains(x.MenuId)));
                        if (isAccess != null || menuTree.Children.Any(x => x.IsSelected == true))
                            menuTree.IsSelected = true;
                        tree.Add(menuTree);
                    }
                }
            }
            return tree.Where(x => isSelected == null || x.IsSelected == isSelected).ToList();
        }

        private List<AccessTree> LoadChilds(List<Domain.Menu> menus, Domain.Menu current, int[] userGroupIds, bool? isSelected)
        {
            var result = new List<AccessTree>();
            var childs = menus.Where(x => x.ParentId == current.Id);
            if (!childs.Any())
            {
                var sitePages = _db.SitePage.Where(x => x.MenuId == current.Id).ToList();
                if (!sitePages.Any())
                    return new List<AccessTree>();
                foreach (var item in sitePages)
                {
                    var siteActions = _db.SiteActions.Where(x => x.SitePageId == item.Id).ToList();
                    var siteActionRoot = siteActions.Where(x => x.ParentId == null).ToList();
                    foreach (var subitem in siteActionRoot)
                    {
                        var isAccess = _db.UserGroupPrivilages.FirstOrDefault(x => (userGroupIds.Any() && userGroupIds.Contains(x.UserGroupId)) && x.SiteActionId == subitem.Id);
                        result.Add(new AccessTree
                        {
                            Id = (int)subitem.Id,
                            Title = subitem.Title,
                            Type = nameof(SiteAction),
                            AccessType = subitem.Action,
                            IsSelected = isAccess == null ? false : true,
                            Children = LoadSiteActionChilds(siteActions, subitem, userGroupIds, isSelected).Where(x => isSelected == null || x.IsSelected == isSelected).ToList()
                        });
                    }
                }
            }
            else
            {
                foreach (var item in childs)
                {
                    var menuTree = new AccessTree
                    {
                        Id = (int)item.Id,
                        Title = item.Title,
                        Type = nameof(Domain.Menu),
                        Key = item.SitePages.FirstOrDefault() != null ? item.SitePages.FirstOrDefault().Key : "",
                        IsSelected = false,
                        IsPage = (item.SitePages != null && item.SitePages.Any()) ? true : false,
                        Children = LoadChilds(menus, item, userGroupIds, isSelected).Where(x => isSelected == null || x.IsSelected == isSelected).ToList()
                    };
                    var menuIds = menuTree.Children.Select(x => (long)x.Id).ToArray();
                    var isAccess = _db.UserGroupPrivilages.FirstOrDefault(x => (userGroupIds.Any() && userGroupIds.Contains(x.UserGroupId)) && (x.MenuId == item.Id || menuIds.Contains(x.MenuId)));
                    if (isAccess != null || menuTree.Children.Any(x => x.IsSelected == true))
                        menuTree.IsSelected = true;
                    result.Add(menuTree);
                }
            }
            return result;
        }
        private List<AccessTree> LoadSiteActionChilds(List<SiteAction> siteActions, SiteAction current, int[] userGroupIds, bool? isSelected)
        {
            var result = new List<AccessTree>();
            var childs = siteActions.Where(x => x.ParentId == current.Id);
            if (!childs.Any())
            {
                return new List<AccessTree>();
            }
            else
            {
                foreach (var item in childs)
                {
                    var isAccess = _db.UserGroupPrivilages.FirstOrDefault(x => (userGroupIds.Any() && userGroupIds.Contains(x.UserGroupId)) && x.SiteActionId == item.Id);
                    result.Add(new AccessTree
                    {
                        Id = (int)item.Id,
                        Title = item.Title,
                        Type = nameof(SiteAction),
                        AccessType = item.Action,
                        IsSelected = isAccess == null ? false : true,
                        Children = LoadSiteActionChilds(siteActions, item, userGroupIds, isSelected).Where(x => isSelected == null || x.IsSelected == isSelected).ToList()
                    });
                }
            }
            return result;
        }
        public async Task<List<Tree?>> FindUserGroupTree()
        {
            var userGroups = await _db.UserGroups.Include(x => x.UserGroupParent).OrderBy(x => x.Id).ToListAsync();
            var tree = new List<Tree>();
            if (userGroups.Any())
            {
                var roots = await _db.UserGroups.Where(x => x.UserGroupParentId == null).ToListAsync();
                if (roots.Any())
                {
                    foreach (var item in roots)
                    {
                        tree.Add(new Tree
                        {
                            Id = item.Id,
                            Title = item.Title,
                            Type = nameof(UserGroup),
                            Children = LoadUserGroupChilds(userGroups, item)
                        });
                    }
                }
            }
            return tree;
        }
        private List<Tree> LoadUserGroupChilds(List<UserGroup> userGroups, UserGroup current)
        {
            var result = new List<Tree>();
            var childs = userGroups.Where(x => x.UserGroupParentId == current.Id);
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
                        Type = nameof(UserGroup),
                        Children = LoadUserGroupChilds(userGroups, item)
                    });
                }
            }
            return result;
        }
        public async Task<FilterResponse> FilterAllPost(int start, int length)
        {
            var q = from t in _db.PostJuncUserGroups
                    join t1 in _db.UserGroups on t.UserGroupId equals t1.Id
                    select new FilterResponseData
                    {
                        Id = t.Post.Id,
                        Title = t.Post.Title
                    };
            return new FilterResponse
            {
                Length = length,
                Start = start,
                TotalRecords = q.Distinct().Count(),
                Data = await q.Distinct().Skip((start - 1) * length).Take(length).ToListAsync()
            };
        }
        public async Task<FilterResponse> FilterAllParent(int start, int length)
        {
            var q = from t in _db.UserGroups
                    join t1 in _db.UserGroups on t.Id equals t1.UserGroupParentId
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
        public async Task Update(UserGroup usergroup)
        {
            _db.Entry(usergroup).State = EntityState.Modified;
        }
        public async Task Delete(int id)
        {
            var usergroup = await FindById(id);
            _db.Entry(usergroup).State = EntityState.Deleted;
        }
        public async Task DeleteAll(int[] ids)
        {
            var result = await _db.UserGroups.Where(x => ids.Contains(x.Id)).ToListAsync();
            _db.UserGroups.RemoveRange(result);
        }
        public async Task DeleteAllPrivilage(int userGroupId)
        {
            var result = await _db.UserGroupPrivilages.Where(x => x.UserGroupId == userGroupId).ToListAsync();
            _db.UserGroupPrivilages.RemoveRange(result);
        }
    }
}
