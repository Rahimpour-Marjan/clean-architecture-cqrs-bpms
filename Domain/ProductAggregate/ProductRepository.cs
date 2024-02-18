using Domain.Common;
using Domain.Resources;

namespace Domain
{
    public interface IProducteRepository
    {
        Task<int> Create(Product product);
        Task Update(Product product);
        Task<Tuple<IList<Product>, int>> FindAll(QueryFilter? queryFilter);
        Task<Product> FindById(int id);
        Task<FilterResponse> FilterAllProductType(int start, int length);
        Task<FilterResponse> FilterAllProductCategory(int start, int length);
        Task<FilterResponse> FilterAllProductBrand(int start, int length);
        Task Delete(int id);
        Task DeleteAll(int[] ids);
    }
}
