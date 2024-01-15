using Domain.Common;
using Domain.Resources;

namespace Domain
{
    public interface IProductBrandRepository
    {
        Task<int> Create(ProductBrand category);
        Task Update(ProductBrand category);
        Task<Tuple<IList<ProductBrand>, int>> FindAll(QueryFilter? queryFilter);
        Task<ProductBrand> FindById(int id);
        Task<FilterResponse> FilterAllProductType(int start, int length);
        Task Delete(int id);
        Task DeleteAll(int[] ids);
    }
}
