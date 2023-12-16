using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MediatR;
using Application.User.Queries.FindAccessById;


namespace Api.Authorization
{
    public class CustomAuthorizeFilter : IAsyncAuthorizationFilter
    {
        private readonly IMediator _mediator;

        public CustomAuthorizeFilter(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            // skip authorization if action is decorated with [AllowAnonymous] attribute
            var allowAnonymous = (bool)context.HttpContext.Items["IsAnonymous"];
            if (allowAnonymous)
                return;

            // authorization

            if (context.HttpContext.Items["UserId"] == null)
            {
                // not logged in or role not authorized
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
            else
            {
#pragma warning disable CS8605 // Unboxing a possibly null value.
                var currentUserId = (int)context.HttpContext.Items["UserId"];
#pragma warning restore CS8605 // Unboxing a possibly null value.

                var userAccess = await _mediator.Send(new FindAccessByIdQuery { Id = currentUserId });

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                var attribute = (CustomAuthorizeAttribute)context.ActionDescriptor.EndpointMetadata
                    .FirstOrDefault(m => m.GetType() == typeof(CustomAuthorizeAttribute));
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

                if (attribute != null)
                {
                    var actions = attribute._requiredActions.ToList();
                    var permission = false;
                    foreach (var action in actions)
                    {
                        if (userAccess != null && attribute != null && userAccess.Any(x => x.Controller + "_" + x.Action == action.ToString()))
                        {
                            permission=true;
                        }
                    }
                    if (permission == false)
                    {
                        // not logged in or role not authorized
                        context.Result = new ForbidResult();
                        //context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
                    }
                }
            }

        }
    }
}
