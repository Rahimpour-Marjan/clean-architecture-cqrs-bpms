using Domain.Resources;

namespace Domain
{
    public interface INotificationRepository
    {
        Task<int> Create(Notification notification);
        Task<Tuple<IList<Notification>, int>> FindAll(QueryFilter? queryFilter, int? userId);
        Task<Notification> FindById(int id, int? userId);
        Task Update(Notification notification);
        Task Delete(int id, int? userId);
        Task DeleteAll(int[] ids, int? userId);
    }
}
