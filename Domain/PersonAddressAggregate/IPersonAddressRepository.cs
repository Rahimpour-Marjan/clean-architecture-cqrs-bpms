using Domain.Common;
using Domain.Resources;

namespace Domain
{
    public interface IPersonAddressRepository
    {
        Task<int> Create(PersonAddress personAddress);
        Task Update(PersonAddress personAddress);
        Task<Tuple<IList<PersonAddress>, int>> FindAll(QueryFilter? queryFilter);
        Task<PersonAddress> FindById(int id);
        Task<FilterResponse> FilterAllPerson(int start, int length);
        Task<FilterResponse> FilterAllCountry(int start, int length);
        Task<FilterResponse> FilterAllState(int start, int length);
        Task<FilterResponse> FilterAllCity(int start, int length);
        Task<FilterResponse> FilterAllZone(int start, int length);
        Task Delete(int id);
        Task DeleteAll(int[] ids);
    }
}
