using Domain.Resources;

namespace Domain
{
    public interface IEducationFieldRepository
    {
        Task<int> Create(EducationField educationField);
        Task<Tuple<IList<EducationField>, int>> FindAll(QueryFilter? queryFilter);
        Task<EducationField> FindById(int id);
        Task Update(EducationField educationField);
        Task Delete(int id);
        Task DeleteAll(int[] ids);
    }
}
