using Domain.Resources;

namespace Domain
{
    public interface IBankRepository
    {
        Task<int> Create(Bank bank);
        Task Update(Bank bank);
        Task<Tuple<IList<Bank>, int>> FindAll(QueryFilter? queryFilter);
        Task<Bank> FindById(int id);
        Task Delete(int id);
        Task DeleteAll(int[] ids);
    }
}
