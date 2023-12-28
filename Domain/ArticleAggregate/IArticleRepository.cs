using Domain.Common;
using Domain.Resources;

namespace Domain
{
    public interface IArticleRepository
    {
        Task<int> Create(Article article);
        Task Update(Article article);
        Task<Tuple<IList<Article>, int>> FindAll(QueryFilter? queryFilter);
        Task<Article> FindById(int id);
        Task<FilterResponse> FilterAllState(int start, int length);
        Task Delete(int id);
        Task DeleteAll(int[] ids);
    }
}
