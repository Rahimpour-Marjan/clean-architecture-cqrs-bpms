using Domain.Common;
using Domain.Resources;

namespace Domain
{
    public interface IAccountCheckRepository
    {
        Task<int> Create(AccountCheck accountCheck);
        Task Update(AccountCheck accountCheck);
        Task<Tuple<IList<AccountCheck>, int>> FindAll(QueryFilter? queryFilter);
        Task<AccountCheck> FindById(int id);
        Task<FilterResponse> FilterAllAccount(int start, int length);
        Task<FilterResponse> FilterAllBank(int start, int length);
        Task Delete(int id);
        Task DeleteAll(int[] ids);
    }
}
