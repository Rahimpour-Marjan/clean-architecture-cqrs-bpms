using Domain.Common;
using Domain.Resources;

namespace Domain
{
    public interface IStoreRepository
    {
        Task<int> Create(Store store);
        Task Update(Store store);
        Task<Tuple<IList<Store>, int>> FindAll(QueryFilter? queryFilter);
        Task<Store> FindById(int id);
        Task<FilterResponse> FilterAllState(int start, int length);
        Task Delete(int id);
        Task DeleteAll(int[] ids);
    }
}
