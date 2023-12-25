using Domain.Common;
using Domain.Resources;

namespace Domain
{
    public interface IAccountCreditRepository
    {
        Task<int> Create(AccountCredit accountCredit);
        Task Update(AccountCredit accountCredit);
        Task<Tuple<IList<AccountCredit>, int>> FindAll(QueryFilter? queryFilter);
        Task<AccountCredit> FindById(int id);
        Task<FilterResponse> FilterAllAccount(int start, int length);
        Task<FilterResponse> FilterAllAccountCheck(int start, int length);
        Task Delete(int id);
        Task DeleteAll(int[] ids);
    }
}
