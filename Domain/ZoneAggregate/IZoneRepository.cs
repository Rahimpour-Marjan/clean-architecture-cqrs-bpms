using Domain.Common;
using Domain.Resources;

namespace Domain
{
    public interface IZoneRepository
    {
        Task<int> Create(Zone zone);
        Task Update(Zone zone);
        Task<Tuple<IList<Zone>, int>> FindAll(QueryFilter? queryFilter);
        Task<Zone> FindById(int id);
        Task<FilterResponse> FilterAllCity(int start, int length);
        Task Delete(int id);
        Task DeleteAll(int[] ids);
    }
}
