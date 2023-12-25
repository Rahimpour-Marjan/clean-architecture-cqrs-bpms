using Domain.Resources;

namespace Domain
{
    public interface ICategoryRepository
    {
        Task<int> Create(Category category);
        Task Update(Category category);
        Task<Tuple<IList<Category>, int>> FindAll(QueryFilter? queryFilter);
        Task<Category> FindById(int id);
        Task Delete(int id);
        Task DeleteAll(int[] ids);
    }
}
