using Domain.Common;
using Domain.Resources;

namespace Domain
{
    public interface IEducationSubFieldRepository
    {
        Task<int> Create(EducationSubField educationSubField);
        Task<Tuple<IList<EducationSubField>, int>> FindAll(QueryFilter? queryFilter, int? educationFieldId);
        Task<EducationSubField> FindById(int id);
        Task<FilterResponse> FilterAllEducationField(int start, int length);
        Task Update(EducationSubField educationField);
        Task Delete(int id);
        Task DeleteAll(int[] ids);
    }
}
