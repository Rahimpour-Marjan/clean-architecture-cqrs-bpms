using Domain.Common;
using Domain.Resources;

namespace Domain
{
    public interface IProductCategoryRepository
    {
        Task<int> Create(ProductCategory category);
        Task Update(ProductCategory category);
        Task<Tuple<IList<ProductCategory>, int>> FindAll(QueryFilter? queryFilter);
        Task<ProductCategory> FindById(int id);
        Task<FilterResponse> FilterAllProductCategoryParent(int start, int length);
        Task Delete(int id);
        Task DeleteAll(int[] ids);
    }
}
