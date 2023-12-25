using Domain;
using Domain.Resources;

namespace Infrastructure.Persistance.Repositories
{
    public interface IUserLogRepository
    {
        Task<int> Create(UserLog user);
        Task<UserLog> FindById(int id);
        Task<IList<UserLog>> FindAll();
        Task<Tuple<IList<UserLog>, int>> FindAll(int? userId, QueryFilter? queryFilter);
        Task Update(UserLog model);
    }
}
