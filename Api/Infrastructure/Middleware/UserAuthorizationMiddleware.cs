using Application.User.Queries.FindById;
using Infrastructure.Persistance;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Api.Infrastructure.Middleware
{
    public class UserAuthorizationMiddleware
    {
        private readonly RequestDelegate _next;
        //private readonly IMediator _mediator;
        public UserAuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var userId = (int)context.Items["UserId"];
            var isAnonymous = (bool)context.Items["IsAnonymous"];

            var _mediator = context.RequestServices.GetRequiredService<IMediator>();

            var user = userId <= 0 ? null :
            await _mediator.Send(new FindUserByIdQuery
            {
                Id = userId,
            });

            context.Items["User"] = user;

            if (user != null || isAnonymous)
            {
                await _next(context);
            }
            else
            {
                context.Response.StatusCode = 401;
            }
        }
    }
}