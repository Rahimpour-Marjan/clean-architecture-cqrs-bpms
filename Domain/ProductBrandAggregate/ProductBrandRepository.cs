using Domain.Resources;

namespace Domain
{
    public interface IProductBrandRepository
    {
        Task<int> Create(ProductBrand category);
        Task Update(ProductBrand category);
        Task<Tuple<IList<ProductBrand>, int>> FindAll(QueryFilter? queryFilter);
        Task<ProductBrand> FindById(int id);
        Task Delete(int id);
        Task DeleteAll(int[] ids);
    }
}
