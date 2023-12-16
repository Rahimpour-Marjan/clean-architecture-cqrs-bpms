using Domain.Resources;

namespace Domain
{
    public interface ISiteActionRepository
    {
        Task<int> Create(SiteAction siteAction);
        Task<Tuple<IList<SiteAction>, int>> FindAll(QueryFilter? queryFilter);
        Task<SiteAction> FindById(int id);
        Task Update(SiteAction siteAction);
        Task Delete(int id);
        Task DeleteAll(int[] ids);
    }
}
