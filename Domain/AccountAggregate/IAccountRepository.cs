using Domain.Common;
using Domain.Resources;

namespace Domain
{
    public interface IAccountRepository
    {
        Task AccountJuncPostCreate(List<int> postIds, int AccountId);
        Task<int> Create(Account model);
        Task<bool> IsExistNationCode(string nationalCode);
        Task<bool> IsExistAccountalNumber(string AccountalNumber);
        Task<Tuple<IList<AccountView>, int>> FindAll(QueryFilter? queryFilter);
        Task<FilterResponse> FilterAllPost(int start, int length);
        Task<FilterResponse> FilterAllCountry(int start, int length);
        Task<FilterResponse> FilterAllState(int start, int length);
        Task<FilterResponse> FilterAllCity(int start, int length);
        Task<FilterResponse> FilterAllZone(int start, int length);
        Task<FilterResponse> FilterAllPackage(int start, int length);
        Task<FilterResponse> FilterAllEducationField(int start, int length);
        Task<FilterResponse> FilterAllEducationSubField(int start, int length);
        Task<FilterResponse> FilterAllEducationLevel(int start, int length);
        Task<IList<Account>> FindAllByPost(int[] postIds);
        Task<Account> FindById(int id);
        Task Update(Account model);
        Task Delete(int id);
        Task AccountJuncPostDelete(int id);
        Task AccountJuncPostCreate(IReadOnlyCollection<AccountJuncPost> model);
        Task AccountDeleteAll(int[] ids);
        Task AccountJuncPostDeleteAll(int[] ids);
        Task<IList<AccountJuncPost>> AccountJuncPostGet(int AccountId);
    }
}
