namespace Api.Infrastructure.Middleware
{
    public static class MiddlewareExtension
    {
        public static void UseJwt(this IApplicationBuilder app)
        {
            //Before
            app.UseMiddleware<JwtMiddleware>();
            //After
        }
        public static void UseAnonymous(this IApplicationBuilder app)
        {
            //Before
            app.UseMiddleware<AnonymousMiddleware>();
            //After
        }
        public static void UseUserAuthorization(this IApplicationBuilder app)
        {
            //Before
            app.UseMiddleware<UserAuthorizationMiddleware>();
            //After
        }
        public static void UseResponse(this IApplicationBuilder app)
        {
            //Before
            app.UseMiddleware<ResponseEditingMiddleware>();
            //After
        }
        public static void UseErrorHandler(this IApplicationBuilder app)
        {
            //Before
            app.UseMiddleware<ErrorHandlerMiddleware>();
            //After
        }
    }
}
