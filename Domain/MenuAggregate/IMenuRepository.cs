using Domain.Resources;

namespace Domain
{
    public interface IMenuRepository
    {
        Task<long> Create(Menu menu);
        Task<Tuple<IList<Menu>, int>> FindAll(QueryFilter? queryFilter);
        Task<List<Domain.Resources.Menu?>> FindAll();
        Task<Menu> FindById(long id);
        Task Update(Menu menu);
        Task Delete(long id);
        Task DeleteAll(long[] ids);
    }
}
