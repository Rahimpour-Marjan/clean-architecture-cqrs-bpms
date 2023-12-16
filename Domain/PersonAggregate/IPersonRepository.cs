using Domain.Common;
using Domain.Resources;

namespace Domain
{
    public interface IPersonRepository
    {
        Task PersonJuncPostCreate(List<int> postIds, int personId);
        Task<int> Create(Person model);
        Task<bool> IsExistNationCode(string nationalCode);
        Task<bool> IsExistPersonalNumber(string personalNumber);
        Task<Tuple<IList<Person>, int>> FindAll(QueryFilter? queryFilter);
        Task<FilterResponse> FilterAllPost(int start, int length);
        Task<IList<Person>> FindAllByPost(int[] postIds);
        Task<Person> FindById(int id);
        Task Update(Person model);
        Task Delete(int id);
        Task PersonJuncPostDelete(int id);
        Task PersonJuncPostCreate(IReadOnlyCollection<PersonJuncPost> model);
        Task PersonDeleteAll(int[] ids);
        Task PersonJuncPostDeleteAll(int[] ids);
        Task<IList<PersonJuncPost>> PersonJuncPostGet(int personId);
    }
}
