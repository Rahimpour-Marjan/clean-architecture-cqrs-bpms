using Domain;
using Domain.Enums;
using Domain.Resources;

namespace Infrastructure.Persistance.Repositories
{
    public interface IUserRepository
    {
        Task<int> Create(User user);
        Task<User> FindById(int id);
        Task<User> FindByUserName(string userName);
        Task<User> FindByType(UserType userType);
        Task<IList<User>> FindAll();
        Task<IList<User>> FindAllByPost(int postId);
        Task<IList<User>> FindAllByPerson(int personId);
        Task<Tuple<IList<User>, int>> FindAll(QueryFilter? queryFilter);
        Task<User> FindByAuthInfo(string userName, string password);
        Task<List<SiteAction>?> FindAccess(int userId);
        Task Update(User model);
        Task Delete(int id);
        Task DeleteAll(int[] ids);
    }
}
