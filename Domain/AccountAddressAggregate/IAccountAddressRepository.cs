using Domain.Common;
using Domain.Resources;

namespace Domain
{
    public interface IAccountAddressRepository
    {
        Task<int> Create(AccountAddress AccountAddress);
        Task Update(AccountAddress AccountAddress);
        Task<Tuple<IList<AccountAddress>, int>> FindAll(QueryFilter? queryFilter);
        Task<AccountAddress> FindById(int id);
        Task<FilterResponse> FilterAllAccount(int start, int length);
        Task<FilterResponse> FilterAllCountry(int start, int length);
        Task<FilterResponse> FilterAllState(int start, int length);
        Task<FilterResponse> FilterAllCity(int start, int length);
        Task<FilterResponse> FilterAllZone(int start, int length);
        Task Delete(int id);
        Task DeleteAll(int[] ids);
    }
}
