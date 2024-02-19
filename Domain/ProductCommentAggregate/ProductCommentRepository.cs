using Domain.Common;
using Domain.Resources;

namespace Domain
{
    public interface IProductCommentRepository
    {
        Task<int> Create(ProductComment productComment);
        Task Update(ProductComment productComment);
        Task<Tuple<IList<ProductComment>, int>> FindAll(QueryFilter? queryFilter);
        Task<ProductComment> FindById(int id);
        Task<FilterResponse> FilterAllProduct(int start, int length);
        Task<FilterResponse> FilterAllProductCommentParent(int start, int length);
        Task Delete(int id);
        Task DeleteAll(int[] ids);
    }
}
