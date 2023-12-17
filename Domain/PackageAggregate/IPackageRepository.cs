using Domain.Resources;

namespace Domain
{
    public interface IPackageRepository
    {
        Task<int> Create(Package package);
        Task Update(Package package);
        Task<Tuple<IList<Package>, int>> FindAll(QueryFilter? queryFilter);
        Task<Package> FindById(int id);
        Task Delete(int id);
        Task DeleteAll(int[] ids);
    }
}
