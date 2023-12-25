
namespace Application.Services
{
    public interface IUriService
    {
        public Uri GetPageUri(int pageNumber, int pageSize, string route);
    }
}
