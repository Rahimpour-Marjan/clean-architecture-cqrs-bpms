using Domain.Resources;

namespace Domain
{
    public interface IEducationLevelRepository
    {
        Task<int> Create(EducationLevel model);
        Task<Tuple<IList<EducationLevel>, int>> FindAll(QueryFilter? queryFilter);
        Task<EducationLevel> FindById(int id);
        Task Update(EducationLevel model);
        Task Delete(int id);
        Task DeleteAll(int[] ids);
    }
}
