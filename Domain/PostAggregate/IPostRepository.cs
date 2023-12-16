using Domain.Common;
using Domain.Resources;

namespace Domain
{
    public interface IPostRepository
    {
        Task<int> Create(Post model);
        Task<int> Create(PostJuncUserGroup model);
        Task<Tuple<IList<Post>, int>> FindAll(QueryFilter? queryFilter,int? parenId);
        Task<FilterResponse> FilterAllParent(int start, int length);
        Task<Post> FindById(int id);
        Task Update(Post model);
        Task Delete(int id);
        Task PostJuncUserGroupUpdateAssigned(int id);
        Task<PostJuncUserGroup> FindPostJuncUserGroup(int userGroupId,int postId);
        Task PostDeleteAll(int[] ids);
        Task PostJuncUserGroupDelete(int postId, int[] groupIds);
        Task<List<Tree?>> FindPostTree();
    }
}
