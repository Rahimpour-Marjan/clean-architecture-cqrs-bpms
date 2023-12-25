namespace Api.Infrastructure.Services.Contracts
{
    public interface IAnonymousRequestCheckService
    {
        bool Validate(HttpContext context);
    }
}