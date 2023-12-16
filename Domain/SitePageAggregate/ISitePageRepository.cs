using Domain.Resources;

namespace Domain
{
    public interface ISitePageRepository
    {
        Task<long> Create(SitePage sitepage);
        Task<Tuple<IList<SitePage>, int>> FindAll(QueryFilter? queryFilter);
        Task<SitePage> FindById(long id);
        Task<SitePage> FindByKey(string key);
        Task Update(SitePage sitepage);
        Task Delete(long id);
        Task DeleteAll(long[] ids);
    }
}
