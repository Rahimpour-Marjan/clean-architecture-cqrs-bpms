using Domain.Resources;

namespace Domain
{
    public interface ICountryRepository
    {
        Task<int> Create(Country country);
        Task Update(Country country);
        Task<Tuple<IList<Country>, int>> FindAll(QueryFilter? queryFilter);
        Task<Country> FindById(int id);
        Task Delete(int id);
        Task DeleteAll(int[] ids);
    }
}
