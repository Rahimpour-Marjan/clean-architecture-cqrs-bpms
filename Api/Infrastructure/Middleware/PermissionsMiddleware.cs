//using AuthUtils;
//using Microsoft.AspNetCore.Http;
//using Microsoft.Extensions.Logging;
//using System.Threading.Tasks;

namespace Api.Infrastructure.Middleware
{
    public class PermissionsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<PermissionsMiddleware> _logger;

        public PermissionsMiddleware(
            RequestDelegate next,
            ILogger<PermissionsMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        //public async Task InvokeAsync(
        //    HttpContext context, IUserPermissionService permissionService)
        //{
        //    // 1 - if the request is not authenticated, nothing to do
        //    if (context.User.Identity == null || !context.User.Identity.IsAuthenticated)
        //    {
        //        await _next(context);
        //        return;
        //    }

        //    var cancellationToken = context.RequestAborted;

        //    // 2. The 'sub' claim is how we find the user in our system
        //    var userSub = context.User.FindFirst(StandardJwtClaimTypes.Subject)?.Value;
        //    if (string.IsNullOrEmpty(userSub))
        //    {
        //        await context.WriteAccessDeniedResponse(
        //          "User 'sub' claim is required",
        //          cancellationToken: cancellationToken);
        //        return;
        //    }

        //    // 3 - Now we try to get the user permissions (as ClaimsIdentity)
        //    var permissionsIdentity = await permissionService
        //        .GetUserPermissionsIdentity(userSub, cancellationToken);
        //    if (permissionsIdentity == null)
        //    {
        //        _logger.LogWarning("User {sub} does not have permissions", userSub);

        //        await context.WriteAccessDeniedResponse(cancellationToken: cancellationToken);
        //        return;
        //    }

        //    // 4 - User has permissions
        //    // so we add the extra identity to the ClaimsPrincipal
        //    context.User.AddIdentity(permissionsIdentity);
        //    await _next(context);
        //}
    }
}