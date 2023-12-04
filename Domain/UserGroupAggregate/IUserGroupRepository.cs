using Domain.Common;
using Domain.Resources;

namespace Domain
{
    public interface IUserGroupRepository
    {
        Task<int> Create(UserGroup usergroup);
        Task<int> Create(UserGroupPrivilage userGroupPrivilage);
        Task<Tuple<IList<UserGroup>, int>> FindAll(QueryFilter? queryFilter);
        Task<List<Tree?>> FindAllByUserId(int userId);
        Task<FilterResponse> FilterAllParent(int start, int length);
        Task<FilterResponse> FilterAllPost(int start, int length);
        Task<List<AccessTree?>> FindTree(int? userId,int? userGroupId, int? postId, bool? isSelected);
        Task<List<Tree?>> FindUserGroupTree();
        Task<UserGroup> FindById(int id);
        Task<UserGroup> FindByResultCode(int resultCode);
        Task Update(UserGroup usergroup);
        Task Delete(int id);
        Task DeleteAll(int[] ids);
        Task DeleteAllPrivilage(int userGroupId);
    }
}
