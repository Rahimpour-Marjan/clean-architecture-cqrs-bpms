using Domain.Common;
using Domain.Resources;

namespace Domain
{
    public interface ICityRepository
    {
        Task<int> Create(City city);
        Task Update(City city);
        Task<Tuple<IList<City>, int>> FindAll(QueryFilter? queryFilter);
        Task<City> FindById(int id);
        Task<FilterResponse> FilterAllState(int start, int length);
        Task Delete(int id);
        Task DeleteAll(int[] ids);
    }
}
