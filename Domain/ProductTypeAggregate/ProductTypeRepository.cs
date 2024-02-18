using Domain.Common;
using Domain.Resources;

namespace Domain
{
    public interface IProductTypeRepository
    {
        Task<int> Create(ProductType productType);
        Task Update(ProductType productType);
        Task<Tuple<IList<ProductType>, int>> FindAll(QueryFilter? queryFilter);
        Task<ProductType> FindById(int id);
        Task<FilterResponse> FilterAllProductTypeParent(int start, int length);
        Task Delete(int id);
        Task DeleteAll(int[] ids);
    }
}
