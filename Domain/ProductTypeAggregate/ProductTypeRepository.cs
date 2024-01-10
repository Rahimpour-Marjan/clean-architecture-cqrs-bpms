using Domain.Resources;

namespace Domain
{
    public interface IProductTypeRepository
    {
        Task<int> Create(ProductType category);
        Task Update(ProductType category);
        Task<Tuple<IList<ProductType>, int>> FindAll(QueryFilter? queryFilter);
        Task<ProductType> FindById(int id);
        Task Delete(int id);
        Task DeleteAll(int[] ids);
    }
}
