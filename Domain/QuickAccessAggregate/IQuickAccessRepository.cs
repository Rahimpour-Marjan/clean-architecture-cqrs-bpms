using Domain.Resources;

namespace Domain
{
    public interface IQuickAccessRepository
    {
        Task<int> Create(QuickAccess model);
        Task<Tuple<IList<QuickAccess>, int>> FindAll(QueryFilter? queryFilter, int userId);
        Task<QuickAccess?> FindById(int id, int userId);
        Task<QuickAccess?> FindWithParam(int userId, long pageId);
        Task Update(QuickAccess model);

        Task Delete(string key, int userId);
        Task DeleteAll(string[] keys, int userId);
        Task<QuickAccess?> FindByKey(string key, int userId);
        Task<List<QuickAccess?>> FindByUserId(int userId);
    }
}