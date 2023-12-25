using Domain.Resources;

namespace Domain
{
    public interface ICurrencyTypeRepository
    {
        Task<int> Create(CurrencyType currencyType);
        Task Update(CurrencyType currencyType);
        Task<Tuple<IList<CurrencyType>, int>> FindAll(QueryFilter? queryFilter);
        Task<CurrencyType> FindById(int id);
        Task Delete(int id);
        Task DeleteAll(int[] ids);
    }
}
