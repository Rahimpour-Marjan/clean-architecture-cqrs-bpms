using Api.Infrastructure.Services.Contracts;

namespace Api.Infrastructure.Middleware
{
    public class AnonymousMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IAnonymousRequestCheckService _anonymousRequestCheckService;

        public AnonymousMiddleware(
            RequestDelegate next,
            IAnonymousRequestCheckService anonymousRequestCheckService)
        {
            _next = next;
            _anonymousRequestCheckService = anonymousRequestCheckService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Items.Add("IsAnonymous", _anonymousRequestCheckService.Validate(context));
            await _next(context);
        }
    }
}
