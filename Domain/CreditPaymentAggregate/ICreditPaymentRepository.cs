using Domain.Common;
using Domain.Resources;

namespace Domain
{
    public interface ICreditPaymentRepository
    {
        Task<int> Create(CreditPayment creditPayment);
        Task Update(CreditPayment creditPayment);
        Task<Tuple<IList<CreditPayment>, int>> FindAll(QueryFilter? queryFilter);
        Task<CreditPayment> FindById(int id);
        Task<FilterResponse> FilterAllAccount(int start, int length);
        Task<FilterResponse> FilterAllAccountCredit(int start, int length);
        Task<FilterResponse> FilterAllCurrencyType(int start, int length);
        Task Delete(int id);
        Task DeleteAll(int[] ids);
    }
}
