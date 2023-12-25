using Domain.Common;
using Domain.Resources;

namespace Domain
{
    public interface IStateRepository
    {
        Task<int> Create(State state);
        Task Update(State state);
        Task<Tuple<IList<State>, int>> FindAll(QueryFilter? queryFilter);
        Task<State> FindById(int id);
        Task<FilterResponse> FilterAllCountry(int start, int length);
        Task Delete(int id);
        Task DeleteAll(int[] ids);
    }
}
