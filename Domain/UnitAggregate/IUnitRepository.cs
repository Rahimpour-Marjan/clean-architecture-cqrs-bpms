using Domain.Resources;

namespace Domain
{
    public interface IUnitRepository
    {
        Task<int> Create(Unit unit);
        Task Update(Unit unit);
        Task<Tuple<IList<Unit>, int>> FindAll(QueryFilter? queryFilter);
        Task<Unit> FindById(int id);
        Task Delete(int id);
        Task DeleteAll(int[] ids);
    }
}
